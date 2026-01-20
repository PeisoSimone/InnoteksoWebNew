namespace InnoteksoWeb.Models
{
    public class SupportPlanModel
    {
        public string Name { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public List<string> Features { get; set; } = new List<string>();
    }
}
