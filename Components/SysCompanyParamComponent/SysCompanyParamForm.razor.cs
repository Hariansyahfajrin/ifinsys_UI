using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysCompanyParamComponent
{
  public partial class SysCompanyParamForm
  {
    #region Service
    [Inject] SysCompanyParamService SysCompanyParamService { get; set; } = null!;
    #endregion

    #region Parameter
    [Parameter] public string? ID { get; set; }
    [Parameter] public string? CompanyID { get; set; }
    #endregion

    #region Component Field
    #endregion

    #region Field
    public SysCompanyParamModel row = new();
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
        row = new SysCompanyParamModel();
      }

      row.CompanyID = CompanyID;
      await base.OnInitializedAsync();
    }
    #endregion

    #region GetRow
    public async Task GetRow()
    {
      row = await SysCompanyParamService.GetRowByID(ID) ?? new();
      StateHasChanged();
    }
    #endregion

    #region OnSubmit
    private async void OnSubmit()
    {
      Loading.Show();

      #region Insert
      if (ID == null)
      {
        var res = await SysCompanyParamService.Insert(row);

        Loading.Close();

        if (res != null)
        {
          if (res.Data != null)
          {
            NavigationManager.NavigateTo($"/companyinformation/company/{CompanyID}/companyparam/{res.Data.ID}", true);
          }
          Loading.Close();
          StateHasChanged();
        }
      }
      #endregion

      #region Update
      else
      {
        var res = await SysCompanyParamService.UpdateByID(row);

        if (res != null)
        {
          Loading.Close();
        }
        StateHasChanged();
      }
      #endregion
    }
    #endregion

    #region Back
    private void Back()
    {
      NavigationManager.NavigateTo($"/companyinformation/company/");
    }
    #endregion
  }
}
