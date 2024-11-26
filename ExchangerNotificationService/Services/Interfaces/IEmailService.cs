namespace ExchangerNotificationService.Services.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(string recipientEmail, string subject, string body);
    }
}
