using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysZipCodeComponent
{
	public partial class SysZipCodeForm
	{
		#region Service
		[Inject] SysZipCodeService SysZipCodeService { get; set; } = null!;
		[Inject] SysProvinceService SysProvinceService { get; set; } = null!;
		[Inject] SysCityService SysCityService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter, EditorRequired] public string? ID { get; set; }
		#endregion

		#region Component Field
		SingleSelectLookup<SysProvinceModel>? provinceLookup;
		SingleSelectLookup<SysCityModel>? cityLookup;
		#endregion

		#region Field
		public SysZipCodeModel row = new();
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
				row = new SysZipCodeModel() { IsActive = 1 };
			}

			await base.OnInitializedAsync();
		}
		#endregion

		#region GetRow
		public async Task GetRow()
		{
			Loading.Show();
			row = await SysZipCodeService.GetRowByID(ID) ?? new();
			Loading.Close();
			StateHasChanged();
		}
		#endregion

		#region Load Province Lookup
		protected async Task<List<SysProvinceModel>?> LoadProvinceLookup(string keyword)
		{
			return await SysProvinceService.GetRowsForLookup(keyword, 0, 100);
		}
		#endregion

		#region Load City Lookup
		protected async Task<List<SysCityModel>?> LoadCityLookup(string keyword)
		{
			return await SysCityService.GetRowsForLookup(keyword, 0, 100, row.ProvinceID ?? "");
		}
		#endregion

		#region ChangeActive
		private async Task ChangeActive()
		{
			if (ID != null)
			{
				Loading.Show();
				var res = await SysZipCodeService.ChangeStatus(row);

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
				var res = await SysZipCodeService.Insert(row);

				if (res?.Data != null)
				{
					NavigationManager.NavigateTo($"/commonmasterfile/zipcode/{res.Data.ID}", true);
				}
			}
			#endregion

			#region Update
			else
			{
				await SysZipCodeService.Update(row);
			}
			#endregion
			Loading.Close();
			StateHasChanged();
		}
		#endregion

		#region Back
		private void Back()
		{
			NavigationManager.NavigateTo($"/commonmasterfile/zipcode");
		}
		#endregion
	}
}
