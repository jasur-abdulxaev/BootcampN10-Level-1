using N37_HT1.Models;

namespace N37_HT1.Services.Interfaces;

// IEmailSenderService.cs
public interface IEmailSenderService
{
    Task SendEmailAsync(IEnumerable<EmailMessage> messages); // ← list
}