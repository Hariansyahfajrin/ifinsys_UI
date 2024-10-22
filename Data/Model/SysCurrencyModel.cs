namespace Data.Model
{
	public class SysCurrencyModel : BaseModel
	{
		public string? Code { get; set; }
		public string? Description { get; set; }
		public string? OJKCode { get; set; }
		public int? IsBase { get; set; }
		public int? IsActive { get; set; }
	}
}