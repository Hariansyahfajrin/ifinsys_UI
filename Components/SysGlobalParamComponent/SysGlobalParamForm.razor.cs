using Data.Model;
using Data.Service;
using Microsoft.AspNetCore.Components;
using IFinancing360_UI.Components;

namespace IFinancing360_SYS_UI.Components.SysGlobalParamComponent
{
  public partial class SysGlobalParamForm
  {
    #region Service
    [Inject] SysGlobalParamService SysGlobalParamService { get; set; } = null!;
    #endregion

    #region Parameter
    [Parameter, EditorRequired] public string? ID { get; set; }
    #endregion

    #region Component Field
    #endregion

    #region Field
    public SysGlobalParamModel row = new();
    #endregion

    #region OnInitialized
    protected override async Task OnParametersSetAsync()
    {
      if (ID != null)
      {
        await GetRow();
      }
      else
      {
        row.IsEditable = 1;
      }
      await base.OnParametersSetAsync();
    }
    #endregion

    #region GetRow
    public async Task GetRow()
    {
      row = await SysGlobalParamService.GetRowByID(ID) ?? new();
      StateHasChanged();
    }
    #endregion

    #region ChangeEditable
    private async Task ChangeEditable()
    {
      if (ID != null)
      {
        Loading.Show();
        var res = await SysGlobalParamService.ChangeEditableStatus(row);

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
        var res = await SysGlobalParamService.Insert(row);

        if (res?.Data != null)
        {
          ID = res.Data.ID;
          NavigationManager.NavigateTo($"/controlpanel/globalparam/{ID}");
        }
      }
      #endregion

      #region Update
      else
      {
        await SysGlobalParamService.UpdateByID(row);
      }
      #endregion

      Loading.Close();
      StateHasChanged();
    }
    #endregion

    #region Back
    private void Back()
    {
      NavigationManager.NavigateTo("/controlpanel/globalparam");
    }
    #endregion
  }
}