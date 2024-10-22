using Data.Model;
using Helper;
using Helper.APIClient;
namespace Data.Service
{
  [Service]
  public class SysMenuRoleService
  {
    public readonly IFINSYSClient _ifinsysClient;
    private readonly string _controller = "SysMenuRole";
    private readonly string _routeGetRows = "GetRows";
    private readonly string _routeGetRowsLookupForRoleGroupDetail = "GetRowsLookupForRoleGroupDetail";
    private readonly string _routeGetRowsLookupForUserRole = "GetRowsLookupForUserRole";
    private readonly string _routeGetRow = "GetRowByID";
    private readonly string _routeInsert = "Insert";
    private readonly string _routeUpdate = "UpdateByID";
    private readonly string _routeDelete = "DeleteByID";

    public SysMenuRoleService(IFINSYSClient ifinsysClient)
    {
      _ifinsysClient = ifinsysClient;
    }

    public async Task<List<SysMenuRoleModel>?> GetRows(string? keyword, int offset, int limit, string MenuID)
    {
      var res = await _ifinsysClient.GetRows<SysMenuRoleModel>(_controller, _routeGetRows, new { keyword, offset, limit, MenuID });
      return res?.Data;
    }
    public async Task<List<SysMenuRoleModel>?> GetRowsLookupForRoleGroupDetail(string? keyword, int offset, int limit, string? roleGroupID, string? moduleID, string? menuID, string? subMenuID, string? roleAccess)
    {
      var res = await _ifinsysClient.GetRows<SysMenuRoleModel>(_controller, _routeGetRowsLookupForRoleGroupDetail, new { keyword, offset, limit, roleGroupID, moduleID, menuID, subMenuID, roleAccess });
      return res?.Data;
    }
    public async Task<List<SysMenuRoleModel>?> GetRowsLookupForUserRole(string? keyword, int offset, int limit, string? userID)
    {
      var res = await _ifinsysClient.GetRows<SysMenuRoleModel>(_controller, _routeGetRowsLookupForUserRole, new { keyword, offset, limit, userID });
      return res?.Data;
    }
    public async Task<SysMenuRoleModel?> GetRowByID(string? ID)
    {
      var res = await _ifinsysClient.GetRow<SysMenuRoleModel>(_controller, _routeGetRow, ID);
      var data = res?.Data;
      return data;
    }

    public async Task<BodyResponse<BaseModel>?> Insert(SysMenuRoleModel model)
    {
      var res = await _ifinsysClient.Post(_controller, _routeInsert, model);
      return res;
    }

    public async Task<BodyResponse<object>?> Update(SysMenuRoleModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeUpdate, model);
      return res;
    }
    public async Task<BodyResponse<object>?> Delete(string[] ID)
    {
      var res = await _ifinsysClient.Delete(_controller, _routeDelete, ID);
      return res;
    }

  }
}