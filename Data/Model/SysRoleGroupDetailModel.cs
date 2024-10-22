namespace Data.Model
{
    public class SysRoleGroupDetailModel : BaseModel
    {
        public string? RoleGroupID { get; set; }
        public string? RoleID { get; set; }

        #region SysMenuRole
        public string? RoleCode { get; set; }
        public string? RoleName { get; set; }
        public string? RoleAccess { get; set; }
        #endregion

        #region SysMenu
        public string? MenuID { get; set; }
        public string? MenuName { get; set; }
        public string? SubMenuID { get; set; }
        public string? SubMenuName { get; set; }
        #endregion

        #region SysModule
        public string? ModuleID { get; set; }
        public string? ModuleName { get; set; }
        #endregion
    }
}