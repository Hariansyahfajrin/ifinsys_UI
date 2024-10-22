using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
  [Service]
  public class SysNotificationService
  {
    private readonly IFINSYSClient _ifinsysClient;
    private readonly string _controller = "SysNotification";
    private readonly string _routeGetRows = "GetRows";
    private readonly string _routeGetRowByID = "GetRowByID";
    private readonly string _routeInsert = "Insert";
    private readonly string _routeUpdateByID = "UpdateByID";
    private readonly string _routeDeleteByID = "DeleteByID";
    private readonly string _routeChangeStatus = "ChangeStatus";

    public SysNotificationService(IFINSYSClient ifinsysClient)
    {
      _ifinsysClient = ifinsysClient;
    }

    public async Task<List<SysNotificationModel>?> GetRows(string? keyword, int offset, int limit)
    {
      var res = await _ifinsysClient.GetRows<SysNotificationModel>(_controller, _routeGetRows, new { keyword, offset, limit });
      return res?.Data;
    }

    public async Task<SysNotificationModel?> GetRowByID(string? id)
    {
      var res = await _ifinsysClient.GetRow<SysNotificationModel>(_controller, _routeGetRowByID, id);
      return res?.Data;
    }

    public async Task<BodyResponse<BaseModel>?> Insert(SysNotificationModel model)
    {
      var res = await _ifinsysClient.Post(_controller, _routeInsert, model);

      return res;
    }

    public async Task<BodyResponse<object>?> UpdateByID(SysNotificationModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeUpdateByID, model);
      return res;
    }
    public async Task<BodyResponse<object>?> DeleteByID(string?[] ID)
    {
      var res = await _ifinsysClient.Delete(_controller, _routeDeleteByID, ID);
      return res;
    }

    public async Task<BodyResponse<object>?> ChangeStatus(SysNotificationModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeChangeStatus, model);
      return res;
    }
  }
}