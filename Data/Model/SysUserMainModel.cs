namespace Data.Model
{
  public class SysUserMainModel : BaseModel
  {
    public string? Code { get; set; }
    public string? UPass { get; set; }
    public string? UPassApproval { get; set; }
    public DateTime? LastLoginDate { get; set; }
    public int? LastFailCount { get; set; }
    public DateTime? NextChangePass { get; set; }
    public int? IsActive { get; set; }

    #region SysEmployeeMain
    public string? EmployeeName { get; set; }
    #endregion
  }
}