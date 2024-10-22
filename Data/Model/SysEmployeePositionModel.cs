namespace Data.Model
{
	public class SysEmployeePositionModel : BaseModel
	{
		public string? Code { get; set; }
		public string? EmployeeID { get; set; }
		public string? PositionID { get; set; }
		public int? IsBasePosition { get; set; }

		#region SysPositionModel
		public string? PositionDescription { get; set; }
		#endregion
	}
}