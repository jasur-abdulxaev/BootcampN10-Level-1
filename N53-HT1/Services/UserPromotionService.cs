using N53_HT1.Events;
using N53_HT1.Interfaces;
using N53_HT1.Models;

namespace N53_HT1.Services;

public class UserPromotionService
{
    private BonusEventStore _eventStore;
    private IEnumerable<INotificationService> _notificationServices;

    public UserPromotionService(BonusEventStore eventStore,
        IEnumerable<INotificationService> notificationServices)
    {
        _eventStore = eventStore;

        _notificationServices = notificationServices;


        _eventStore.BonusAchievedEvent += HandleAchievedBonusEventAsync;
    }

    public async ValueTask HandleAchievedBonusEventAsync(Bonus bonus)
    {
        foreach (var notificationService in _notificationServices)
        {
            await notificationService.SendAsync(bonus.UserId, "Siz bonusga yetdingiz!!!");
        }
    }
}