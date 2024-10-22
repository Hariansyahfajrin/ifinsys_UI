namespace Data.Model
{
	public class SysCurrencyRateModel : BaseModel
	{
		public string? CurrencyID { get; set; }
		public DateTime? EffectiveDate { get; set; }
		public decimal? BuyRate { get; set; }
		public decimal? SaleBuyMid { get; set; }
		public decimal? SaleRate { get; set; }
	}
}