namespace innoteksoWebNew.Models
{
    public class PricingPackageModel
    {
        public string Name { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string IconClass { get; set; } = string.Empty;
        public string InstallationPrice { get; set; } = string.Empty;
        public string DeviceBundlePrice { get; set; } = string.Empty;
        public List<string> Features { get; set; } = new List<string>();
        public bool IsPopular { get; set; } = false;
    }
}
