using System.Collections.Generic;

namespace ReflectionEmailService.Models
{
    public class EmailRequest
    {
        public List<string> coworkers { get; set; }
        public string mailtext { get; set; }
        public string mailto { get; set; }
        public string type { get; set; }
        public string footer { get; set; }
        public string emailbody { get; set; }
        public string subject { get; set; }
        public string status { get; set; }
    }
}
