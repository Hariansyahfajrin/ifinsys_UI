using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysEmployeeMainComponent
{
	public partial class BranchEmployeeDataGrid
	{
		#region Service
		[Inject] SysEmployeeMainService SysEmployeeMainService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter] public string BranchID { get; set; } = "";
		#endregion

		#region Component Field
		DataGrid<SysEmployeeMainModel> dataGrid = null!;
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
		protected async Task<List<SysEmployeeMainModel>?> LoadData(string keyword)
		{
			return await SysEmployeeMainService.GetRowsByBranch(keyword, 0, 100, BranchID);
		}
		#endregion
	}
}
