using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysGeneralSubcodeComponent
{
  public partial class SysGeneralSubcodeForm
  {
    #region Service
    [Inject] SysGeneralCodeService SysGeneralCodeService { get; set; } = null!;
    [Inject] SysGeneralSubcodeService SysGeneralSubcodeService { get; set; } = null!;
    #endregion

    #region Parameter
    [Parameter, EditorRequired] public string? ID { get; set; }
    [Parameter, EditorRequired] public string? GeneralCodeID { get; set; }
    #endregion

    #region Component Field
    #endregion

    #region Field
    public SysGeneralSubcodeModel row = new();
    public SysGeneralCodeModel rowGeneralCode = new();
    public bool IsReadonly
    {
      get
      {
        return rowGeneralCode?.IsEditable == -1;
      }
    }
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
        row.GeneralCodeID = GeneralCodeID;
      }

      await GetRowGeneralCode();
      await base.OnInitializedAsync();
    }
    #endregion

    #region GetRowGeneralCode
    public async Task GetRowGeneralCode()
    {
      Loading.Show();

      rowGeneralCode = await SysGeneralCodeService.GetRowByID(GeneralCodeID) ?? new();
      StateHasChanged();

      Loading.Close();
    }

    #endregion

    #region GetRow
    public async Task GetRow()
    {
      Loading.Show();

      row = await SysGeneralSubcodeService.GetRowByID(ID) ?? new();
      StateHasChanged();

      Loading.Close();
    }
    #endregion

    #region ChangeActive
    private async Task ChangeActive()
    {
      if (ID != null)
      {
        Loading.Show();
        var res = await SysGeneralSubcodeService.ChangeStatus(row);

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
        var res = await SysGeneralSubcodeService.Insert(row);

        if (res?.Data != null)
        {
          NavigationManager.NavigateTo($"/systemsetting/generalcode/{GeneralCodeID}/generalsubcode/{res.Data.ID}", true);
        }
      }
      #endregion

      #region Update
      else
      {
        var res = await SysGeneralSubcodeService.UpdateByID(row);
      }
      #endregion

      Loading.Close();
      StateHasChanged();
    }
    #endregion

    #region Back
    private void Back()
    {
      NavigationManager.NavigateTo($"/systemsetting/generalcode/{GeneralCodeID}");
    }
    #endregion
  }
}
