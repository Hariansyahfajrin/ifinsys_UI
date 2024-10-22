using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysCompanyComponent
{
	public partial class SysCompanyForm
	{
		#region Service
		[Inject] SysCompanyService SysCompanyService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter] public EventCallback<string?> IDChanged { get; set; }
		#endregion

		#region Component Field
		#endregion

		#region Field
		public SysCompanyModel row = new();
		#endregion

		#region OnInitialized
		protected override async Task OnInitializedAsync()
		{
			await GetRow();
			await base.OnInitializedAsync();
		}
		#endregion

		#region GetRow
		public async Task GetRow()
		{
			Loading.Show();

			row = await SysCompanyService.GetRowByCode("COMP") ?? new();

			await IDChanged.InvokeAsync(row.ID);

			Loading.Close();
			StateHasChanged();
		}
		#endregion

		#region OnSubmit
		private async void OnSubmit()
		{
			Loading.Show();

			#region Update
			await SysCompanyService.UpdateByID(row);

			Loading.Close();
			StateHasChanged();

			#endregion
		}
		#endregion
	}
}
