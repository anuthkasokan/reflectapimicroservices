namespace ReflectionEmailService.Models
{
    internal class envSettings
    {
        internal string ConnectionString { get; set; }
        internal string DbName { get; set; }
        internal string emailTemplateCollection { get; set; }
        internal string emailRequestCollection { get; set; }
        internal int smtpPort { get; set; }
        internal string smtpHost { get; set; }
        internal string mailCredUsername { get; set; }
        internal string mailCredPassword { get; set; }
        internal string userapibaseurl { get; set; }

    }
}
