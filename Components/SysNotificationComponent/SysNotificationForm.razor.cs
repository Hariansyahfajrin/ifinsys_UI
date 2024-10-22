using Data.Model;
using Data.Service;
using Microsoft.AspNetCore.Components;
using IFinancing360_UI.Components;

namespace IFinancing360_SYS_UI.Components.SysNotificationComponent
{
  public partial class SysNotificationForm
  {
    #region Service
    [Inject] SysNotificationService SysNotificationService { get; set; } = null!;
    #endregion

    #region Parameter
    [Parameter] public string? ID { get; set; }
    #endregion

    #region Component Field
    #endregion

    #region Field
    public SysNotificationModel row = new();
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
      }
      await base.OnInitializedAsync();
    }
    #endregion

    #region GetRow
    public async Task GetRow()
    {
      Loading.Show();
      row = await SysNotificationService.GetRowByID(ID) ?? new();

      Loading.Close();
      StateHasChanged();
    }
    #endregion

    #region ChangeActive
    private async Task ChangeActive()
    {
      if (ID != null)
      {
        Loading.Show();
        var res = await SysNotificationService.ChangeStatus(row);

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
        var res = await SysNotificationService.Insert(row);

        if (res?.Data != null)
        {
          NavigationManager.NavigateTo($"/systemsetting/notification/{res.Data.ID}", true);
        }
      }
      #endregion

      #region Update
      else
      {
        await SysNotificationService.UpdateByID(row);
      }
      #endregion
      Loading.Close();
      StateHasChanged();
    }
    #endregion

    #region Back
    private void Back()
    {
      NavigationManager.NavigateTo("/systemsetting/notification");
    }
    #endregion
  }
}