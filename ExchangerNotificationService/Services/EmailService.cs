using ExchangerNotificationService.Helpers;
using System.Net.Mail;
using System.Net;
using ExchangerNotificationService.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace ExchangerNotificationService.Services
{
    public class EmailService : IEmailService
	{
		private readonly EmailSettings _settings;

		public EmailService(IOptions<EmailSettings> emailSettings)
		{
			_settings = emailSettings.Value;
		}
		
		public void SendEmail(string recipientEmail, string subject, string body)
		{
			using var smtpClient = new SmtpClient(_settings.SmtpServer, _settings.SmtpPort)
			{
				Credentials = new NetworkCredential(_settings.SenderEmail, _settings.SenderPassword),
				EnableSsl = true
			};

			var mailMessage = new MailMessage
			{
				From = new MailAddress(_settings.SenderEmail),
				Subject = subject,
				Body = body,
				IsBodyHtml = true
			};
			mailMessage.To.Add(recipientEmail);

			smtpClient.Send(mailMessage);
		}
	}
}
