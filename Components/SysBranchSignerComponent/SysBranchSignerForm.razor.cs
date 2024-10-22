using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysBranchSignerComponent
{
	public partial class SysBranchSignerForm
	{
		#region Service
		[Inject] SysBranchSignerService SysBranchSignerService { get; set; } = null!;
		[Inject] SysBranchService SysBranchService { get; set; } = null!;
		[Inject] SysGeneralSubcodeService SysGeneralSubcodeService { get; set; } = null!;
		[Inject] SysEmployeeMainService SysEmployeeMainService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter, EditorRequired] public string? BranchID { get; set; }
		[Parameter, EditorRequired] public string? ID { get; set; }
		#endregion


		#region Component Ref
		SingleSelectLookup<SysGeneralSubcodeModel> signerTypeLookup = new();
		SingleSelectLookup<SysEmployeeMainModel> employeeLookup = new();
		#endregion

		#region Field
		public SysBranchSignerModel row = new();
		public SysBranchModel branchRow = new();
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
					BranchID = BranchID
				};
			}

			branchRow = await SysBranchService.GetRowByID(BranchID) ?? new();
			await base.OnInitializedAsync();
		}
		public async Task GetRow()
		{
			Loading.Show();
			row = await SysBranchSignerService.GetRowByID(ID) ?? new();
			Loading.Close();
			StateHasChanged();
		}

		#region Load Lookup
		public async Task<List<SysGeneralSubcodeModel>?> LoadSignerTypeLookup(string keyword)
		{
			return await SysGeneralSubcodeService.GetRowsForLookup(keyword, 0, 100, "BST") ?? [];
		}
		public async Task<List<SysEmployeeMainModel>?> LoadEmployeeMainLookup(string keyword)
		{
			return await SysEmployeeMainService.GetRowsForLookup(keyword, 0, 100) ?? [];
		}
		#endregion

		private async void OnSubmit()
		{
			Loading.Show();

			if (ID != null)
			{
				await SysBranchSignerService.UpdateByID(row);
			}
			else
			{
				var res = await SysBranchSignerService.Insert(row);

				if (res?.Data != null)
				{
					NavigationManager.NavigateTo($"/companyinformation/branch/{BranchID}/branchsigner/{res.Data.ID}", true);
				}
			}
			Loading.Close();
			StateHasChanged();
		}

		private void Back()
		{
			NavigationManager.NavigateTo($"/companyinformation/branch/{BranchID}");
		}
	}
}
