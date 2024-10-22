namespace Data.Model
{
	public class SysMenuModel : BaseModel
	{
		public string? Code { get; set; }
		public string? Name { get; set; }
		public string? ModuleID { get; set; }
		public string? ParentMenuID { get; set; }
		public string? Abbreviation { get; set; } = "";
		public string? RoutingMenu { get; set; }
		public string? URLMenu { get; set; }
		public int? OrderKey { get; set; }
		public string? CssIcon { get; set; } = "";
		public int? IsActive { get; set; }
		public string? Type { get; set; }

		#region SysModule
		public string? ModuleCode { get; set; }
		public string? ModuleName { get; set; }
		#endregion

		#region SysMenu (Parent Menu)
		public string? ParentMenuName { get; set; }
		#endregion
	}
}