namespace Data.Model
{
	public class SysHolidayModel : BaseModel
	{
		public DateTime? HolidayDate { get; set; }
		public string? Description { get; set; }
		public int? IsActive { get; set; }
	}
}