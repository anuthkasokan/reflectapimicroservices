namespace ReflectionFeedback.Api.Models
{
    internal class MongoDbSettings
    {
        internal string ConnectionString { get; set; }
        internal string DbName { get; set; }
        internal string FeedbackCollection { get; set; }
        internal string FeedbackReplyCollection { get; set; }
        internal string ErrorLogsCollection { get; set; }
    }
}
