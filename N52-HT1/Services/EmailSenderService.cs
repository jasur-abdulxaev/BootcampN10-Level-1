using N52_HT1.Models;
using N52_HT1.Services.Interfaces;

namespace N52_HT1.Services;

// Faqat email yuboradi. User qanday saqlangani bilmaydi.
public class EmailSenderService : IEmailSenderService
{
    private readonly ILogger<EmailSenderService> _logger;

    public EmailSenderService(ILogger<EmailSenderService> logger)
    {
        _logger = logger;
    }

    public void SendWelcomeEmail(User user)
    {
        // Real proyektda: SmtpClient yoki SendGrid ishlatiladi
        // Hozir: Console ga log qilamiz
        _logger.LogInformation(
            "[EMAIL] To: {Email} | Subject: {Subject} | Body: {Body}",
            user.Email,
            MessageConstants.Email.WelcomeSubject,
            MessageConstants.Email.WelcomeBody(user.FirstName));
    }
}
