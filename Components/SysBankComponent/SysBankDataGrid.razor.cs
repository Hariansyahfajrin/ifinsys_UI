using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysBankComponent
{
	public partial class SysBankDataGrid
	{
		#region Service
		[Inject] SysBankService SysBankService { get; set; } = null!;
		#endregion

		#region Component Field
		DataGrid<SysBankModel> dataGrid = null!;
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
		protected async Task<List<SysBankModel>?> LoadData(string keyword)
		{
			return await SysBankService.GetRows(keyword, 0, 100);
		}
		#endregion

		#region Add
		private void Add()
		{
			NavigationManager.NavigateTo($"/commonmasterfile/bank/add");
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

				await SysBankService.DeleteByID(dataGrid.selectedData.Select(row => row.ID ?? "").ToArray());

				await dataGrid.Reload();
				dataGrid.selectedData.Clear();

				Loading.Close();

				StateHasChanged();
			}
		}
		#endregion
	}
}
