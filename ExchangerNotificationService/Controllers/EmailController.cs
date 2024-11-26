using ExchangerNotificationService.Models;
using ExchangerNotificationService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExchangerNotificationService.Controllers
{
    [ApiController]
	[Route("api/[controller]")]
	public class EmailController : ControllerBase
	{
		private readonly IEmailService _emailService;

		public EmailController(IEmailService emailService)
		{
			_emailService = emailService;
		}

		[HttpPost("send")]
		public IActionResult SendEmail([FromBody] EmailDTO request)
		{
			try
			{
				_emailService.SendEmail(request.RecipientEmail, request.Subject, request.Body);
				return Ok(new { Message = "Email успешно отправлен!" });
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = $"Ошибка: {ex.Message}" });
			}
		}
	}
}
