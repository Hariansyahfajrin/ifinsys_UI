using Data.Model;
using Data.Service;
using Microsoft.AspNetCore.Components;
using IFinancing360_UI.Components;

namespace IFinancing360_SYS_UI.Components.SysNotificationComponent
{
  public partial class SysNotificationDataGrid
  {
    #region Service
    [Inject] SysNotificationService SysNotificationService { get; set; } = null!;
    #endregion

    #region Component Field
    DataGrid<SysNotificationModel> dataGrid = null!;
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
    protected async Task<List<SysNotificationModel>?> LoadData(string keyword)
    {
      return await SysNotificationService.GetRows(keyword, 0, 100);
    }
    #endregion

    #region Add
    private void Add()
    {
      NavigationManager.NavigateTo($"/systemsetting/notification/add");
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

        await SysNotificationService.DeleteByID(dataGrid.selectedData.Select(row => row.ID).ToArray());

        await dataGrid.Reload();
        dataGrid.selectedData.Clear();

        Loading.Close();

        StateHasChanged();
      }
    }
    #endregion
  }
}