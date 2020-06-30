
namespace ReflectionFeedback.Api.Models
{
    public class FeedbackReply
    {
        public long id { get; set; }
        public string userid { get; set; }
        public long feedbackid { get; set; }
        public string feedback { get; set; }
        public string createtimestamp { get; set; }

    }
}
