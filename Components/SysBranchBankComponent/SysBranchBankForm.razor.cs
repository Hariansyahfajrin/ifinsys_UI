using System.Runtime.CompilerServices;
using System.Text.Json;
using Data.Model;
using Data.Service;
using Helper;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysBranchBankComponent
{
  public partial class SysBranchBankForm
  {
    #region Service
    [Inject] SysBranchBankService SysBranchBankService { get; set; } = null!;
    [Inject] SysBranchService SysBranchService { get; set; } = null!;
    [Inject] SysBankService SysBankService { get; set; } = null!;
    [Inject] SysEmployeeMainService SysEmployeeMainService { get; set; } = null!;
    [Inject] SysCurrencyService SysCurrencyService { get; set; } = null!;
    [Inject] JournalGLLinkService JournalGLLinkService { get; set; } = null!;
    #endregion

    #region Parameter
    [Parameter, EditorRequired] public string? BranchID { get; set; }
    [Parameter, EditorRequired] public string? ID { get; set; }
    #endregion


    #region Component Ref
    SingleSelectLookup<SysBankModel> bankLookup = null!;
    SingleSelectLookup<SysEmployeeMainModel> employeeLookup = null!;
    SingleSelectLookup<SysCurrencyModel> currencyLookup = null!;
    SingleSelectLookup<JournalGLLinkModel> glLinkLookup = null!;
    #endregion

    #region Field
    public SysBranchBankModel row = new();
    public SysBranchModel branchRow = new();

    private Dictionary<string, string> typesDdl = new(){
      {"KONVENSIONAL", "KONVENSIONAL"},
      {"SYARIAH", "SYARIAH"}
    };
    private Dictionary<string, string> flagTypesDdl = new(){
      {"BANK", "B"},
      {"CASH", "C"},
      {"OPEX", "O"}
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
        row = new()
        {
          BranchID = BranchID,
          IsActive = 1
        };
      }

      branchRow = await SysBranchService.GetRowByID(BranchID) ?? new();
      await base.OnInitializedAsync();
    }
    public async Task GetRow()
    {
      Loading.Show();
      row = await SysBranchBankService.GetRowByID(ID) ?? new();
      Loading.Close();
      StateHasChanged();
    }

    protected async Task<List<SysBankModel>?> LoadBankLookup(string keyword)
    {
      return await SysBankService.GetRowsForLookup(keyword, 0, 100);
    }
    public async Task<List<SysEmployeeMainModel>?> LoadEmployeeMainLookup(string keyword)
    {
      return await SysEmployeeMainService.GetRowsForLookup(keyword, 0, 100) ?? [];
    }
    public async Task<List<SysCurrencyModel>?> LoadCurrencyLookup(string keyword)
    {
      return await SysCurrencyService.GetRowsForLookup(keyword, 0, 100) ?? [];
    }
    public async Task<List<JournalGLLinkModel>?> LoadGLLinkLookup(string keyword)
    {
      return await JournalGLLinkService.GetRowsForLookup(keyword, 0, 100) ?? [];
    }

    private async void OnSubmit()
    {
      Loading.Show();

      if (ID != null)
      {
        await SysBranchBankService.UpdateByID(row);
      }
      else
      {
        var res = await SysBranchBankService.Insert(row);

        if (res?.Data != null)
        {
          NavigationManager.NavigateTo($"/companyinformation/branch/{BranchID}/branchbank/{res.Data.ID}", true);
        }
      }
      Loading.Close();
      StateHasChanged();
    }

    #region ChangeActive
    private async Task ChangeActive()
    {
      if (ID != null)
      {
        Loading.Show();
        var res = await SysBranchBankService.ChangeStatus(row);

        if (res != null)
        {
          await GetRow();
        }

        Loading.Close();
        StateHasChanged();
      }
    }
    #endregion

    #region Upload
    async Task Upload(FileRequest file)
    {
      row.FileBytes = file.Bytes;
      row.FileName = row.Code + Path.GetExtension(file.Name);
      row.Paths = Path.Combine("SysBranchBank", row.Code ?? "");
      await SysBranchBankService.Upload(row);
    }
    #endregion

    #region Preview
    async Task<FileRequest> Preview()
    {
      Loading.Show();
      var model = await SysBranchBankService.Preview(ID);

      Loading.Close();
      return new()
      {
        Name = model?.FileName,
        Path = model?.Paths,
        Bytes = model?.FileBytes
      };
    }
    #endregion

    #region DeleteFile
    async Task DeleteFile()
    {
      Loading.Show();
      await SysBranchBankService.DeleteFile(row);
      await GetRow();
      Loading.Close();
    }
    #endregion
    private void Back()
    {
      NavigationManager.NavigateTo($"/companyinformation/branch/{BranchID}");
    }
  }
}
