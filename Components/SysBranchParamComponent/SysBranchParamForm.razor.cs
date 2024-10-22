using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysBranchParamComponent
{
	public partial class SysBranchParamForm
	{
		#region Service
		[Inject] SysBranchParamService SysBranchParamService { get; set; } = null!;
		[Inject] SysBranchService SysBranchService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter, EditorRequired] public string? BranchID { get; set; }
		[Parameter, EditorRequired] public string? ID { get; set; }
		#endregion


		#region Component Ref
		#endregion

		#region Field
		public SysBranchParamModel row = new();
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
			row = await SysBranchParamService.GetRowByID(ID) ?? new();
			Loading.Close();
			StateHasChanged();
		}

		private async void OnSubmit()
		{
			Loading.Show();

			if (ID != null)
			{
				await SysBranchParamService.UpdateByID(row);
			}
			else
			{
				var res = await SysBranchParamService.Insert(row);

				if (res?.Data != null)
				{
					NavigationManager.NavigateTo($"/companyinformation/branch/{BranchID}/branchparam/{res.Data.ID}", true);
				}
				Loading.Close();
				StateHasChanged();
			}
		}

		private void Back()
		{
			NavigationManager.NavigateTo($"/companyinformation/branch/{BranchID}");
		}
	}
}
