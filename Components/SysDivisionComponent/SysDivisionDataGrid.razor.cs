using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysDivisionComponent
{
	public partial class SysDivisionDataGrid
	{
		[Inject] SysDivisionService SysDivisionService { get; set; } = null!;
		DataGrid<SysDivisionModel> dataGrid = null!;

		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
		}

		protected async Task<List<SysDivisionModel>?> LoadData(string keyword)
		{
			return await SysDivisionService.GetRows(keyword, 0, 100);
		}

		private void Add()
		{
			NavigationManager.NavigateTo("/companyinformation/division/add");
		}

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

				await SysDivisionService.DeleteByID(dataGrid.selectedData.Select(row => row.ID).ToArray());

				await dataGrid.Reload();
				dataGrid.selectedData.Clear();

				Loading.Close();

				StateHasChanged();
			}
		}
	}
}
