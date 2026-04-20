using N37_HT1.Models;
namespace N37_HT1.Services.Interfaces;

public interface IEmailService
{
    IEnumerable<EmailMessage> GetMessages(IEnumerable<EmailTemplate> templates, IEnumerable<User> users);
    Task SendMessagesAsync(IEnumerable<EmailMessage> messages); // ← qo'shiladi
}