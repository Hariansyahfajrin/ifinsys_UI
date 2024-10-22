using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysBranchBankComponent
{
	public partial class SysBranchBankDataGrid
	{
		#region Service
		[Inject] SysBranchBankService SysBranchBankService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter] public string BranchID { get; set; } = "";
		#endregion

		#region Component Field
		DataGrid<SysBranchBankModel> dataGrid = null!;
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
		protected async Task<List<SysBranchBankModel>?> LoadData(string keyword)
		{
			return await SysBranchBankService.GetRows(keyword, 0, 100, BranchID);
		}
		#endregion

		#region Add
		private void Add()
		{
			NavigationManager.NavigateTo($"/companyinformation/branch/{BranchID}/branchbank/add");
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

				await SysBranchBankService.DeleteByID(selectedData.Select(row => row.ID ?? "").ToArray());

				await dataGrid.Reload();
				dataGrid.selectedData.Clear();

				Loading.Close();

				StateHasChanged();
			}
		}
		#endregion
	}
}
