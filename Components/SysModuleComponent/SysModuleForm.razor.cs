using Data.Model;
using Data.Service;
using Microsoft.AspNetCore.Components;
using IFinancing360_UI.Components;

namespace IFinancing360_SYS_UI.Components.SysModuleComponent
{
  public partial class SysModuleForm
  {
    #region Service
    [Inject] SysModuleService SysModuleService { get; set; } = null!;
    #endregion

    #region Parameter
    [Parameter, EditorRequired] public string? ID { get; set; }
    #endregion

    #region Field
    public SysModuleModel row = new();
    #endregion

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

    public async Task GetRow()
    {
      Loading.Show();
      row = await SysModuleService.GetRowByID(ID) ?? new();

      Loading.Close();
      StateHasChanged();
    }
    private async Task ChangeActive()
    {
      if (ID != null)
      {
        Loading.Show();
        var res = await SysModuleService.ChangeStatus(row);

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
        await SysModuleService.Update(row);
      }
      else
      {
        var res = await SysModuleService.Insert(row);

        if (res?.Data != null)
        {
          NavigationManager.NavigateTo($"/systemsetting/module/{res.Data.ID}", true);
        }
      }

      Loading.Close();
      StateHasChanged();
    }

    private void Back()
    {
      NavigationManager.NavigateTo("/systemsetting/module");
    }
  }
}