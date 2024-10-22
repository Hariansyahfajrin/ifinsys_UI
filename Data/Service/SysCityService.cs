using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
  [Service]
  public class SysCityService
  {
    private readonly IFINSYSClient _ifinsysClient;
    private readonly string _controller = "SysCity";
    private readonly string _routeGetRows = "GetRows";
    private readonly string _routeGetRowsForLookup = "GetRowsForLookup";
    private readonly string _routeGetRow = "GetRowByID";
    private readonly string _routeInsert = "Insert";
    private readonly string _routeUpdate = "UpdateByID";
    private readonly string _routeDelete = "DeleteByID";
    private readonly string _routeChangeStatus = "ChangeStatus";

    public SysCityService(IFINSYSClient ifinsysClient)
    {
      _ifinsysClient = ifinsysClient;
    }

    public async Task<List<SysCityModel>?> GetRows(string? keyword, int offset, int limit, string ProvinceID)
    {
      var res = await _ifinsysClient.GetRows<SysCityModel>(_controller, _routeGetRows, new { keyword, offset, limit, ProvinceID });
      return res?.Data;
    }

    public async Task<List<SysCityModel>?> GetRowsForLookup(string? keyword, int offset, int limit, string provinceID, bool WithAll = false)
    {
      var res = await _ifinsysClient.GetRows<SysCityModel>(_controller, _routeGetRowsForLookup, new { keyword, offset, limit, ProvinceID = provinceID, WithAll = WithAll.ToString() });
      return res?.Data;
    }

    public async Task<SysCityModel?> GetRowByID(string? id)
    {
      var res = await _ifinsysClient.GetRow<SysCityModel>(_controller, _routeGetRow, id);
      return res?.Data;
    }

    public async Task<BodyResponse<BaseModel>?> Insert(SysCityModel model)
    {
      var res = await _ifinsysClient.Post(_controller, _routeInsert, model);

      return res;
    }

    public async Task<BodyResponse<object>?> Update(SysCityModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeUpdate, model);
      return res;
    }
    public async Task<BodyResponse<object>?> Delete(string[] ID)
    {
      var res = await _ifinsysClient.Delete(_controller, _routeDelete, ID);
      return res;
    }

    public async Task<BodyResponse<object>?> ChangeStatus(SysCityModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeChangeStatus, model);
      return res;
    }
  }
}