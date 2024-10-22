using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysBranchComponent
{
  public partial class SysBranchDataGrid
  {
    #region Service
    [Inject] SysBranchService SysBranchService { get; set; } = null!;
    #endregion

    #region Component Field
    DataGrid<SysBranchModel> dataGrid = null!;
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
    protected async Task<List<SysBranchModel>?> LoadData(string keyword)
    {
      return await SysBranchService.GetRows(keyword, 0, 100);
    }
    #endregion

    #region Add
    private void Add()
    {
      NavigationManager.NavigateTo("/companyinformation/branch/add");
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

        await SysBranchService.Delete(selectedData.Select(row => row.ID ?? "").ToArray());

        await dataGrid.Reload();
        dataGrid.selectedData.Clear();

        Loading.Close();

        StateHasChanged();
      }
    }
    #endregion
  }
}
