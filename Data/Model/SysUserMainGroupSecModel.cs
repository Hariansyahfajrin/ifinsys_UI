namespace Data.Model
{
  public class SysUserMainGroupSecModel : BaseModel
  {
    public string? RoleGroupID { get; set; }
    public string? UserID { get; set; }

    #region SysRoleGroup
    public string? RoleGroupName { get; set; }
    #endregion
  }
}