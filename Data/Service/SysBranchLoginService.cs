using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
  [Service]
  public class SysBranchLoginService
  {
    private readonly IFINSYSClient _ifinsysClient;
    private readonly string _controller = "SysBranchLogin";
    private readonly string _routeGetRows = "GetRows";
    private readonly string _routeGetRowByID = "GetRowByID";
    private readonly string _routeGetRowByBranch = "GetRowByBranch";
    private readonly string _routeInsert = "Insert";
    private readonly string _routeUpdateByID = "UpdateByID";
    private readonly string _routeDeleteByID = "DeleteByID";

    public SysBranchLoginService(IFINSYSClient ifinsysClient)
    {
      _ifinsysClient = ifinsysClient;
    }

    public async Task<List<SysBranchLoginModel>?> GetRows(string? keyword, int offset, int limit, string? branchID)
    {
      var res = await _ifinsysClient.GetRows<SysBranchLoginModel>(_controller, _routeGetRows, new { keyword, offset, limit, branchID });
      return res?.Data;
    }
    public async Task<SysBranchLoginModel?> GetRowByBranch(string? branchID)
    {
      var res = await _ifinsysClient.GetRow<SysBranchLoginModel>(_controller, _routeGetRowByBranch, new { BranchID = branchID });
      return res?.Data;
    }

    public async Task<SysBranchLoginModel?> GetRowByID(string? id)
    {
      var res = await _ifinsysClient.GetRow<SysBranchLoginModel>(_controller, _routeGetRowByID, id);
      return res?.Data;
    }

    public async Task<BodyResponse<BaseModel>?> Insert(SysBranchLoginModel model)
    {
      var res = await _ifinsysClient.Post(_controller, _routeInsert, model);

      return res;
    }

    public async Task<BodyResponse<object>?> UpdateByID(SysBranchLoginModel model)
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