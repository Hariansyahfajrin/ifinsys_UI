using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysEmployeePositionComponent
{
  public partial class SysEmployeePositionForm
  {
    #region Service
    [Inject] SysEmployeePositionService SysEmployeePositionService { get; set; } = null!;
    [Inject] SysPositionService SysPositionService { get; set; } = null!;
    [Inject] SysEmployeeMainService SysEmployeeMainService { get; set; } = null!;
    #endregion

    #region Parameter
    [Parameter, EditorRequired] public string? ID { get; set; }
    [Parameter, EditorRequired] public string? EmployeeID { get; set; }
    #endregion

    #region Component Field
    SingleSelectLookup<SysPositionModel>? positionLookup;
    #endregion

    #region Field
    public SysEmployeePositionModel row = new();
    public SysEmployeeMainModel employeeMain = new();
    #endregion

    #region OnInitialized
    protected override async Task OnInitializedAsync()
    {
      if (ID != null)
      {
        await GetRow();
      }
      else
      {
        row.EmployeeID = EmployeeID;
      }

      employeeMain = await SysEmployeeMainService.GetRowByID(EmployeeID) ?? new();
      await base.OnInitializedAsync();
    }
    #endregion

    #region GetRow
    public async Task GetRow()
    {
      row = await SysEmployeePositionService.GetRowByID(ID) ?? new();
      StateHasChanged();
    }
    #endregion

    #region Load Data Lookup
    public async Task<List<SysPositionModel>?> LoadPositionLookup(string keyword)
    {
      return await SysPositionService.GetRowsForLookup(keyword, 0, 100) ?? [];
    }

    #endregion

    #region OnSubmit
    private async void OnSubmit()
    {
      Loading.Show();

      #region Insert
      if (ID == null)
      {
        var res = await SysEmployeePositionService.Insert(row);

        if (res?.Data != null)
        {
          NavigationManager.NavigateTo($"/companyinformation/employee/{EmployeeID}/employeeposition/{res.Data.ID}", true);
        }
        Loading.Close();
        StateHasChanged();
      }
      #endregion

      #region Update
      else
      {
        await SysEmployeePositionService.Update(row);

      }
      #endregion
      Loading.Close();
      StateHasChanged();
    }
    #endregion

    #region Back
    private void Back()
    {
      NavigationManager.NavigateTo($"/companyinformation/employee/{EmployeeID}");
    }
    #endregion
  }
}
