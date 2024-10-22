namespace Data.Model
{
	public class SysDepartmentModel : BaseModel
	{
		public string? Code { get; set; }
		public string? DivisionID { get; set; }
		public string? Description { get; set; }
		public int? IsActive { get; set; }

		#region SysDivision
		public string? DivisionDescription { get; set; }
		#endregion
	}
}