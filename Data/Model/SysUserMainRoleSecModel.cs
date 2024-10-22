namespace Data.Model
{
  public class SysUserMainRoleSecModel : BaseModel
  {
    public string? UserID { get; set; }
    public string? RoleID { get; set; }

    #region SysMenuRole
    public string? RoleCode { get; set; }
    public string? RoleName { get; set; }
    #endregion
  }
}