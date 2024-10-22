using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
	[Service]
	public class SysCompanyParamService
	{
		private readonly IFINSYSClient _ifinsysClient;
		private readonly string _controller = "SysCompanyParam";
		private readonly string _routeGetRows = "GetRows";
		private readonly string _routeGetRowByID = "GetRowByID";
		private readonly string _routeInsert = "Insert";
		private readonly string _routeUpdateByID = "UpdateByID";
		private readonly string _routeDeleteByID = "DeleteByID";

		public SysCompanyParamService(IFINSYSClient ifinsysClient)
		{
			_ifinsysClient = ifinsysClient;
		}

		public async Task<List<SysCompanyParamModel>?> GetRows(string? keyword, int offset, int limit)
		{
			var res = await _ifinsysClient.GetRows<SysCompanyParamModel>(_controller, _routeGetRows, new { keyword, offset, limit });
			return res?.Data;
		}
		public async Task<SysCompanyParamModel?> GetRowByID(string? id)
		{
			var res = await _ifinsysClient.GetRow<SysCompanyParamModel>(_controller, _routeGetRowByID, id);
			return res?.Data;
		}

		public async Task<BodyResponse<BaseModel>?> Insert(SysCompanyParamModel model)
		{
			var res = await _ifinsysClient.Post(_controller, _routeInsert, model);

			return res;
		}

		public async Task<BodyResponse<object>?> UpdateByID(SysCompanyParamModel model)
		{
			var res = await _ifinsysClient.Put(_controller, _routeUpdateByID, model);
			return res;
		}
		public async Task<BodyResponse<object>?> DeleteByID(string[] ID)
		{
			var res = await _ifinsysClient.Delete(_controller, _routeDeleteByID, ID);
			return res;
		}
	}
}