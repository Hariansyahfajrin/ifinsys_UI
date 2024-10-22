using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
  [Service]
  public class SysCurrencyService
  {
    private readonly IFINSYSClient _ifinsysClient;
    private readonly string _controller = "SysCurrency";
    private readonly string _routeGetRows = "GetRows";
    private readonly string _routeGetRowsForLookup = "GetRowsForLookup";
    private readonly string _routeGetRowByID = "GetRowByID";
    private readonly string _routeInsert = "Insert";
    private readonly string _routeUpdateByID = "UpdateByID";
    private readonly string _routeDeleteByID = "DeleteByID";
    private readonly string _routeChangeStatus = "ChangeStatus";

    public SysCurrencyService(IFINSYSClient ifinsysClient)
    {
      _ifinsysClient = ifinsysClient;
    }

    public async Task<List<SysCurrencyModel>?> GetRows(string? keyword, int offset, int limit)
    {
      var res = await _ifinsysClient.GetRows<SysCurrencyModel>(_controller, _routeGetRows, new { keyword, offset, limit });
      return res?.Data;
    }

    public async Task<List<SysCurrencyModel>?> GetRowsForLookup(string? keyword, int offset, int limit)
    {
      var res = await _ifinsysClient.GetRows<SysCurrencyModel>(_controller, _routeGetRowsForLookup, new { keyword, offset, limit });
      return res?.Data;
    }

    public async Task<SysCurrencyModel?> GetRowByID(string? id)
    {
      var res = await _ifinsysClient.GetRow<SysCurrencyModel>(_controller, _routeGetRowByID, id);
      return res?.Data;
    }

    public async Task<BodyResponse<BaseModel>?> Insert(SysCurrencyModel model)
    {
      var res = await _ifinsysClient.Post(_controller, _routeInsert, model);

      return res;
    }

    public async Task<BodyResponse<object>?> UpdateByID(SysCurrencyModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeUpdateByID, model);
      return res;
    }
    public async Task<BodyResponse<object>?> DeleteByID(string?[] ID)
    {
      var res = await _ifinsysClient.Delete(_controller, _routeDeleteByID, ID);
      return res;
    }

    public async Task<BodyResponse<object>?> ChangeStatus(SysCurrencyModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeChangeStatus, model);
      return res;
    }
  }
}