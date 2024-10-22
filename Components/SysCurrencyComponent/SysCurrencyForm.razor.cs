using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysCurrencyComponent
{
	public partial class SysCurrencyForm
	{
		#region Service
		[Inject] SysCurrencyService SysCurrencyService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter] public string? ID { get; set; }
		#endregion

		#region Component Field
		#endregion

		#region Field
		public SysCurrencyModel row = new();
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
				row.IsActive = 1;
			}
			await base.OnInitializedAsync();
		}
		#endregion

		#region GetRow
		public async Task GetRow()
		{
			Loading.Show();
			row = await SysCurrencyService.GetRowByID(ID) ?? new();
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
				var res = await SysCurrencyService.ChangeStatus(row);

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
				var res = await SysCurrencyService.Insert(row);

				if (res?.Data != null)
				{
					NavigationManager.NavigateTo($"/commonmasterfile/currency/{res.Data.ID}", true);
				}
			}
			#endregion

			#region Update
			else
			{
				await SysCurrencyService.UpdateByID(row);
			}
			#endregion
			Loading.Close();
			StateHasChanged();
		}
		#endregion

		#region Back
		private void Back()
		{
			NavigationManager.NavigateTo("/commonmasterfile/currency");
		}
		#endregion
	}
}
