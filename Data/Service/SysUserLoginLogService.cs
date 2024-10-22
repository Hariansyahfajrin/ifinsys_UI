using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
  [Service]
  public class SysUserLoginLogService
  {
    private readonly IFINSYSClient _ifinsysClient;
    private readonly string _controller = "SysUserLoginLog";
    private readonly string _routeGetRows = "GetRows";
    private readonly string _routeGetRowByID = "GetRowByID";
    private readonly string _routeInsert = "Insert";
    private readonly string _routeUpdateByID = "UpdateByID";
    private readonly string _routeDeleteByID = "DeleteByID";

    public SysUserLoginLogService(IFINSYSClient ifinsysClient)
    {
      _ifinsysClient = ifinsysClient;
    }

    public async Task<List<SysUserLoginLogModel>?> GetRows(string? keyword, int offset, int limit, string? userID, DateTime? fromDate, DateTime? toDate)
    {
      var res = await _ifinsysClient.GetRows<SysUserLoginLogModel>(_controller, _routeGetRows, new { keyword, offset, limit, userID, FromDate = fromDate?.ToString("yyyy-MM-dd"), ToDate = toDate?.ToString("yyyy-MM-dd") });
      return res?.Data;
    }

    public async Task<SysUserLoginLogModel?> GetRowByID(string? id)
    {
      var res = await _ifinsysClient.GetRow<SysUserLoginLogModel>(_controller, _routeGetRowByID, id);
      return res?.Data;
    }

    public async Task<BodyResponse<BaseModel>?> Insert(SysUserLoginLogModel model)
    {
      var res = await _ifinsysClient.Post(_controller, _routeInsert, model);

      return res;
    }

    public async Task<BodyResponse<object>?> UpdateByID(SysUserLoginLogModel model)
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