namespace Data.Model
{
	public class SysEmployeeMainModel : BaseModel
	{
		public string? Code { get; set; }
		public string? CompanyID { get; set; }
		public string? Name { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string? NIK { get; set; }
		public string? DepartmentID { get; set; }
		public string? HeadEmployeeID { get; set; }
		public string? ProvinceID { get; set; }
		public string? CityID { get; set; }
		public string? ZipCodeID { get; set; }
		public string? SubDistrict { get; set; }
		public string? Village { get; set; }
		public string? Address { get; set; }
		public string? AreaPhoneNo { get; set; }
		public string? PhoneNo { get; set; }
		public string? AreaHandphoneNo { get; set; }
		public string? HandphoneNo { get; set; }
		public string? Email { get; set; }
		public string? OtherEmail { get; set; }
		public string? PersonalInfo { get; set; }
		public int? IsActive { get; set; }

		#region SysEmployeeMain (Head Emplloyee)
		public string? HeadEmployeeName { get; set; }
		#endregion

		#region SysCompany
		public string? CompanyName { get; set; }
		#endregion

		#region SysDepartment
		public string? DepartmentDescription { get; set; }
		#endregion

		#region SysPosition
		public string? BasePositionDescription { get; set; }
		#endregion
		#region SysCity
		public string? CityDescription { get; set; }
		#endregion

		#region SysProvince
		public string? ProvinceDescription { get; set; }
		#endregion

		#region SysZipCode
		public string? ZipCodePostalCode { get; set; }
		#endregion
	}
}