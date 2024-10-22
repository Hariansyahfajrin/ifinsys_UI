using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysBranchLoginComponent
{
	public partial class SysBranchLoginForm
	{
		#region Service
		[Inject] SysBranchLoginService SysBranchLoginService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter] public string? BranchID { get; set; }
		#endregion


		#region Component Ref
		#endregion

		#region Field
		public SysBranchLoginModel row = new();
		#endregion

		protected override async Task OnInitializedAsync()
		{
			await GetRow();

			await base.OnInitializedAsync();
		}

		public async Task GetRow()
		{
			row = await SysBranchLoginService.GetRowByBranch(BranchID) ?? new();
			StateHasChanged();
		}

		private async void OnSubmit()
		{
			Loading.Show();

			await SysBranchLoginService.UpdateByID(row);

			Loading.Close();
			StateHasChanged();
		}
	}
}
