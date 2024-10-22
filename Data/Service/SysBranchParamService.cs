using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
  [Service]
  public class SysBranchParamService
  {
    private readonly IFINSYSClient _ifinsysClient;
    private readonly string _controller = "SysBranchParam";
    private readonly string _routeGetRows = "GetRows";
    private readonly string _routeGetRowByID = "GetRowByID";
    private readonly string _routeInsert = "Insert";
    private readonly string _routeUpdateByID = "UpdateByID";
    private readonly string _routeDeleteByID = "DeleteByID";

    public SysBranchParamService(IFINSYSClient ifinsysClient)
    {
      _ifinsysClient = ifinsysClient;
    }

    public async Task<List<SysBranchParamModel>?> GetRows(string? keyword, int offset, int limit, string? branchID)
    {
      var res = await _ifinsysClient.GetRows<SysBranchParamModel>(_controller, _routeGetRows, new { keyword, offset, limit, branchID });
      return res?.Data;
    }

    public async Task<SysBranchParamModel?> GetRowByID(string? id)
    {
      var res = await _ifinsysClient.GetRow<SysBranchParamModel>(_controller, _routeGetRowByID, id);
      return res?.Data;
    }

    public async Task<BodyResponse<BaseModel>?> Insert(SysBranchParamModel model)
    {
      var res = await _ifinsysClient.Post(_controller, _routeInsert, model);

      return res;
    }

    public async Task<BodyResponse<object>?> UpdateByID(SysBranchParamModel model)
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