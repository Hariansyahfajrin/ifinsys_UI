namespace Data.Model
{
    public class JournalGLLinkModel : BaseModel
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int? IsBank { get; set; }
        public int? IsActive { get; set; }
    }
}