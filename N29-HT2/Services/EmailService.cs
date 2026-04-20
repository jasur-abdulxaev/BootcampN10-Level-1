using System.Net;
using System.Net.Mail;

namespace N29_HT2.Services;

public class EmailService
{
    public SmtpClient SmtpClientInstance { get; init; }

    public EmailService()
    {
        SmtpClientInstance = new SmtpClient("smtp.gmail.com", 587);
        SmtpClientInstance.Credentials =
            new NetworkCredential("sultonbek.rakhimov.recovery@gmail.com", "szabguksrhwsbtie");
        SmtpClientInstance.EnableSsl = true;
    }
    public Task<bool> SendAsync(string receiverEmailAddress, string subject, string body, string fullname)
    {
        return Task.Run(async () =>
        {
            var result = true;
            try
            {
                var smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("sultonbek.rakhimov.recovery@gmail.com", "szabguksrhwsbtie");
                smtp.EnableSsl = true;

                var mail = new MailMessage("sultonbek.rakhimov@gmail.com", receiverEmailAddress);
                mail.Subject = subject;
                mail.Body = body.Replace("{{Employee}}", fullname);

                await smtp.SendMailAsync(mail);
            }
            catch (Exception e)
            {
                result = false;
            }

            return result;
        });
    }
}

