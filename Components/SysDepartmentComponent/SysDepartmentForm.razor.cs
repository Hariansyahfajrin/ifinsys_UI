using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysDepartmentComponent
{
  public partial class SysDepartmentForm
  {
    [Inject] SysDepartmentService SysDepartmentService { get; set; } = null!;
    [Inject] SysDivisionService SysDivisionService { get; set; } = null!;

    [Parameter]
    public string? ID { get; set; }
    SingleSelectLookup<SysDivisionModel>? divisionLookup;
    public SysDepartmentModel row = new();

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

    public async Task<List<SysDivisionModel>?> LoadDivisionLookup(string keyword)
    {
      return await SysDivisionService.GetRowsForLookup(keyword, 0, 100) ?? [];
    }

    public async Task GetRow()
    {
      Loading.Show();
      row = await SysDepartmentService.GetRowByID(ID) ?? new();
      Loading.Close();
      StateHasChanged();
    }
    private async Task ChangeActive()
    {
      if (ID != null)
      {
        Loading.Show();
        var res = await SysDepartmentService.ChangeStatus(row);

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
        await SysDepartmentService.Update(row);
      }
      else
      {
        var res = await SysDepartmentService.Insert(row);

        Loading.Close();

        if (res?.Data != null)
        {
          NavigationManager.NavigateTo($"/companyinformation/department/{res.Data.ID}", true);
        }

      }
      Loading.Close();
      StateHasChanged();
    }

    private void Back()
    {
      NavigationManager.NavigateTo("/companyinformation/department");
    }
  }
}
