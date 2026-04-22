namespace N52_HT1.Services;

using global::N52_HT1.Events;
using global::N52_HT1.Models;
using global::N52_HT1.Services.Interfaces;

// EventStore dagi OnUserCreated eventini tinglaydi
// Va EmailSenderService orqali welcome email yuboradi
public class AccountNotificationService : IAccountNotificationService
{
    private readonly AccountEventStore _eventStore;
    private readonly IEmailSenderService _emailSenderService;
    private readonly ILogger<AccountNotificationService> _logger;

    public AccountNotificationService(
        AccountEventStore eventStore,
        IEmailSenderService emailSenderService,
        ILogger<AccountNotificationService> logger)
    {
        _eventStore = eventStore;
        _emailSenderService = emailSenderService;
        _logger = logger;
    }

    public void Subscribe()
    {
        _eventStore.OnUserCreated += HandleUserCreated;
        _logger.LogInformation("[AccountNotificationService] OnUserCreated eventiga subscribe bo'ldi.");
    }

    private void HandleUserCreated(User user)
    {
        _logger.LogInformation(
            "[AccountNotificationService] Yangi user aniqlandi: {Email}. Welcome email yuborilmoqda...",
            user.Email);

        _emailSenderService.SendWelcomeEmail(user);
    }
}
