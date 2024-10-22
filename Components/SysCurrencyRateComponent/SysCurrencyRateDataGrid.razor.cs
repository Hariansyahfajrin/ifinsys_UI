using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysCurrencyRateComponent
{
	public partial class SysCurrencyRateDataGrid
	{
		#region Service
		[Inject] SysCurrencyRateService SysCurrencyRateService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter, EditorRequired] public string? CurrencyID { get; set; }
		#endregion

		#region Component Field
		DataGrid<SysCurrencyRateModel> dataGrid = null!;
		#endregion

		#region Field
		public SysCurrencyModel row = new();
		#endregion

		#region LoadData
		protected async Task<List<SysCurrencyRateModel>?> LoadData(string keyword)
		{
			return await SysCurrencyRateService.GetRows(keyword, 0, 100, CurrencyID);
		}
		#endregion

		#region Add
		private void Add()
		{
			NavigationManager.NavigateTo($"/commonmasterfile/currency/{CurrencyID}/rate/add");
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

			if (result == true)
			{
				Loading.Show();

				await SysCurrencyRateService.DeleteByID(dataGrid.selectedData.Select(row => row.ID).ToArray());

				await dataGrid.Reload();
				dataGrid.selectedData.Clear();

				Loading.Close();

				StateHasChanged();
			}
		}
		#endregion
	}
}
