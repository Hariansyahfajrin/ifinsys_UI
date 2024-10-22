namespace Data.Model
{
	public class SysBranchModel : BaseModel
	{
		public string? Code { get; set; }
		public string? Name { get; set; }
		public string? CompanyID { get; set; }
		public string? RegionID { get; set; }
		public string? ProvinceID { get; set; }
		public string? CityID { get; set; }
		public string? ZipCodeID { get; set; }
		public string? SubDistrict { get; set; }
		public string? Village { get; set; }
		public string? Address { get; set; }
		public string? BranchType { get; set; }
		public string? AreaPhoneNo { get; set; }
		public string? PhoneNo { get; set; }
		public string? AreaFaxNo { get; set; }
		public string? FaxNo { get; set; }
		public string? EmailDefault { get; set; }
		public int? IsSyariah { get; set; }
		public int? IsActive { get; set; }


		#region SysRegionModel
		public string? RegionDescription { get; set; }
		#endregion

		#region SysProvinceModel
		public string? ProvinceDescription { get; set; }
		#endregion

		#region SysCityModel
		public string? CityDescription { get; set; }
		#endregion

		#region SysCompanyModel
		public string? CompanyName { get; set; }
		#endregion

		#region SysZipCodeModel
		public string? ZipCodePostalCode { get; set; }
		#endregion
	}
}