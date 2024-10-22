using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
	[Service]
	public class SysCurrencyRateService
	{
		private readonly IFINSYSClient _ifinsysClient;
		private readonly string _controller = "SysCurrencyRate";
		private readonly string _routeGetRows = "GetRows";
		private readonly string _routeGetRowByID = "GetRowByID";
		private readonly string _routeInsert = "Insert";
		private readonly string _routeUpdateByID = "UpdateByID";
		private readonly string _routeDeleteByID = "DeleteByID";
		private readonly string _routeChangeStatus = "ChangeStatus";

		public SysCurrencyRateService(IFINSYSClient ifinsysClient)
		{
			_ifinsysClient = ifinsysClient;
		}

		public async Task<List<SysCurrencyRateModel>?> GetRows(string? keyword, int offset, int limit, string? currencyID)
		{
			var res = await _ifinsysClient.GetRows<SysCurrencyRateModel>(_controller, _routeGetRows, new { keyword, offset, limit, currencyID });
			return res?.Data;
		}

		public async Task<SysCurrencyRateModel?> GetRowByID(string? id)
		{
			var res = await _ifinsysClient.GetRow<SysCurrencyRateModel>(_controller, _routeGetRowByID, id);
			return res?.Data;
		}

		public async Task<BodyResponse<BaseModel>?> Insert(SysCurrencyRateModel model)
		{
			var res = await _ifinsysClient.Post(_controller, _routeInsert, model);

			return res;
		}

		public async Task<BodyResponse<object>?> UpdateByID(SysCurrencyRateModel model)
		{
			var res = await _ifinsysClient.Put(_controller, _routeUpdateByID, model);
			return res;
		}
		public async Task<BodyResponse<object>?> DeleteByID(string?[] ID)
		{
			var res = await _ifinsysClient.Delete(_controller, _routeDeleteByID, ID);
			return res;
		}

		public async Task<BodyResponse<object>?> ChangeStatus(SysCurrencyRateModel model)
		{
			var res = await _ifinsysClient.Put(_controller, _routeChangeStatus, model);
			return res;
		}
	}
}