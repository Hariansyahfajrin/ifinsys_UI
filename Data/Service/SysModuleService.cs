using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
  [Service]
  public class SysModuleService
  {
    private readonly IFINSYSClient _ifinsysClient;
    private readonly string _controller = "SysModule";
    private readonly string _routeGetRows = "GetRows";
    private readonly string _routeGetRow = "GetRowByID";
    private readonly string _routeInsert = "Insert";
    private readonly string _routeUpdate = "UpdateByID";
    private readonly string _routeDelete = "DeleteByID";
    private readonly string _routeChangeStatus = "ChangeStatus";
    private readonly string _routeGetRowsForLookup = "GetRowsForLookupModule";

    public SysModuleService(IFINSYSClient ifinsysClient)
    {
      _ifinsysClient = ifinsysClient;
    }

    public async Task<List<SysModuleModel>?> GetRows(string? keyword, int offset, int limit)
    {
      var res = await _ifinsysClient.GetRows<SysModuleModel>(_controller, _routeGetRows, new { keyword, offset, limit });
      return res?.Data;
    }

    public async Task<SysModuleModel?> GetRowByID(string? id)
    {
      var res = await _ifinsysClient.GetRow<SysModuleModel>(_controller, _routeGetRow, id);
      return res?.Data;
    }

    public async Task<BodyResponse<BaseModel>?> Insert(SysModuleModel model)
    {
      var res = await _ifinsysClient.Post(_controller, _routeInsert, model);

      return res;
    }

    public async Task<BodyResponse<object>?> Update(SysModuleModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeUpdate, model);
      return res;
    }
    public async Task<BodyResponse<object>?> Delete(string[] ID)
    {
      var res = await _ifinsysClient.Delete(_controller, _routeDelete, ID);
      return res;
    }

    public async Task<List<SysModuleModel>?> GetRowsForLookupModule(string? keyword, int offset, int limit, bool WithAll = false)
    {
      var res = await _ifinsysClient.GetRows<SysModuleModel>(_controller, _routeGetRowsForLookup, new { keyword, offset, limit, WithAll = WithAll.ToString() });
      return res?.Data;
    }

    public async Task<BodyResponse<object>?> ChangeStatus(SysModuleModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeChangeStatus, model);
      return res;
    }
  }
}