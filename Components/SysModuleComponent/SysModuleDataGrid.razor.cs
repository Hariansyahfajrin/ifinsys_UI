using Data.Model;
using Data.Service;
using Microsoft.AspNetCore.Components;
using IFinancing360_UI.Components;

namespace IFinancing360_SYS_UI.Components.SysModuleComponent
{
  public partial class SysModuleDataGrid
  {
    #region Service
    [Inject] SysModuleService SysModuleService { get; set; } = null!;
    #endregion

    #region Component Field
    DataGrid<SysModuleModel> dataGrid = null!;
    #endregion
    protected async Task<List<SysModuleModel>?> LoadData(string keyword)
    {
      return await SysModuleService.GetRows(keyword, 0, 100);
    }

    private void Add()
    {
      NavigationManager.NavigateTo("/systemsetting/module/add");
    }

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

        await SysModuleService.Delete(selectedData.Select(row => row.ID ?? "").ToArray());

        await dataGrid.Reload();
        dataGrid.selectedData.Clear();

        Loading.Close();

        StateHasChanged();
      }
    }
  }
}