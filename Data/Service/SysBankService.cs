using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
  [Service]
  public class SysBankService
  {
    private readonly IFINSYSClient _ifinsysClient;
    private readonly string _controller = "SysBank";
    private readonly string _routeGetRows = "GetRows";
    private readonly string _routeGetRowsForLookup = "GetRowsForLookup";
    private readonly string _routeGetRowByID = "GetRowByID";
    private readonly string _routeInsert = "Insert";
    private readonly string _routeUpdateByID = "UpdateByID";
    private readonly string _routeDeleteByID = "DeleteByID";
    private readonly string _routeChangeStatus = "ChangeStatus";

    public SysBankService(IFINSYSClient ifinsysClient)
    {
      _ifinsysClient = ifinsysClient;
    }

    public async Task<List<SysBankModel>?> GetRows(string? keyword, int offset, int limit)
    {
      var res = await _ifinsysClient.GetRows<SysBankModel>(_controller, _routeGetRows, new { keyword, offset, limit });
      return res?.Data;
    }

    public async Task<List<SysBankModel>?> GetRowsForLookup(string? keyword, int offset, int limit, bool WithAll = false)
    {
      var res = await _ifinsysClient.GetRows<SysBankModel>(_controller, _routeGetRowsForLookup, new { keyword, offset, limit, WithAll = WithAll.ToString() });
      return res?.Data;
    }

    public async Task<SysBankModel?> GetRowByID(string? id)
    {
      var res = await _ifinsysClient.GetRow<SysBankModel>(_controller, _routeGetRowByID, id);
      return res?.Data;
    }

    public async Task<BodyResponse<BaseModel>?> Insert(SysBankModel model)
    {
      var res = await _ifinsysClient.Post(_controller, _routeInsert, model);

      return res;
    }

    public async Task<BodyResponse<object>?> UpdateByID(SysBankModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeUpdateByID, model);
      return res;
    }
    public async Task<BodyResponse<object>?> DeleteByID(string?[] ID)
    {
      var res = await _ifinsysClient.Delete(_controller, _routeDeleteByID, ID);
      return res;
    }

    public async Task<BodyResponse<object>?> ChangeStatus(SysBankModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeChangeStatus, model);
      return res;
    }
  }
}