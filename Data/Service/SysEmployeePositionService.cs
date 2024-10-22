using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
  [Service]
  public class SysEmployeePositionService
  {
    private readonly IFINSYSClient _ifinsysClient;
    private readonly string _controller = "SysEmployeePosition";
    private readonly string _routeGetRows = "GetRows";
    private readonly string _routeGetRow = "GetRowByID";
    private readonly string _routeInsert = "Insert";
    private readonly string _routeUpdate = "UpdateByID";
    private readonly string _routeDelete = "DeleteByID";

    public SysEmployeePositionService(IFINSYSClient ifinsysClient)
    {
      _ifinsysClient = ifinsysClient;
    }

    public async Task<List<SysEmployeePositionModel>?> GetRows(string? keyword, int offset, int limit, string? employeeID)
    {
      var res = await _ifinsysClient.GetRows<SysEmployeePositionModel>(_controller, _routeGetRows, new { keyword, offset, limit, employeeID });
      return res?.Data;
    }

    public async Task<SysEmployeePositionModel?> GetRowByID(string? ID)
    {
      var res = await _ifinsysClient.GetRow<SysEmployeePositionModel>(_controller, _routeGetRow, ID);
      return res?.Data;
    }

    public async Task<BodyResponse<BaseModel>?> Insert(SysEmployeePositionModel model)
    {
      var res = await _ifinsysClient.Post(_controller, _routeInsert, model);

      return res;
    }

    public async Task<BodyResponse<object>?> Update(SysEmployeePositionModel model)
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