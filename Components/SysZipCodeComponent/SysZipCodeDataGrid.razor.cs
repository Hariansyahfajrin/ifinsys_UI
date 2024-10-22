using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysZipCodeComponent
{
	public partial class SysZipCodeDataGrid
	{
		#region Service
		[Inject] SysZipCodeService SysZipCodeService { get; set; } = null!;
		#endregion

		#region Component Field
		DataGrid<SysZipCodeModel> dataGrid = null!;
		#endregion

		#region Field

		#endregion

		#region OnInitialized
		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
		}
		#endregion

		#region LoadData
		protected async Task<List<SysZipCodeModel>?> LoadData(string keyword)
		{
			return await SysZipCodeService.GetRows(keyword, 0, 100);
		}
		#endregion

		#region Add
		private void Add()
		{
			NavigationManager.NavigateTo("/commonmasterfile/zipcode/add");
		}
		#endregion

		#region Delete
		private async void Delete()
		{

			var selectedData = dataGrid.selectedData;

			if (!selectedData.Any())
			{
				await NoDataSelectedAlert();
				return;
			}

			bool? result = await Confirm();

			if (result == true)
			{
				Loading.Show();

				await SysZipCodeService.Delete(selectedData.Select(row => row.ID ?? "").ToArray());

				await dataGrid.Reload();
				dataGrid.selectedData.Clear();

				Loading.Close();

				StateHasChanged();
			}
		}
		#endregion
	}
}
