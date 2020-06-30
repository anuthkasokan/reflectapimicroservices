namespace ReflectionEmailService.Models
{
    public class EmailTemplate
    {
        public string type { get; set; }
        public string subject { get; set; }
        public string headerprefix { get; set; }
        public string footer { get; set; }
        public string body { get; set; }
    }
}
