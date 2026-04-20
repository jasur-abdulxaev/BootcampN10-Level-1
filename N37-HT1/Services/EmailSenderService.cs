using N37_HT1.Models;
using N37_HT1.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace N37_HT1.Services;

public class EmailSenderService : IEmailSenderService
{
    public async Task SendEmailAsync(IEnumerable<EmailMessage> messages)
    {
        var smtp = new SmtpClient("smtp.gmail.com", 587);
        smtp.Credentials = new NetworkCredential("sultonbek.rakhimov.recovery@gmail.com", "szabguksrhwsbtie");
        smtp.EnableSsl = true;

        foreach (var message in messages)
        {
            var mail = new MailMessage(message.SenderAddress, message.ReceiverAddress);
            mail.Subject = message.Subject;
            mail.Body = message.Body;

            await smtp.SendMailAsync(mail);
        }
    }
}
