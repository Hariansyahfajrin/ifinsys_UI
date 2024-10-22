using Data.Model;
using Data.Service;
using IFinancing360_UI.Components;
using Microsoft.AspNetCore.Components;

namespace IFinancing360_SYS_UI.Components.SysUserLoginLogComponent
{
	public partial class SysUserLoginLogDataGrid
	{
		#region Service
		[Inject] SysUserLoginLogService SysUserLoginLogService { get; set; } = null!;
		#endregion

		#region Parameter
		[Parameter, EditorRequired] public string? UserID { get; set; }
		#endregion

		#region Component Field
		DataGrid<SysUserLoginLogModel> dataGrid = null!;
		#endregion

		#region Field
		public Dictionary<string, DateTime?> filters = new(){
			{"FromDate", DateTime.Now.AddMonths(-1)},
			{"ToDate", DateTime.Now}
		};
		#endregion

		#region OnInitialized
		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
		}
		#endregion

		#region LoadData
		protected async Task<List<SysUserLoginLogModel>?> LoadData(string keyword)
		{
			Console.WriteLine($"UserID: {UserID}");
			return await SysUserLoginLogService.GetRows(keyword, 0, 100, UserID, filters["FromDate"], filters["ToDate"]);
		}
		#endregion

		#region Delete
		private async void Delete()
		{
			var selectedData = dataGrid.selectedData;

			if (!selectedData.Any())
			{
				await NoDataSelectedAlert();
				return;
			}

			bool? result = await Confirm();

			if (result == true)
			{
				Loading.Show();

				await SysUserLoginLogService.DeleteByID(dataGrid.selectedData.Select(row => row.ID).ToArray());

				await dataGrid.Reload();
				dataGrid.selectedData.Clear();

				Loading.Close();

				StateHasChanged();
			}
		}
		#endregion
	}
}
