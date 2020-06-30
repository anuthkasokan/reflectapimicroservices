namespace ReflectionFeedback.Api.Models
{
    internal class Notification
    {
        //{id:1,notification:"You are using a growth mindset more often than a fixed mindset.",notificationType:"feedback",userid:"Admin"},
        internal long id { get; set; }
        internal string notification { get; set; }
        internal string notificationtype { get; set; }
        internal string userid { get; set; }

    }
}
