
namespace Data.Model
{
	public class SysGeneralSubcodeModel : BaseModel
	{
		public string? Code { get; set; }
		public string? Description { get; set; }
		public string? GeneralCodeID { get; set; }
		public int? OrderKey { get; set; }
		public int? IsActive { get; set; }

		#region SysGeneralCode
		public string? GeneralCodeCode { get; set; }
		public string? GeneralCodeDescription { get; set; }
		#endregion
	}
}