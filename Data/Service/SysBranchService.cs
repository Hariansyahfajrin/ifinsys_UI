using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
  [Service]
  public class SysBranchService
  {
    private readonly IFINSYSClient _ifinsysClient;
    private readonly string _controller = "SysBranch";
    private readonly string _routeGetRows = "GetRows";
    private readonly string _routeGetRowsForLookup = "GetRowsForLookup";
    private readonly string _routeGetRowsForLookupDiffCode = "GetRowsForLookupDiffCode";
    private readonly string _routeGetRow = "GetRowByID";
    private readonly string _routeInsert = "Insert";
    private readonly string _routeUpdate = "UpdateByID";
    private readonly string _routeDelete = "DeleteByID";
    private readonly string _routeChangeStatus = "ChangeStatus";

    public SysBranchService(IFINSYSClient ifinsysClient)
    {
      _ifinsysClient = ifinsysClient;
    }

    public async Task<List<SysBranchModel>?> GetRows(string? keyword, int offset, int limit)
    {
      var res = await _ifinsysClient.GetRows<SysBranchModel>(_controller, _routeGetRows, new { keyword, offset, limit });
      return res?.Data;
    }

    public async Task<List<SysBranchModel>?> GetRowsForLookup(string? keyword, int offset, int limit, bool WithAll = false)
    {
      var res = await _ifinsysClient.GetRows<SysBranchModel>(_controller, _routeGetRowsForLookup, new { keyword, offset, limit, WithAll = WithAll.ToString() });
      return res?.Data;
    }
    public async Task<List<SysBranchModel>?> GetRowsForLookupDiffCode(string? keyword, int offset, int limit, string[] codes)
    {
      var res = await _ifinsysClient.GetRows<SysBranchModel>(_controller, _routeGetRowsForLookupDiffCode, new { keyword, offset, limit, codes });
      return res?.Data;
    }

    public async Task<SysBranchModel?> GetRowByID(string? id)
    {
      var res = await _ifinsysClient.GetRow<SysBranchModel>(_controller, _routeGetRow, id);
      return res?.Data;
    }

    public async Task<BodyResponse<BaseModel>?> Insert(SysBranchModel model)
    {
      var res = await _ifinsysClient.Post(_controller, _routeInsert, model);

      return res;
    }

    public async Task<BodyResponse<object>?> Update(SysBranchModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeUpdate, model);
      return res;
    }
    public async Task<BodyResponse<object>?> Delete(string[] ID)
    {
      var res = await _ifinsysClient.Delete(_controller, _routeDelete, ID);
      return res;
    }

    public async Task<BodyResponse<object>?> ChangeStatus(SysBranchModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeChangeStatus, model);
      return res;
    }
  }
}