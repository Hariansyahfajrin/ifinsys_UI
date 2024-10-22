using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysDepartmentComponent
{
	public partial class SysDepartmentDataGrid
	{
		[Inject] SysDepartmentService SysDepartmentService { get; set; } = null!;
		DataGrid<SysDepartmentModel> dataGrid = null!;

		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
		}

		protected async Task<List<SysDepartmentModel>?> LoadData(string keyword)
		{
			return await SysDepartmentService.GetRows(keyword, 0, 100);
		}

		private void Add()
		{
			NavigationManager.NavigateTo("/companyinformation/department/add");
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

				await SysDepartmentService.DeleteByID(dataGrid.selectedData.Where(row => row.ID is not null).Select(row => row.ID).ToArray());

				await dataGrid.Reload();
				dataGrid.selectedData.Clear();

				Loading.Close();

				StateHasChanged();
			}
		}
	}
}
