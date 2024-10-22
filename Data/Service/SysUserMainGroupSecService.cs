using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
  [Service]
  public class SysUserMainGroupSecService
  {
    private readonly IFINSYSClient _ifinsysClient;
    private readonly string _controller = "SysUserMainGroupSec";
    private readonly string _routeGetRows = "GetRows";
    private readonly string _routeGetRowByID = "GetRowByID";
    private readonly string _routeInsert = "Insert";
    private readonly string _routeUpdateByID = "UpdateByID";
    private readonly string _routeDeleteByID = "DeleteByID";

    public SysUserMainGroupSecService(IFINSYSClient ifinsysClient)
    {
      _ifinsysClient = ifinsysClient;
    }

    public async Task<List<SysUserMainGroupSecModel>?> GetRows(string? keyword, int offset, int limit, string? userID)
    {
      var res = await _ifinsysClient.GetRows<SysUserMainGroupSecModel>(_controller, _routeGetRows, new { keyword, offset, limit, userID });
      return res?.Data;
    }

    public async Task<SysUserMainGroupSecModel?> GetRowByID(string? ID)
    {
      var res = await _ifinsysClient.GetRow<SysUserMainGroupSecModel>(_controller, _routeGetRowByID, ID);
      return res?.Data;
    }

    public async Task<BodyResponse<BaseModel>?> Insert(List<SysUserMainGroupSecModel> model)
    {
      var res = await _ifinsysClient.Post(_controller, _routeInsert, model);

      return res;
    }

    public async Task<BodyResponse<object>?> UpdateByID(SysUserMainGroupSecModel model)
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