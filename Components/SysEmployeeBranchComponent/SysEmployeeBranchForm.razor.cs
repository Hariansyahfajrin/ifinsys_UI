using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysEmployeeBranchComponent
{
  public partial class SysEmployeeBranchForm
  {
    #region Service
    [Inject] SysEmployeeBranchService SysEmployeeBranchService { get; set; } = null!;
    [Inject] SysBranchService SysBranchService { get; set; } = null!;
    [Inject] SysEmployeeMainService SysEmployeeMainService { get; set; } = null!;
    #endregion

    #region Parameter
    [Parameter, EditorRequired] public string? ID { get; set; }
    [Parameter, EditorRequired] public string? EmployeeID { get; set; }
    #endregion

    #region Component Field
    SingleSelectLookup<SysBranchModel>? branchLookup;
    #endregion

    #region Field
    public SysEmployeeBranchModel row = new();
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
      row = await SysEmployeeBranchService.GetRowByID(ID) ?? new();
      StateHasChanged();
    }
    #endregion

    #region Load Data Lookup
    public async Task<List<SysBranchModel>?> LoadBranchLookup(string keyword)
    {
      return await SysBranchService.GetRowsForLookup(keyword, 0, 100) ?? [];
    }

    #endregion

    #region OnSubmit
    private async void OnSubmit()
    {
      Loading.Show();

      #region Insert
      if (ID == null)
      {
        var res = await SysEmployeeBranchService.Insert(row);

        if (res?.Data != null)
        {
          NavigationManager.NavigateTo($"/companyinformation/employee/{EmployeeID}/employeebranch/{res.Data.ID}", true);
        }
      }
      #endregion

      #region Update
      else
      {
        await SysEmployeeBranchService.UpdateByID(row);
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
