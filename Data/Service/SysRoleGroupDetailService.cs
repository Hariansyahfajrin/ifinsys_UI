using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
	[Service]
	public class SysRoleGroupDetailService
	{
		private readonly IFINSYSClient _ifinsysClient;
		private readonly string _controller = "SysRoleGroupDetail";
		private readonly string _routeGetRows = "GetRows";
		private readonly string _routeGetRowByID = "GetRowByID";
		private readonly string _routeInsert = "Insert";
		private readonly string _routeUpdateByID = "UpdateByID";
		private readonly string _routeDeleteByID = "DeleteByID";

		public SysRoleGroupDetailService(IFINSYSClient ifinsysClient)
		{
			_ifinsysClient = ifinsysClient;
		}

		public async Task<List<SysRoleGroupDetailModel>?> GetRows(string? keyword, int offset, int limit, string? roleGroupID, string? roleAccess, string? menuID, string? subMenuID, string? moduleID)
		{
			var res = await _ifinsysClient.GetRows<SysRoleGroupDetailModel>(_controller, _routeGetRows, new { keyword, offset, limit, roleGroupID, roleAccess, menuID, subMenuID, moduleID });
			return res?.Data;
		}

		public async Task<SysRoleGroupDetailModel?> GetRowByID(string? id)
		{
			var res = await _ifinsysClient.GetRow<SysRoleGroupDetailModel>(_controller, _routeGetRowByID, id);
			return res?.Data;
		}

		public async Task<BodyResponse<BaseModel>?> Insert(List<SysRoleGroupDetailModel> model)
		{
			var res = await _ifinsysClient.Post(_controller, _routeInsert, model);

			return res;
		}

		public async Task<BodyResponse<object>?> UpdateByID(SysRoleGroupDetailModel model)
		{
			var res = await _ifinsysClient.Put(_controller, _routeUpdateByID, model);
			return res;
		}
		public async Task<BodyResponse<object>?> DeleteByID(string?[] ID)
		{
			var res = await _ifinsysClient.Delete(_controller, _routeDeleteByID, ID);
			return res;
		}
	}
}