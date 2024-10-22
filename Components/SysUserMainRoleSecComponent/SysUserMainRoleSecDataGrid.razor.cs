using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysUserMainRoleSecComponent
{
	public partial class SysUserMainRoleSecDataGrid
	{
		#region Service
		[Inject] SysUserMainRoleSecService SysUserMainRoleSecService { get; set; } = null!;
		[Inject] SysMenuRoleService SysMenuRoleService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter, EditorRequired] public string? UserID { get; set; }
		#endregion

		#region Component Field
		DataGrid<SysUserMainRoleSecModel> dataGrid = null!;
		MultipleSelectLookup<SysMenuRoleModel> menuRoleLookup = null!;
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
		protected async Task<List<SysUserMainRoleSecModel>?> LoadData(string keyword)
		{
			return await SysUserMainRoleSecService.GetRows(keyword, 0, 100, UserID);
		}

		protected async Task<List<SysMenuRoleModel>?> LoadLookupMenuRole(string keyword)
		{
			return await SysMenuRoleService.GetRowsLookupForUserRole(keyword, 0, 100, UserID);
		}
		#endregion

		#region Add
		private async void Add()
		{
			Loading.Show();

			var data = menuRoleLookup.GetSelected().Select(x => new SysUserMainRoleSecModel
			{
				RoleID = x.ID,
				UserID = UserID
			}).ToList();

			await SysUserMainRoleSecService.Insert(data);

			Loading.Close();

			await dataGrid.Reload();
			await menuRoleLookup.Reload();

			StateHasChanged();

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

				await SysUserMainRoleSecService.DeleteByID(dataGrid.selectedData.Select(row => row.ID).ToArray());

				await dataGrid.Reload();
				dataGrid.selectedData.Clear();

				Loading.Close();

				StateHasChanged();
			}
		}
		#endregion
	}
}
