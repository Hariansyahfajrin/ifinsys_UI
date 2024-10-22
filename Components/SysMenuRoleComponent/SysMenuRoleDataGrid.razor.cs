using Data.Model;
using Data.Service;
using Microsoft.AspNetCore.Components;
using IFinancing360_UI.Components;

namespace IFinancing360_SYS_UI.Components.SysMenuRoleComponent
{
  public partial class SysMenuRoleDataGrid
  {
    #region Service
    [Inject] SysMenuRoleService SysMenuRoleService { get; set; } = null!;
    #endregion

    #region Parameter
    [Parameter, EditorRequired] public string? MenuID { get; set; }
    #endregion

    #region Component Field
    DataGrid<SysMenuRoleModel> dataGrid = null!;
    #endregion

    #region Field
    public readonly Dictionary<string, string> roleAccess = new(){
            {"ACCESS","A"},
            {"CREATE/UPDATE/GENERATE/UPLOAD","C"},
            {"MATCHING/VALIDATE/EDITABLE","U"},
            {"DELETE","D"},
            {"POST/PROCEED/APPROVE","O"},
            {"CANCEL/REJECT","R"},
            {"PRINT/DOWNLOAD","P"},
        };
    #endregion

    protected async Task<List<SysMenuRoleModel>?> LoadData(string keyword)
    {
      return await SysMenuRoleService.GetRows(keyword, 0, 100, MenuID ?? "");
    }

    private void Add()
    {
      NavigationManager.NavigateTo($"/systemsetting/menu/{MenuID}/menurole/add");
    }

    private async void Delete()
    {
      if (!dataGrid.selectedData.Any())
      {
        await NoDataSelectedAlert();
        return;
      }

      bool? result = await Confirm();

      if (result == true && dataGrid != null)
      {
        Loading.Show();
        string[] IDList = dataGrid.selectedData.Select(row => row.ID ?? "").ToArray();

        await SysMenuRoleService.Delete(IDList.ToArray());

        dataGrid.selectedData.Clear();

        await dataGrid.Reload();

        Loading.Close();

        StateHasChanged();
      }
    }

  }
}