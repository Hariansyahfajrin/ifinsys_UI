using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
	[Service]
	public class SysDepartmentService
	{
		private readonly IFINSYSClient _ifinsysClient;
		private readonly string _controller = "SysDepartment";
		private readonly string _routeGetRows = "GetRows";
		private readonly string _routeGetRowsForLookup = "GetRowsForLookup";
		private readonly string _routeGetRow = "GetRowByID";
		private readonly string _routeInsert = "Insert";
		private readonly string _routeUpdate = "UpdateByID";
		private readonly string _routeDeleteByID = "DeleteByID";
		private readonly string _routeChangeStatus = "ChangeStatus";

		public SysDepartmentService(IFINSYSClient ifinsysClient)
		{
			_ifinsysClient = ifinsysClient;
		}

		public async Task<List<SysDepartmentModel>?> GetRows(string? keyword, int offset, int limit)
		{
			var res = await _ifinsysClient.GetRows<SysDepartmentModel>(_controller, _routeGetRows, new { keyword, offset, limit });
			return res?.Data;
		}
		public async Task<List<SysDepartmentModel>?> GetRowsForLookup(string? keyword, int offset, int limit, bool WithAll = false)
		{
			var res = await _ifinsysClient.GetRows<SysDepartmentModel>(_controller, _routeGetRowsForLookup, new { keyword, offset, limit, WithAll = WithAll.ToString() });
			return res?.Data;
		}

		public async Task<SysDepartmentModel?> GetRowByID(string? id)
		{
			var res = await _ifinsysClient.GetRow<SysDepartmentModel>(_controller, _routeGetRow, id);
			return res?.Data;
		}

		public async Task<BodyResponse<BaseModel>?> Insert(SysDepartmentModel model)
		{
			var res = await _ifinsysClient.Post(_controller, _routeInsert, model);

			return res;
		}

		public async Task<BodyResponse<object>?> Update(SysDepartmentModel model)
		{
			var res = await _ifinsysClient.Put(_controller, _routeUpdate, model);
			return res;
		}
		public async Task<BodyResponse<object>?> DeleteByID(string?[] ID)
		{
			var res = await _ifinsysClient.Delete(_controller, _routeDeleteByID, ID);
			return res;
		}

		public async Task<BodyResponse<object>?> ChangeStatus(SysDepartmentModel model)
		{
			var res = await _ifinsysClient.Put(_controller, _routeChangeStatus, model);
			return res;
		}
	}
}