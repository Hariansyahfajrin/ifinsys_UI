namespace Data.Model
{
  public class SysBranchDocModel : BaseModel
  {
    public string? Code { get; set; }
    public string? BranchID { get; set; }
    public string? DocumentNo { get; set; }
    public string? DocumentType { get; set; }
    public DateTime? ExpiredDate { get; set; }
    public DateTime? EffectiveDate { get; set; }

    #region SysGeneralSubcode
    public string? DocumentTypeDescription { get; set; }
    #endregion
  }
}