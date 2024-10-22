namespace Data.Model
{
  public class SysBranchSignerModel : BaseModel
  {
    public string? Code { get; set; }
    public string? BranchID { get; set; }
    public string? EmployeeID { get; set; }
    public string? SignerTypeID { get; set; }
    public string? SignerName { get; set; }
    public string? SignerKTPNo { get; set; }
    public int? OrderNo { get; set; }

    #region SysGeneralSubcode
    public string? SignerTypeDescription { get; set; }
    #endregion
  }
}