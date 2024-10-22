using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysCurrencyRateComponent
{
	public partial class SysCurrencyRateForm
	{
		#region Service
		[Inject] SysCurrencyRateService SysCurrencyRateService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter, EditorRequired] public string? CurrencyID { get; set; }
		[Parameter, EditorRequired] public string? ID { get; set; }
		#endregion

		#region Component Field
		#endregion

		#region Field
		public SysCurrencyRateModel row = new();
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
				row.CurrencyID = CurrencyID;
			}

			await base.OnInitializedAsync();
		}
		#endregion

		#region GetRow
		public async Task GetRow()
		{
			Loading.Show();
			row = await SysCurrencyRateService.GetRowByID(ID) ?? new();
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
				var res = await SysCurrencyRateService.ChangeStatus(row);

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
				var res = await SysCurrencyRateService.Insert(row);

				if (res?.Data != null)
				{
					NavigationManager.NavigateTo($"/commonmasterfile/currency/{CurrencyID}/rate/{res.Data.ID}", true);
				}
			}
			#endregion

			#region Update
			else
			{
				await SysCurrencyRateService.UpdateByID(row);
			}
			#endregion
			Loading.Close();
			StateHasChanged();
		}
		#endregion

		#region Back
		private void Back()
		{
			NavigationManager.NavigateTo($"/commonmasterfile/currency/{CurrencyID}");
		}
		#endregion
	}
}
