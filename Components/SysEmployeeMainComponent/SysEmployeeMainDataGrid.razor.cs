using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysEmployeeMainComponent
{
  public partial class SysEmployeeMainDataGrid
  {
    #region Service
    [Inject] SysEmployeeMainService SysEmployeeMainService { get; set; } = null!;
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
      return await SysEmployeeMainService.GetRows(keyword, 0, 100);
    }
    #endregion

    #region Add
    private void Add()
    {
      NavigationManager.NavigateTo("/companyinformation/employee/add");
    }
    #endregion
  }
}
