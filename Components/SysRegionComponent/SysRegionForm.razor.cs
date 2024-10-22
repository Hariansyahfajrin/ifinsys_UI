using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysRegionComponent
{
	public partial class SysRegionForm
	{
		#region Service
		[Inject] SysRegionService SysRegionService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter, EditorRequired] public string? ID { get; set; }
		#endregion

		#region Component Field
		#endregion

		#region Field
		public SysRegionModel row = new();
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
				row = new SysRegionModel() { IsActive = 1 };
			}
			await base.OnInitializedAsync();
		}
		#endregion

		#region GetRow
		public async Task GetRow()
		{
			Loading.Show();
			row = await SysRegionService.GetRowByID(ID) ?? new();
			Loading.Close();
			StateHasChanged();
		}
		#endregion

		#region ChangeActive
		private async Task ChangeActive()
		{
			if (ID != null)
			{
				Loading.Show();
				var res = await SysRegionService.ChangeStatus(row);

				if (res != null)
				{
					await GetRow();
				}

				Loading.Close();
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
				var res = await SysRegionService.Insert(row);

				if (res?.Data != null)
				{
					NavigationManager.NavigateTo($"/companyinformation/areabranch/{res.Data.ID}", true);
				}

			}
			#endregion

			#region Update
			else
			{
				await SysRegionService.Update(row);
			}
			#endregion

			Loading.Close();
			StateHasChanged();
		}
		#endregion

		#region Back
		private void Back()
		{
			NavigationManager.NavigateTo("/companyinformation/areabranch");
		}
		#endregion
	}
}
