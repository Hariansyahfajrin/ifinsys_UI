using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysCityComponent
{
	public partial class SysCityDataGrid
	{
		#region Service
		[Inject] SysProvinceService SysProvinceService { get; set; } = null!;
		[Inject] SysCityService SysCityService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter, EditorRequired] public string? ProvinceID { get; set; }
		#endregion

		#region Component Field
		DataGrid<SysCityModel> dataGrid = null!;
		#endregion

		#region LoadData
		public async Task<List<SysCityModel>?> LoadData(string keyword)
		{
			return await SysCityService.GetRows(keyword, 0, 100, ProvinceID ?? "");
		}
		#endregion

		#region Add
		private void Add()
		{
			NavigationManager.NavigateTo($"/commonmasterfile/province/{ProvinceID}/city/add");
		}
		#endregion

		#region Delete
		private async void Delete()
		{
			if (!dataGrid.selectedData.Any())
			{
				await NoDataSelectedAlert();
				return;
			}

			bool? result = await Confirm();

			var selectedData = dataGrid.selectedData.Select(row => row.ID ?? "").ToArray();

			if (selectedData.Length <= 0)
			{
				await NoDataSelectedAlert();
				return;
			}

			if (result == true)
			{
				Loading.Show();

				await SysCityService.Delete(selectedData);

				await dataGrid.Reload();
				dataGrid.selectedData.Clear();

				Loading.Close();

				StateHasChanged();
			}
		}
		#endregion
	}
}
