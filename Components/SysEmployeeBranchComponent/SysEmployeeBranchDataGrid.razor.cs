using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysEmployeeBranchComponent
{
  public partial class SysEmployeeBranchDataGrid
  {
    #region Service
    [Inject] SysEmployeeBranchService SysEmployeeBranchService { get; set; } = null!;
    #endregion

    #region Parameter
    [Parameter, EditorRequired] public string? EmployeeID { get; set; }
    #endregion

    #region Component Field
    DataGrid<SysEmployeeBranchModel> dataGrid = null!;
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
    protected async Task<List<SysEmployeeBranchModel>?> LoadData(string keyword)
    {
      return await SysEmployeeBranchService.GetRows(keyword, 0, 100, EmployeeID);
    }
    #endregion

    #region Add
    private void Add()
    {
      NavigationManager.NavigateTo($"/companyinformation/employee/{EmployeeID}/employeebranch/add");
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

        await SysEmployeeBranchService.DeleteByID(selectedData.Select(row => row.ID ?? "").ToArray());

        await dataGrid.Reload();
        dataGrid.selectedData.Clear();

        Loading.Close();

        StateHasChanged();
      }
    }
    #endregion
  }
}
