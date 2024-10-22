using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysUserMainComponent
{
	public partial class SysUserMainForm
	{
		#region Service
		[Inject] SysUserMainService SysUserMainService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter, EditorRequired] public string? ID { get; set; }
		#endregion

		#region Component Field
		#endregion

		#region Field
		public SysUserMainModel row = new();
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
			row = await SysUserMainService.GetRowByID(ID) ?? new();
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
				var res = await SysUserMainService.ChangeStatus(row);

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
				var res = await SysUserMainService.Insert(row);

				if (res?.Data != null)
				{
					NavigationManager.NavigateTo($"/commonmasterfile/publicholiday/{res.Data.ID}", true);
				}

			}
			#endregion

			#region Update
			else
			{
				await SysUserMainService.UpdateByID(row);
			}
			#endregion
			Loading.Close();
			StateHasChanged();
		}
		#endregion

		#region Back
		private void Back()
		{
			NavigationManager.NavigateTo("/systemsecurity/user");
		}
		#endregion
	}
}
