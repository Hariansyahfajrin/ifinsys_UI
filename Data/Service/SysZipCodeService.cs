using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
  [Service]
  public class SysZipCodeService
  {
    private readonly IFINSYSClient _ifinsysClient;
    private readonly string _controller = "SysZipCode";
    private readonly string _routeGetRows = "GetRows";
    private readonly string _routeGetRowsForLookup = "GetRowsForLookup";
    private readonly string _routeGetRow = "GetRowByID";
    private readonly string _routeInsert = "Insert";
    private readonly string _routeUpdate = "UpdateByID";
    private readonly string _routeDelete = "DeleteByID";
    private readonly string _routeChangeStatus = "ChangeStatus";

    public SysZipCodeService(IFINSYSClient ifinsysClient)
    {
      _ifinsysClient = ifinsysClient;
    }

    public async Task<List<SysZipCodeModel>?> GetRows(string? keyword, int offset, int limit)
    {
      var res = await _ifinsysClient.GetRows<SysZipCodeModel>(_controller, _routeGetRows, new { keyword, offset, limit });
      return res?.Data;
    }

    public async Task<List<SysZipCodeModel>?> GetRowsForLookup(string? keyword, int offset, int limit, string? provinceID, string? cityID, bool WithAll = false)
    {
      var res = await _ifinsysClient.GetRows<SysZipCodeModel>(_controller, _routeGetRowsForLookup, new { keyword, offset, limit, provinceID, cityID, WithAll = WithAll.ToString() });
      return res?.Data;
    }

    public async Task<SysZipCodeModel?> GetRowByID(string? ID)
    {
      var res = await _ifinsysClient.GetRow<SysZipCodeModel>(_controller, _routeGetRow, ID);
      return res?.Data;
    }

    public async Task<BodyResponse<BaseModel>?> Insert(SysZipCodeModel model)
    {
      var res = await _ifinsysClient.Post(_controller, _routeInsert, model);

      return res;
    }

    public async Task<BodyResponse<object>?> Update(SysZipCodeModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeUpdate, model);
      return res;
    }
    public async Task<BodyResponse<object>?> Delete(string[] ID)
    {
      var res = await _ifinsysClient.Delete(_controller, _routeDelete, ID);
      return res;
    }

    public async Task<BodyResponse<object>?> ChangeStatus(SysZipCodeModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeChangeStatus, model);
      return res;
    }
  }
}