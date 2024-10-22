namespace Data.Model
{
	public class SysModuleModel : BaseModel
	{
		public string? Code { get; set; }
		public string? Name { get; set; }
		public string? IP { get; set; }
		public string? Colour { get; set; }
		public string? Icon { get; set; }
		public int? OrderKey { get; set; }
		public string? ServerIPAddress { get; set; }
		public int? IsActive { get; set; }
	}
}