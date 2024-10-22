using Data.Model;
using Data.Service;
using Microsoft.AspNetCore.Components;
using IFinancing360_UI.Components;

namespace IFinancing360_SYS_UI.Components.SysMenuComponent
{
  public partial class SysMenuForm
  {
    [Inject] SysMenuService SysMenuService { get; set; } = default!;
    [Inject] SysModuleService SysModuleService { get; set; } = default!;

    #region Parameter
    [Parameter, EditorRequired] public string? ID { get; set; }
    #endregion

    #region Component Field
    SingleSelectLookup<SysModuleModel> moduleLookup = null!;
    SingleSelectLookup<SysMenuModel> parentLookup = null!;
    #endregion

    #region Field
    public Dictionary<string, string> menuTypes = new(){
      {"Link", "Link"},
      {"Parent", "Parent"},
      {"Child", "Child"}
    };
    private SysMenuModel row = new();
    #endregion

    protected override async Task OnInitializedAsync()
    {
      if (ID != null)
      {
        await GetRow();
      }
      else
      {
        row = new SysMenuModel { IsActive = 1 };
      }

      await base.OnInitializedAsync();
    }

    protected async Task GetRow()
    {
      Loading.Show();
      row = await SysMenuService.GetRowByID(ID) ?? new();

      Loading.Close();
      StateHasChanged();
    }

    protected async Task<List<SysModuleModel>?> LoadModuleLookup(string keyword)
    {
      return await SysModuleService.GetRowsForLookupModule(keyword, 0, 100);
    }
    protected async Task<List<SysMenuModel>?> LoadParentLookup(string keyword)
    {
      return await SysMenuService.GetRowsForLookupParent(keyword, 0, 100, row.ModuleID ?? "");
    }

    private async Task ChangeActive()
    {
      if (ID != null)
      {
        Loading.Show();
        var res = await SysMenuService.ChangeStatus(row);

        if (res != null)
        {
          await GetRow();
        }

        Loading.Close();
        StateHasChanged();

      }
    }

    private async void OnSubmit()
    {
      Loading.Show();

      if (ID != null)
      {
        var res = await SysMenuService.Update(row);

        Loading.Close();
        StateHasChanged();
      }
      else
      {
        var res = await SysMenuService.Insert(row);

        if (res?.Data != null)
        {
          NavigationManager.NavigateTo($"/systemsetting/menu/{res.Data.ID}", true);
        }

        Loading.Close();
        StateHasChanged();
      }
    }

    private void Back()
    {
      NavigationManager.NavigateTo("/systemsetting/menu");
    }
  }
}