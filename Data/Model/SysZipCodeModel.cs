namespace Data.Model
{
	public class SysZipCodeModel : BaseModel
	{
		public string? ProvinceID { get; set; }
		public string? CityID { get; set; }
		public string? PostalCode { get; set; }
		public string? SubDistrict { get; set; }
		public string? Village { get; set; }
		public string? Name { get; set; }
		public int? IsActive { get; set; }

		#region SysProvince
		public string? ProvinceDescription { get; set; }
		#endregion

		#region SysCity
		public string? CityDescription { get; set; }
		#endregion
	}
}