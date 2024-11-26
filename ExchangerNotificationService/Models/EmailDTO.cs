using System.ComponentModel.DataAnnotations;

namespace ExchangerNotificationService.Models
{
	public class EmailDTO
	{
		[Required] 
		[EmailAddress] 
		public string RecipientEmail { get; set; }

		[Required] 
		public string Subject { get; set; }

		[Required] 
		public string Body { get; set; }
	}
}
