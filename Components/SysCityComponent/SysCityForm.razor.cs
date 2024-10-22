using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysCityComponent
{
	public partial class SysCityForm
	{
		#region Service
		[Inject] SysProvinceService SysProvinceService { get; set; } = null!;
		[Inject] SysCityService SysCityService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter, EditorRequired] public string? ID { get; set; }
		[Parameter, EditorRequired] public string? ProvinceID { get; set; }
		#endregion

		#region Component Field
		#endregion

		#region Field
		public SysCityModel row = new();
		public SysProvinceModel? rowProvince;
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
				row = new SysCityModel() { IsActive = 1, ProvinceID = ProvinceID };
			}

			rowProvince = await SysProvinceService.GetRowByID(ProvinceID);
			await base.OnInitializedAsync();
		}
		#endregion

		#region GetRow
		public async Task GetRow()
		{
			row = await SysCityService.GetRowByID(ID) ?? new();
			StateHasChanged();
		}
		#endregion



		#region ChangeActive
		private async Task ChangeActive()
		{
			if (ID != null)
			{
				Loading.Show();
				var res = await SysCityService.ChangeStatus(row);

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
				var res = await SysCityService.Insert(row);

				if (res?.Data != null)
				{
					NavigationManager.NavigateTo($"/commonmasterfile/province/{ProvinceID}/city/{res.Data.ID}", true);
				}
			}
			#endregion

			#region Update
			else
			{
				await SysCityService.Update(row);
			}
			#endregion
			Loading.Close();
			StateHasChanged();
		}
		#endregion

		#region Back
		private void Back()
		{
			NavigationManager.NavigateTo($"/commonmasterfile/province/{ProvinceID}");
		}
		#endregion
	}
}
