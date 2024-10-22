using Data.Model;
using Helper;
using Helper.APIClient;

namespace Data.Service
{
  [Service]
  public class SysBranchBankService
  {
    private readonly IFINSYSClient _ifinsysClient;
    private readonly string _controller = "SysBranchBank";
    private readonly string _routeGetRows = "GetRows";
    private readonly string _routeGetRowByID = "GetRowByID";
    private readonly string _routeInsert = "Insert";
    private readonly string _routeUpdateByID = "UpdateByID";
    private readonly string _routeUpload = "Upload";
    private readonly string _routePreview = "Preview";
    private readonly string _routeDeleteFile = "DeleteFile";
    private readonly string _routeDeleteByID = "DeleteByID";
    private readonly string _routeChangeStatus = "ChangeStatus";

    public SysBranchBankService(IFINSYSClient ifinsysClient)
    {
      _ifinsysClient = ifinsysClient;
    }

    public async Task<List<SysBranchBankModel>?> GetRows(string? keyword, int offset, int limit, string? branchID)
    {
      var res = await _ifinsysClient.GetRows<SysBranchBankModel>(_controller, _routeGetRows, new { keyword, offset, limit, branchID });
      return res?.Data;
    }

    public async Task<SysBranchBankModel?> GetRowByID(string? id)
    {
      var res = await _ifinsysClient.GetRow<SysBranchBankModel>(_controller, _routeGetRowByID, id);
      return res?.Data;
    }

    public async Task<BodyResponse<BaseModel>?> Insert(SysBranchBankModel model)
    {
      var res = await _ifinsysClient.Post(_controller, _routeInsert, model);

      return res;
    }

    public async Task<BodyResponse<object>?> UpdateByID(SysBranchBankModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeUpdateByID, model);
      return res;
    }

    public async Task<BodyResponse<object>?> DeleteByID(string[] ID)
    {
      var res = await _ifinsysClient.Delete(_controller, _routeDeleteByID, ID);
      return res;
    }

    public async Task<BodyResponse<object>?> ChangeStatus(SysBranchBankModel model)
    {
      var res = await _ifinsysClient.Put(_controller, _routeChangeStatus, model);
      return res;
    }
    public async Task<BodyResponse<object>?> Upload(SysBranchBankModel model)
    {
      var res = await _ifinsysClient.Post<object>(_controller, _routeUpload, model);

      return res;
    }
    public async Task<SysBranchBankModel?> Preview(string? id)
    {
      var res = await _ifinsysClient.GetRow<SysBranchBankModel>(_controller, _routePreview, id);

      return res?.Data;
    }
    public async Task<BodyResponse<object>?> DeleteFile(SysBranchBankModel model)
    {
      var res = await _ifinsysClient.Delete(_controller, _routeDeleteFile, model);

      return res;
    }
  }
}