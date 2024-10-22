namespace Data.Model
{
  public class SysBranchBankModel : BaseModel
  {
    public string? Code { get; set; }
    public string? BranchID { get; set; }
    public string? BankID { get; set; }
    public string? BankBranchName { get; set; }
    public string? CurrencyCode { get; set; }
    public string? BankAccountNo { get; set; }
    public string? BankAccountName { get; set; }
    public string? BankType { get; set; }
    public string? TypeFlag { get; set; }
    public int? DefaultFlag { get; set; }
    public string? EmployeeSignerPDCID { get; set; }
    public byte[]? FileBytes { get; set; }
    public string? FileName { get; set; }
    public string? Paths { get; set; }
    public string? GLLinkID { get; set; }
    public int? IsActive { get; set; }
    public int? IsEDC { get; set; }

    #region SysBank
    public string? BankDescription { get; set; }
    #endregion

    #region SysEmployeeMain
    public string? EmployeeSignerPDCName { get; set; }
    #endregion

    #region JournalGLLink
    public string? GLLinkName { get; set; }
    #endregion
  }
}