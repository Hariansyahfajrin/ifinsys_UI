namespace Data.Model
{
	public class SysCityModel : BaseModel
	{
		public string? Code { get; set; }
		public string? BICode { get; set; }
		public string? ProvinceID { get; set; }
		public string? Description { get; set; }
		public string? Plat { get; set; }
		public int? IsActive { get; set; }
	}
}