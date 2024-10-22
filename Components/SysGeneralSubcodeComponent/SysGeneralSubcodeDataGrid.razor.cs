using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysGeneralSubcodeComponent
{
  public partial class SysGeneralSubcodeDataGrid
  {
    #region Service
    [Inject] SysGeneralSubcodeService SysGeneralSubcodeService { get; set; } = null!;
    #endregion

    #region Parameter
    [Parameter, EditorRequired] public string? GeneralCodeID { get; set; }
    [Parameter] public SysGeneralCodeModel? GeneralCode { get; set; } = new();
    #endregion

    #region Component Field
    DataGrid<SysGeneralSubcodeModel> dataGrid = null!;
    #endregion

    #region Field
    public bool IsReadonly
    {
      get
      {
        return GeneralCode?.IsEditable == -1;
      }
    }
    #endregion

    #region LoadData
    protected async Task<List<SysGeneralSubcodeModel>?> LoadData(string keyword)
    {
      return await SysGeneralSubcodeService.GetRows(keyword, 0, 100, GeneralCodeID ?? "");
    }
    #endregion

    #region Add
    private void Add()
    {
      NavigationManager.NavigateTo($"/systemsetting/generalcode/{GeneralCodeID}/generalsubcode/add");
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

        await SysGeneralSubcodeService.DeleteByID(dataGrid.selectedData.Select(row => row.ID).ToArray());

        await dataGrid.Reload();
        dataGrid.selectedData.Clear();

        Loading.Close();

        StateHasChanged();
      }
    }
    #endregion
  }
}
