using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
  [Service]
  public class SysUserMainRoleSecService
  {
    private readonly IFINSYSClient _ifinsysClient;
    private readonly string _controller = "SysUserMainRoleSec";
    private readonly string _routeGetRows = "GetRows";
    private readonly string _routeGetRowByID = "GetRowByID";
    private readonly string _routeInsert = "Insert";
    private readonly string _routeUpdateByID = "UpdateByID";
    private readonly string _routeDeleteByID = "DeleteByID";

    public SysUserMainRoleSecService(IFINSYSClient ifinsysClient)
    {
      _ifinsysClient = ifinsysClient;
    }

    public async Task<List<SysUserMainRoleSecModel>?> GetRows(string? keyword, int offset, int limit, string? userID)
    {
      var res = await _ifinsysClient.GetRows<SysUserMainRoleSecModel>(_controller, _routeGetRows, new { keyword, offset, limit, userID });
      return res?.Data;
    }

    public async Task<SysUserMainRoleSecModel?> GetRowByID(string? ID)
    {
      var res = await _ifinsysClient.GetRow<SysUserMainRoleSecModel>(_controller, _routeGetRowByID, ID);
      return res?.Data;
    }

    public async Task<BodyResponse<BaseModel>?> Insert(List<SysUserMainRoleSecModel> model)
    {
      var res = await _ifinsysClient.Post(_controller, _routeInsert, model);

      return res;
    }

    public async Task<BodyResponse<object>?> UpdateByID(SysUserMainRoleSecModel model)
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