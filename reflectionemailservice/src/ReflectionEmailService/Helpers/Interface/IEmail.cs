namespace ReflectionEmailService.Helpers.Interface
{
    internal interface IEmail
    {
        void SendEmail(string mailto, string emailBody, string subject);
    }
}
