using Data.Model;
using Data.Service;
using Microsoft.AspNetCore.Components;
using IFinancing360_UI.Components;

namespace IFinancing360_SYS_UI.Components.SysMenuRoleComponent
{
  public partial class SysMenuRoleForm
  {
    #region Service
    [Inject] SysMenuRoleService SysMenuRoleService { get; set; } = null!;
    [Inject] SysMenuService SysMenuService { get; set; } = default!;
    #endregion

    #region Parameter
    [Parameter, EditorRequired] public string? ID { get; set; }
    [Parameter, EditorRequired] public string? MenuID { get; set; }
    #endregion

    #region Field
    SysMenuRoleModel row = new();
    SysMenuModel rowMenu = new();
    readonly Dictionary<string, string> roleAccess = new(){
            {"ACCESS","A"},
            {"CREATE/UPDATE/GENERATE/UPLOAD","C"},
            {"MATCHING/VALIDATE/EDITABLE","U"},
            {"DELETE","D"},
            {"POST/PROCEED/APPROVE","O"},
            {"CANCEL/REJECT","R"},
            {"PRINT/DOWNLOAD","P"},
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
        row = new SysMenuRoleModel { MenuID = MenuID };
      }

      rowMenu = await SysMenuService.GetRowByID(MenuID) ?? new();
    }

    private async Task GetRow()
    {
      row = await SysMenuRoleService.GetRowByID(ID) ?? new();
    }

    private async void OnSubmit()
    {
      Loading.Show();

      if (ID != null)
      {
        var res = await SysMenuRoleService.Update(row);
      }
      else
      {
        var res = await SysMenuRoleService.Insert(row);

        if (res?.Data != null)
        {
          NavigationManager.NavigateTo($"/systemsetting/menu/{MenuID}/menurole/{res.Data.ID}", true);
        }
      }

      Loading.Close();
      StateHasChanged();
    }

    private void Back()
    {
      NavigationManager.NavigateTo($"/systemsetting/menu/{MenuID}");
    }
  }
}