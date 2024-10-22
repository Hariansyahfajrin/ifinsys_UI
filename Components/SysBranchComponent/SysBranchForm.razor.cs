using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysBranchComponent
{
  public partial class SysBranchForm
  {
    [Inject] SysBranchService SysBranchService { get; set; } = null!;
    [Inject] SysRegionService SysRegionService { get; set; } = null!;
    [Inject] SysProvinceService SysProvinceService { get; set; } = null!;
    [Inject] SysCityService SysCityService { get; set; } = null!;
    [Inject] SysZipCodeService SysZipCodeService { get; set; } = null!;

    [Parameter, EditorRequired] public string? ID { get; set; }

    #region Component Ref
    SingleSelectLookup<SysProvinceModel>? provinceLookup;
    SingleSelectLookup<SysCityModel>? cityLookup;
    SingleSelectLookup<SysRegionModel>? regionLookup;
    SingleSelectLookup<SysZipCodeModel>? zipCodeLookup;

    #endregion

    #region Field
    public SysBranchModel row = new();
    public Dictionary<string, string> BranchTypes = new(){
      {"BRANCH", "BRANCH"},
      {"HEAD OFFICE", "HEAD OFFICE"}
    };

    #endregion

    protected override async Task OnInitializedAsync()
    {
      if (ID != null)
      {
        await GetRow();
      }
      else
      {
        row.IsActive = 1;
      }
      await base.OnInitializedAsync();
    }

    public async Task<List<SysRegionModel>?> LoadRegionLookup(string keyword)
    {
      return await SysRegionService.GetRowsForLookup(keyword, 0, 100) ?? [];
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

    public async Task GetRow()
    {
      Loading.Show();
      row = await SysBranchService.GetRowByID(ID) ?? new();
      Loading.Close();
      StateHasChanged();
    }
    private async Task ChangeActive()
    {
      if (ID != null)
      {
        Loading.Show();
        var res = await SysBranchService.ChangeStatus(row);

        if (res != null)
        {
          await GetRow();
        }

        Loading.Close();
        StateHasChanged();
      }
    }

    private async void OnSubmit()
    {
      Loading.Show();

      if (ID != null)
      {
        await SysBranchService.Update(row);
      }
      else
      {
        var res = await SysBranchService.Insert(row);

        Loading.Close();

        if (res?.Data != null)
        {
          NavigationManager.NavigateTo($"/companyinformation/branch/{res.Data.ID}", true);
        }
      }
      Loading.Close();
      StateHasChanged();
    }

    private void Back()
    {
      NavigationManager.NavigateTo("/companyinformation/branch");
    }
  }
}
