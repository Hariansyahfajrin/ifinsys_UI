using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysProvinceComponent
{
	public partial class SysProvinceForm
	{
		#region Service
		[Inject] SysProvinceService SysProvinceService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter, EditorRequired] public string? ID { get; set; }
		#endregion

		#region Component Field
		#endregion

		#region Field
		public SysProvinceModel row = new();
		#endregion

		#region OnInitialized
		protected override async Task OnInitializedAsync()
		{
			if (ID != null)
			{
				await GetRow();
			}
			else
			{
				row = new SysProvinceModel() { IsActive = 1 };
			}
			await base.OnInitializedAsync();
		}
		#endregion

		#region GetRow
		public async Task GetRow()
		{
			row = await SysProvinceService.GetRowByID(ID) ?? new();
			StateHasChanged();
		}
		#endregion



		#region ChangeActive
		private async Task ChangeActive()
		{
			if (ID != null)
			{
				Loading.Show();
				var res = await SysProvinceService.ChangeStatus(row);

				if (res != null)
				{
					await GetRow();
					Loading.Close();
				}

				StateHasChanged();
			}
		}
		#endregion

		#region OnSubmit
		private async void OnSubmit()
		{
			Loading.Show();

			#region Insert
			if (ID == null)
			{
				var res = await SysProvinceService.Insert(row);

				Loading.Close();

				if (res != null)
				{
					if (res.Data != null)
					{
						NavigationManager.NavigateTo($"/commonmasterfile/province/{res.Data.ID}", true);
					}
					Loading.Close();
					StateHasChanged();
				}
			}
			#endregion

			#region Update
			else
			{
				var res = await SysProvinceService.Update(row);

				if (res != null)
				{
					Loading.Close();
				}
				StateHasChanged();
			}
			#endregion
		}
		#endregion

		#region Back
		private void Back()
		{
			NavigationManager.NavigateTo("/commonmasterfile/province");
		}
		#endregion
	}
}
