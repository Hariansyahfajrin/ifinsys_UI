using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysCompanyParamComponent
{
	public partial class SysCompanyParamDataGrid
	{
		#region Service
		[Inject] SysCompanyParamService SysCompanyParamService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter, EditorRequired] public string? CompanyID { get; set; }
		#endregion

		#region Component Field
		DataGrid<SysCompanyParamModel>? dataGrid;
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
		public async Task<List<SysCompanyParamModel>?> LoadData(string? keyword)
		{
			return await SysCompanyParamService.GetRows(keyword, 0, 100) ?? [];
		}
		#endregion

		#region Add
		private void Add()
		{
			NavigationManager.NavigateTo($"/companyinformation/company/{CompanyID}/companyparam/add");
		}
		#endregion
	}
}
