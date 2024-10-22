namespace Data.Model
{
  public class SysBranchLoginModel : BaseModel
  {
    public string? BranchID { get; set; }
    public int? IsMonday { get; set; }
    public string? DateInMonday { get; set; }
    public string? DateOutMonday { get; set; }
    public int? IsTuesday { get; set; }
    public string? DateInTuesday { get; set; }
    public string? DateOutTuesday { get; set; }
    public int? IsWednesday { get; set; }
    public string? DateInWednesday { get; set; }
    public string? DateOutWednesday { get; set; }
    public int? IsThursday { get; set; }
    public string? DateInThursday { get; set; }
    public string? DateOutThursday { get; set; }
    public int? IsFriday { get; set; }
    public string? DateInFriday { get; set; }
    public string? DateOutFriday { get; set; }
    public int? IsSaturday { get; set; }
    public string? DateInSaturday { get; set; }
    public string? DateOutSaturday { get; set; }
    public int? IsSunday { get; set; }
    public string? DateInSunday { get; set; }
    public string? DateOutSunday { get; set; }
    public int? IsHoliday { get; set; }
    public string? DateInHoliday { get; set; }
    public string? DateOutHoliday { get; set; }
  }
}