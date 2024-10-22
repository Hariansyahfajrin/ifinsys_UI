using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
  [Service]
  public class SysMenuService
  {
    private readonly IFINSYSClient _ifinsysClient;
    private readonly string _controller = "SysMenu";
    private readonly string _routeGetRows = "GetRows";
    private readonly string _routeGetRow = "GetRowByID";
    private readonly string _routeInsert = "Insert";
    private readonly string _routeUpdate = "UpdateByID";
    private readonly string _routeDelete = "DeleteByID";
    private readonly string _routeChangeStatus = "ChangeStatus";
    private readonly string _routeGetRowsForLookup = "GetRowsForLookupParent";

    public SysMenuService(IFINSYSClient ifinsysClient)
    {
      _ifinsysClient = ifinsysClient;
    }

    public async Task<List<SysMenuModel>?> GetRows(string? keyword, int offset, int limit, string ModuleID = "all", string ParentMenuID = "all")
    {
      var res = await _ifinsysClient.GetRows<SysMenuModel>(_controller, _routeGetRows, new { Keyword = keyword, Offset = offset, Limit = limit, ModuleID, ParentMenuID });
      return res?.Data;
    }
    public async Task<SysMenuModel?> GetRowByID(string? id)
    {
      var res = await _ifinsysClient.GetRow<SysMenuModel>(_controller, _routeGetRow, id);
      var data = res?.Data;
      return data;
    }

    public async Task<BodyResponse<BaseModel>?> Insert(SysMenuModel model)
    {
      var res = await _ifinsysClient.Post(_controller, _routeInsert, model);
      return res;
    }

    public async Task<BodyResponse<object>?> Update(SysMenuModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeUpdate, model);
      return res;
    }
    public async Task<BodyResponse<object>?> Delete(string[] ID)
    {
      var res = await _ifinsysClient.Delete(_controller, _routeDelete, ID);
      return res;
    }

    public async Task<List<SysMenuModel>?> GetRowsForLookupParent(string? keyword, int offset, int limit, string ModuleID, bool WithAll = false)
    {
      var res = await _ifinsysClient.GetRows<SysMenuModel>(_controller, _routeGetRowsForLookup, new { keyword, offset, limit, ModuleID, WithAll = WithAll.ToString() });
      return res?.Data;
    }

    public async Task<BodyResponse<object>?> ChangeStatus(SysMenuModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeChangeStatus, model);
      return res;
    }
  }
}