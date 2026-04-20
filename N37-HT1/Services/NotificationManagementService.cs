using N37_HT1.Services.Interfaces;

namespace N37_HT1.Services;

public class NotificationManagementService : INotificationManagementService
{
    private readonly IUserService _userService;
    private readonly IEmailService _emailService;
    private readonly IEmailTemplateService _emailTemplateService;

    // IEmailSenderService — olib tashlandi!

    public NotificationManagementService(
        IUserService userService,
        IEmailService emailService,
        IEmailTemplateService emailTemplateService)
    {
        _userService = userService;
        _emailService = emailService;
        _emailTemplateService = emailTemplateService;
    }

    public async Task NotifyUsers()
    {
        var users = _userService.GetUsers();
        var templates = _emailTemplateService.GetTemplates(users);
        var messages = _emailService.GetMessages(templates, users);
        await _emailService.SendMessagesAsync(messages); // ← EmailService orqali
    }
}