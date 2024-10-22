using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysPositionComponent
{
  public partial class SysPositionForm
  {
    #region Service
    [Inject] SysPositionService SysPositionService { get; set; } = null!;
    #endregion

    #region Parameter
    [Parameter] public string? ID { get; set; }
    #endregion

    #region Component Field
    #endregion

    #region Field
    public SysPositionModel row = new();
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
        row = new SysPositionModel() { IsActive = 1 };
      }

      await base.OnInitializedAsync();
    }
    #endregion

    #region GetRow
    public async Task GetRow()
    {
      Loading.Show();
      row = await SysPositionService.GetRowByID(ID) ?? new();
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
        var res = await SysPositionService.ChangeStatus(row);

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
        var res = await SysPositionService.Insert(row);

        if (res?.Data != null)
        {
          NavigationManager.NavigateTo($"/companyinformation/position/{res.Data.ID}", true);
        }
      }
      #endregion

      #region Update
      else
      {
        await SysPositionService.Update(row);
      }
      #endregion

      Loading.Close();
      StateHasChanged();
    }
    #endregion

    #region Back
    private void Back()
    {
      NavigationManager.NavigateTo($"/companyinformation/position");
    }
    #endregion
  }
}
