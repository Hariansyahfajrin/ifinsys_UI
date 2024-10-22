using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysRoleGroupComponent
{
	public partial class SysRoleGroupForm
	{
		#region Service
		[Inject] SysRoleGroupService SysRoleGroupService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter, EditorRequired] public string? ID { get; set; }
		#endregion

		#region Component Field
		#endregion

		#region Field
		public SysRoleGroupModel row = new();
		#endregion

		#region OnInitialized
		protected override async Task OnInitializedAsync()
		{
			if (ID != null)
			{
				await GetRow();
			}

			await base.OnInitializedAsync();
		}
		#endregion

		#region GetRow
		public async Task GetRow()
		{
			row = await SysRoleGroupService.GetRowByID(ID) ?? new();
			StateHasChanged();
		}
		#endregion

		#region OnSubmit
		private async void OnSubmit()
		{
			Loading.Show();

			#region Insert
			if (ID == null)
			{
				var res = await SysRoleGroupService.Insert(row);

				Loading.Close();

				if (res != null)
				{
					if (res.Data != null)
					{
						NavigationManager.NavigateTo($"/systemsecurity/grouprole/{res.Data.ID}", true);
					}
					Loading.Close();
					StateHasChanged();
				}
			}
			#endregion

			#region Update
			else
			{
				var res = await SysRoleGroupService.UpdateByID(row);

				if (res != null)
				{
				}
			}
			#endregion
			Loading.Close();
			StateHasChanged();
		}
		#endregion

		#region Back
		private void Back()
		{
			NavigationManager.NavigateTo("/systemsecurity/grouprole");
		}
		#endregion
	}
}
