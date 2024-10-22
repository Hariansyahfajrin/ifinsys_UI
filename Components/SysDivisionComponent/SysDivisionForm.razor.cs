using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysDivisionComponent
{
  public partial class SysDivisionForm
  {
    [Inject] SysDivisionService SysDivisionService { get; set; } = null!;

    [Parameter] public string? ID { get; set; }
    public SysDivisionModel row = new();

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
      row = await SysDivisionService.GetRowByID(ID) ?? new();
      Loading.Close();
      StateHasChanged();
    }
    private async Task ChangeActive()
    {
      if (ID != null)
      {
        Loading.Show();
        var res = await SysDivisionService.ChangeStatus(row);

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
        await SysDivisionService.UpdateByID(row);
      }
      else
      {
        var res = await SysDivisionService.Insert(row);

        Loading.Close();

        if (res?.Data != null)
        {
          NavigationManager.NavigateTo($"/companyinformation/division/{res.Data.ID}", true);
        }
      }
      Loading.Close();
      StateHasChanged();
    }

    private void Back()
    {
      NavigationManager.NavigateTo("/companyinformation/division");
    }
  }
}
