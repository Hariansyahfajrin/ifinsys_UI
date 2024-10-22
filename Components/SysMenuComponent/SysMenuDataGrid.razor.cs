using Data.Model;
using Data.Service;
using Microsoft.AspNetCore.Components;
using IFinancing360_UI.Components;

namespace IFinancing360_SYS_UI.Components.SysMenuComponent
{
	public partial class SysMenuDataGrid
	{
		[Inject] SysMenuService SysMenuService { get; set; } = default!;
		[Inject] SysModuleService SysModuleService { get; set; } = default!;
		DataGrid<SysMenuModel> dataGrid = new();
		SingleSelectLookup<SysModuleModel> moduleLookup = new();
		SingleSelectLookup<SysMenuModel> parentLookup = new();

		private SysMenuModel filter = new()
		{
			ModuleID = "all",
			ModuleCode = "ALL",
			ParentMenuID = "all",
			ParentMenuName = "ALL"
		};

		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
		}

		private async Task<List<SysMenuModel>?> LoadData(string keyword)
		{
			return await SysMenuService.GetRows(keyword, 0, 100, ModuleID: filter.ModuleID ?? default!, ParentMenuID: filter.ParentMenuID ?? default!);
		}
		protected async Task<List<SysModuleModel>?> LoadModuleLookup(string keyword)
		{
			return await SysModuleService.GetRowsForLookupModule(keyword, 0, 100, true);
		}
		protected async Task<List<SysMenuModel>?> LoadParentLookup(string keyword)
		{
			return await SysMenuService.GetRowsForLookupParent(keyword, 0, 100, filter.ModuleID ?? default!, true);
		}

		private void Add()
		{
			NavigationManager.NavigateTo("/systemsetting/menu/add");
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
				var IDList = dataGrid.selectedData.Select(row => row.ID ?? "").ToList() ?? [];

				await SysMenuService.Delete(IDList.ToArray());

				await dataGrid.Reload();
				dataGrid.selectedData.Clear();

				Loading.Close();

				StateHasChanged();
			}
		}
	}
}