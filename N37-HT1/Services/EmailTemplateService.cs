using N37_HT1.Enums;
using N37_HT1.Models;
using N37_HT1.Services.Interfaces;

namespace N37_HT1.Services;

public class EmailTemplateService : IEmailTemplateService
{
    public IEnumerable<EmailTemplate> GetTemplates(IEnumerable<User> users)
    {
        foreach (var user in users)
        {
            string fullName = $"{user.FirstName} {user.LastName}";

            if (user.Status == Status.Registered)
            {
                yield return new EmailTemplate(
                    MessageConstants.RegisteredSubject.Replace("{{FullName}}", fullName),
                    MessageConstants.RegisteredSubject);
            }
            else if (user.Status == Status.Deleted)
            {
                yield return new EmailTemplate(
                    MessageConstants.DeletedBody.Replace("{{FullName}}", fullName),
                    MessageConstants.DeletedSubject);
            }
        }
    }
}
