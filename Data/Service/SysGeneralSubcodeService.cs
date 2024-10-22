using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
  [Service]
  public class SysGeneralSubcodeService
  {
    private readonly IFINSYSClient _ifinsysClient;
    private readonly string _controller = "SysGeneralSubcode";
    private readonly string _routeGetRows = "GetRows";
    private readonly string _routeGetRowsForLookup = "GetRowsForLookup";
    private readonly string _routeGetRowByID = "GetRowByID";
    private readonly string _routeInsert = "Insert";
    private readonly string _routeUpdateByID = "UpdateByID";
    private readonly string _routeDeleteByID = "DeleteByID";
    private readonly string _routeChangeStatus = "ChangeStatus";

    public SysGeneralSubcodeService(IFINSYSClient ifinsysClient)
    {
      _ifinsysClient = ifinsysClient;
    }

    public async Task<List<SysGeneralSubcodeModel>?> GetRows(string? keyword, int offset, int limit, string generalCodeID)
    {
      var res = await _ifinsysClient.GetRows<SysGeneralSubcodeModel>(_controller, _routeGetRows, new { keyword, offset, limit, generalCodeID });
      return res?.Data;
    }

    public async Task<List<SysGeneralSubcodeModel>?> GetRowsForLookup(string? keyword, int offset, int limit, string? generalCode)
    {
      var res = await _ifinsysClient.GetRows<SysGeneralSubcodeModel>(_controller, _routeGetRowsForLookup, new { keyword, offset, limit, generalCode });
      return res?.Data;
    }

    public async Task<SysGeneralSubcodeModel?> GetRowByID(string? id)
    {
      var res = await _ifinsysClient.GetRow<SysGeneralSubcodeModel>(_controller, _routeGetRowByID, id);
      return res?.Data;
    }

    public async Task<BodyResponse<BaseModel>?> Insert(SysGeneralSubcodeModel model)
    {
      var res = await _ifinsysClient.Post(_controller, _routeInsert, model);

      return res;
    }

    public async Task<BodyResponse<object>?> UpdateByID(SysGeneralSubcodeModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeUpdateByID, model);
      return res;
    }
    public async Task<BodyResponse<object>?> DeleteByID(string?[] ID)
    {
      var res = await _ifinsysClient.Delete(_controller, _routeDeleteByID, ID);
      return res;
    }

    public async Task<BodyResponse<object>?> ChangeStatus(SysGeneralSubcodeModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeChangeStatus, model);
      return res;
    }
  }
}