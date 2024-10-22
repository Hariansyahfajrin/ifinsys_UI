using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysUserMainGroupSecComponent
{
	public partial class SysUserMainGroupSecDataGrid
	{
		#region Service
		[Inject] SysUserMainGroupSecService SysUserMainGroupSecService { get; set; } = null!;
		[Inject] SysRoleGroupService SysRoleGroupService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter, EditorRequired] public string? UserID { get; set; }
		#endregion

		#region Component Field
		DataGrid<SysUserMainGroupSecModel> dataGrid = null!;
		MultipleSelectLookup<SysRoleGroupModel> groupRoleLookup = null!;
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
		protected async Task<List<SysUserMainGroupSecModel>?> LoadData(string keyword)
		{
			return await SysUserMainGroupSecService.GetRows(keyword, 0, 100, UserID);
		}

		protected async Task<List<SysRoleGroupModel>?> LoadLookupGroupRole(string keyword)
		{
			return await SysRoleGroupService.GetRowsLookupForUserGroupRole(keyword, 0, 100, UserID);
		}
		#endregion

		#region Add
		private async void Add()
		{
			Loading.Show();

			var data = groupRoleLookup.GetSelected().Select(x => new SysUserMainGroupSecModel
			{
				RoleGroupID = x.ID,
				UserID = UserID
			}).ToList();

			await SysUserMainGroupSecService.Insert(data);

			Loading.Close();

			await dataGrid.Reload();
			await groupRoleLookup.Reload();

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

				await SysUserMainGroupSecService.DeleteByID(dataGrid.selectedData.Select(row => row.ID).ToArray());

				await dataGrid.Reload();
				dataGrid.selectedData.Clear();

				Loading.Close();

				StateHasChanged();
			}
		}
		#endregion
	}
}
