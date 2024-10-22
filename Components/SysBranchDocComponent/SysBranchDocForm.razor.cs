using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysBranchDocComponent
{
	public partial class SysBranchDocForm
	{
		#region Service
		[Inject] SysBranchDocService SysBranchDocService { get; set; } = null!;
		[Inject] SysBranchService SysBranchService { get; set; } = null!;
		[Inject] SysGeneralSubcodeService SysGeneralSubcodeService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter, EditorRequired] public string? BranchID { get; set; }
		[Parameter, EditorRequired] public string? ID { get; set; }
		#endregion


		#region Component Ref
		SingleSelectLookup<SysGeneralSubcodeModel> docTypeLookup = new();
		#endregion

		#region Field
		public SysBranchDocModel row = new();
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
			row = await SysBranchDocService.GetRowByID(ID) ?? new();
			Loading.Close();
			StateHasChanged();
		}

		public async Task<List<SysGeneralSubcodeModel>?> LoadDocTypeLookup(string keyword)
		{
			return await SysGeneralSubcodeService.GetRowsForLookup(keyword, 0, 100, "BRD") ?? [];
		}
		private async void OnSubmit()
		{
			Loading.Show();

			if (ID != null)
			{
				await SysBranchDocService.UpdateByID(row);
			}
			else
			{
				var res = await SysBranchDocService.Insert(row);

				if (res?.Data != null)
				{
					NavigationManager.NavigateTo($"/companyinformation/branch/{BranchID}/branchdoc/{res.Data.ID}", true);
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
