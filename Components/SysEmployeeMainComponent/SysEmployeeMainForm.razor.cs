using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysEmployeeMainComponent
{
  public partial class SysEmployeeMainForm
  {
    #region Service
    [Inject] SysEmployeeMainService SysEmployeeMainService { get; set; } = null!;
    [Inject] SysDepartmentService SysDepartmentService { get; set; } = null!;
    [Inject] SysProvinceService SysProvinceService { get; set; } = null!;
    [Inject] SysCityService SysCityService { get; set; } = null!;
    [Inject] SysZipCodeService SysZipCodeService { get; set; } = null!;
    [Inject] SysCompanyService SysCompanyService { get; set; } = null!;
    #endregion

    #region Parameter
    [Parameter, EditorRequired] public string? ID { get; set; }
    #endregion

    #region Component Field
    SingleSelectLookup<SysProvinceModel>? provinceLookup;
    SingleSelectLookup<SysEmployeeMainModel>? employeeLookup;
    SingleSelectLookup<SysCityModel>? cityLookup;
    SingleSelectLookup<SysZipCodeModel>? zipCodeLookup;
    SingleSelectLookup<SysDepartmentModel>? departmentLookup;
    #endregion

    #region Field
    public SysEmployeeMainModel row = new();
    public SysCompanyModel company = new();
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
        row.IsActive = 1;

        company = await SysCompanyService.GetRowByCode("COMP") ?? new();

        row.CompanyID = company.ID;
      }

      await base.OnInitializedAsync();
    }
    #endregion

    #region GetRow
    public async Task GetRow()
    {
      Loading.Show();
      row = await SysEmployeeMainService.GetRowByID(ID) ?? new();
      Loading.Close();
      StateHasChanged();
    }
    #endregion

    #region Load Data Lookup
    public async Task<List<SysDepartmentModel>?> LoadDepartmentLookup(string keyword)
    {
      return await SysDepartmentService.GetRowsForLookup(keyword, 0, 100) ?? [];
    }
    public async Task<List<SysEmployeeMainModel>?> LoadEmployeeMainLookup(string keyword)
    {
      return await SysEmployeeMainService.GetRowsForLookup(keyword, 0, 100) ?? [];
    }
    public async Task<List<SysProvinceModel>?> LoadProvinceLookup(string keyword)
    {
      return await SysProvinceService.GetRowsForLookup(keyword, 0, 100) ?? [];
    }
    public async Task<List<SysCityModel>?> LoadCityLookup(string keyword)
    {
      return await SysCityService.GetRowsForLookup(keyword, 0, 100, row.ProvinceID ?? "") ?? [];
    }
    public async Task<List<SysZipCodeModel>?> LoadZipCodeLookup(string keyword)
    {
      return await SysZipCodeService.GetRowsForLookup(keyword, 0, 100, row.ProvinceID, row.CityID) ?? [];
    }
    #endregion


    #region ChangeActive
    private async Task ChangeActive()
    {
      if (ID != null)
      {
        Loading.Show();
        var res = await SysEmployeeMainService.ChangeStatus(row);

        if (res != null)
        {
          await GetRow();
        }

        Loading.Close();
        StateHasChanged();
      }
    }
    #endregion

    #region OnSubmit
    private async void OnSubmit()
    {
      Loading.Show();

      #region Insert
      if (ID == null)
      {
        var res = await SysEmployeeMainService.Insert(row);

        if (res?.Data != null)
        {
          NavigationManager.NavigateTo($"/companyinformation/employee/{res.Data.ID}", true);
        }
      }
      #endregion

      #region Update
      else
      {
        await SysEmployeeMainService.Update(row);
      }
      #endregion

      Loading.Close();
      StateHasChanged();
    }
    #endregion

    #region Back
    private void Back()
    {
      NavigationManager.NavigateTo($"/companyinformation/employee");
    }
    #endregion
  }
}
