namespace ReflectionFeedback.Api.Models
{
    public class Feedback
    {
        public long id { get; set; }
        public string userid { get; set; }
        public string question { get; set; }
        public string assigned { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string createtimestamp { get; set; }
        public string updatetimestamp { get; set; }

    }
}
