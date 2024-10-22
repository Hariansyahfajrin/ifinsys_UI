namespace Data.Model
{
	public class SysEmployeeBranchModel : BaseModel
	{
		public string? Code { get; set; }
		public string? EmployeeID { get; set; }
		public string? BranchID { get; set; }
		public int? IsBase { get; set; }

		#region SysBranchModel
		public string? BranchName { get; set; }
		#endregion

	}
}