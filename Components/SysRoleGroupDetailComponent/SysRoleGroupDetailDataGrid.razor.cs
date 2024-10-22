using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysRoleGroupDetailComponent
{
	public partial class SysRoleGroupDetailDataGrid
	{
		#region Service
		[Inject] SysRoleGroupDetailService SysRoleGroupDetailService { get; set; } = null!;
		[Inject] SysMenuRoleService SysMenuRoleService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter] public string? GroupRoleID { get; set; }
		#endregion

		#region Component Field
		DataGrid<SysRoleGroupDetailModel> dataGrid = null!;
		MultipleSelectLookup<SysMenuRoleModel> menuRoleLookup = null!;
		#endregion

		#region Field
		SysRoleGroupDetailModel filter = new()
		{
			RoleAccess = "all",
			MenuID = "all",
			SubMenuID = "all",
			ModuleID = "all"
		};
		SysRoleGroupDetailModel lookupFilter = new()
		{
			RoleAccess = "all",
			MenuID = "all",
			SubMenuID = "all",
			ModuleID = "all"
		};
		#endregion

		#region OnInitialized
		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
		}
		#endregion

		#region LoadData
		protected async Task<List<SysRoleGroupDetailModel>?> LoadData(string keyword)
		{
			return await SysRoleGroupDetailService.GetRows(keyword, 0, 100, GroupRoleID, filter.RoleAccess, filter.MenuID, filter.SubMenuID, filter.ModuleID);
		}
		protected async Task<List<SysMenuRoleModel>?> LoadLookupMenuRole(string keyword)
		{
			return await SysMenuRoleService.GetRowsLookupForRoleGroupDetail(keyword, 0, 100, GroupRoleID, lookupFilter.ModuleID, lookupFilter.MenuID, lookupFilter.SubMenuID, lookupFilter.RoleAccess);
		}
		#endregion

		#region Add
		private async void Add()
		{
			var data = menuRoleLookup.GetSelected().Select(x => new SysRoleGroupDetailModel
			{
				RoleGroupID = GroupRoleID,
				RoleID = x.ID
			}).ToList();

			Loading.Show();
			await SysRoleGroupDetailService.Insert(data);
			Loading.Close();

			await dataGrid.Reload();
			await menuRoleLookup.Reload();
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

				await SysRoleGroupDetailService.DeleteByID(selectedData.Select(row => row.ID).ToArray());

				await dataGrid.Reload();
				dataGrid.selectedData.Clear();

				Loading.Close();

				StateHasChanged();
			}
		}
		#endregion
	}
}
