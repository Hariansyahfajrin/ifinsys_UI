using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
  [Service]
  public class SysEmployeeBranchService
  {
    private readonly IFINSYSClient _ifinsysClient;
    private readonly string _controller = "SysEmployeeBranch";
    private readonly string _routeGetRows = "GetRows";
    private readonly string _routeGetRowByID = "GetRowByID";
    private readonly string _routeInsert = "Insert";
    private readonly string _routeUpdateByID = "UpdateByID";
    private readonly string _routeDeleteByID = "DeleteByID";

    public SysEmployeeBranchService(IFINSYSClient ifinsysClient)
    {
      _ifinsysClient = ifinsysClient;
    }

    public async Task<List<SysEmployeeBranchModel>?> GetRows(string? keyword, int offset, int limit, string? employeeID)
    {
      var res = await _ifinsysClient.GetRows<SysEmployeeBranchModel>(_controller, _routeGetRows, new { keyword, offset, limit, employeeID });
      return res?.Data;
    }

    public async Task<SysEmployeeBranchModel?> GetRowByID(string? ID)
    {
      var res = await _ifinsysClient.GetRow<SysEmployeeBranchModel>(_controller, _routeGetRowByID, ID);
      return res?.Data;
    }

    public async Task<BodyResponse<BaseModel>?> Insert(SysEmployeeBranchModel model)
    {
      var res = await _ifinsysClient.Post(_controller, _routeInsert, model);

      return res;
    }

    public async Task<BodyResponse<object>?> UpdateByID(SysEmployeeBranchModel model)
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