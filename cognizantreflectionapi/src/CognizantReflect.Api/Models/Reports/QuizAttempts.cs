namespace CognizantReflect.Api.Models.Reports
{
    public class QuizAttempts
    {
        public int id { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public string userId { get; set; }
        public string date { get; set; }
        public string meetingTitle { get; set; }
        public string scoring { get; set; }
        public string comments { get; set; }
        public int attempt { get; set; }
        public string type { get; set; }
        public string selectedoptions { get; set; }
    }
}
