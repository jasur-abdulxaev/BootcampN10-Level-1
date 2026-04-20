using N37_HT1.Models;
using N37_HT1.Services.Interfaces;

namespace N37_HT1.Services;

public class EmailService : IEmailService
{
    private readonly IEmailSenderService _emailSenderService;

    public EmailService(IEmailSenderService emailSenderService)
    {
        _emailSenderService = emailSenderService;
    }

    public IEnumerable<EmailMessage> GetMessages(IEnumerable<EmailTemplate> templates, IEnumerable<User> users)
    {
        foreach (var item in users.Zip(templates))
        {
            yield return new EmailMessage(
                item.Second.Subject,
                item.Second.Body,
                MessageConstants.SenderEmailAddress,
                item.First.EmailAddress
            );
        }
    }

    public async Task SendMessagesAsync(IEnumerable<EmailMessage> messages)
    {
        await _emailSenderService.SendEmailAsync(messages); // ← foreach yo'q
    }
}