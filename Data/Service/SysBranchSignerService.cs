using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
  [Service]
  public class SysBranchSignerService
  {
    private readonly IFINSYSClient _ifinsysClient;
    private readonly string _controller = "SysBranchSigner";
    private readonly string _routeGetRows = "GetRows";
    private readonly string _routeGetRowsForLookup = "GetRowsForLookup";
    private readonly string _routeGetRowByID = "GetRowByID";
    private readonly string _routeInsert = "Insert";
    private readonly string _routeUpdateByID = "UpdateByID";
    private readonly string _routeDeleteByID = "DeleteByID";

    public SysBranchSignerService(IFINSYSClient ifinsysClient)
    {
      _ifinsysClient = ifinsysClient;
    }

    public async Task<List<SysBranchSignerModel>?> GetRows(string? keyword, int offset, int limit, string? branchID)
    {
      var res = await _ifinsysClient.GetRows<SysBranchSignerModel>(_controller, _routeGetRows, new { keyword, offset, limit, branchID });
      return res?.Data;
    }

    public async Task<List<SysBranchSignerModel>?> GetRowsForLookup(string? keyword, int offset, int limit, bool WithAll = false)
    {
      var res = await _ifinsysClient.GetRows<SysBranchSignerModel>(_controller, _routeGetRowsForLookup, new { keyword, offset, limit, WithAll = WithAll.ToString() });
      return res?.Data;
    }

    public async Task<SysBranchSignerModel?> GetRowByID(string? id)
    {
      var res = await _ifinsysClient.GetRow<SysBranchSignerModel>(_controller, _routeGetRowByID, id);
      return res?.Data;
    }

    public async Task<BodyResponse<BaseModel>?> Insert(SysBranchSignerModel model)
    {
      var res = await _ifinsysClient.Post(_controller, _routeInsert, model);

      return res;
    }

    public async Task<BodyResponse<object>?> UpdateByID(SysBranchSignerModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeUpdateByID, model);
      return res;
    }
    public async Task<BodyResponse<object>?> DeleteByID(string[] ID)
    {
      var res = await _ifinsysClient.Delete(_controller, _routeDeleteByID, ID);
      return res;
    }
  }
}