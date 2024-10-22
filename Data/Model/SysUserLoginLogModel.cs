namespace Data.Model
{
  public class SysUserLoginLogModel : BaseModel
  {
    public string? UserID { get; set; }
    public DateTime? LoginDate { get; set; }
    public string? FlagCode { get; set; }
    public string? SessionID { get; set; }
    public string? IP { get; set; }
  }
}