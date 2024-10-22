using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysEmployeePositionComponent
{
  public partial class SysEmployeePositionDataGrid
  {
    #region Service
    [Inject] SysEmployeePositionService SysEmployeePositionService { get; set; } = null!;
    #endregion

    #region Parameter
    [Parameter] public string? EmployeeID { get; set; }
    #endregion

    #region Component Field
    DataGrid<SysEmployeePositionModel> dataGrid = null!;
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
    protected async Task<List<SysEmployeePositionModel>?> LoadData(string keyword)
    {
      return await SysEmployeePositionService.GetRows(keyword, 0, 100, EmployeeID);
    }
    #endregion

    #region Add
    private void Add()
    {
      NavigationManager.NavigateTo($"/companyinformation/employee/{EmployeeID}/employeeposition/add");
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

        await SysEmployeePositionService.Delete(selectedData.Select(row => row.ID ?? "").ToArray());

        await dataGrid.Reload();
        dataGrid.selectedData.Clear();

        Loading.Close();

        StateHasChanged();
      }
    }
    #endregion
  }
}
