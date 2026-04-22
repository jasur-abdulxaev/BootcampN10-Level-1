using N53_HT1.Events;
using N53_HT1.Interfaces;
using N53_HT1.Models;

namespace N53_HT1.Services;

public class UserBonusService
{
    private OrderEventStore _orderEventStore;
    private IUserService _userService;
    private IBonusService _bonusService;
    private BonusEventStore _bonusEventStore;
    private IEnumerable<INotificationService> _notificationServices;

    public UserBonusService(OrderEventStore orderEventStore,
         IUserService userService, IBonusService bonusService, BonusEventStore bonusEventStore,
        IEnumerable<INotificationService> notificationServices)
    {
        _orderEventStore = orderEventStore;


        _userService = userService;

        _bonusService = bonusService;

        _bonusEventStore = bonusEventStore;

        _notificationServices = notificationServices;


        _orderEventStore.OrderCreatedEvent += HandleOrderCreatedEventAsync;
    }

    public async ValueTask HandleOrderCreatedEventAsync(Order order)
    {
        // user va uni bonusini olish
        var user = _userService.Get(u => u.Id == order.UserId).FirstOrDefault();
        if (user is null)
            return; // user not found - nothing to do

        var bonus = _bonusService.Get(x => x.UserId == user.Id).FirstOrDefault();

        // ensure bonus exists
        if (bonus is null)
        {
            bonus = await _bonusService.CreateAsync(new Bonus(Guid.NewGuid(), 0, user.Id));
        }

        // safe digit count helper
        static int DigitCount(int value)
        {
            value = Math.Abs(value);
            if (value == 0) return 1;
            return (int)Math.Floor(Math.Log10(value)) + 1;
        }

        // tekshirish (count digits safely)
        var oldBonusLength = DigitCount(bonus.Amount);
        var newBonusLenght = DigitCount(bonus.Amount + order.Amount);

        // bonus ni update qilish
        var updatedBonus = new Bonus(bonus.Id, bonus.Amount + order.Amount, bonus.UserId);
        await _bonusService.UpdateAsync(updatedBonus);

        if (oldBonusLength < newBonusLenght)
        {
            await _bonusEventStore.CreateBonusAchievedEventAsync(updatedBonus);
            return;
        }

        // compute threshold (10^oldBonusLength)
        var threshold = (int)Math.Pow(10, oldBonusLength);

        foreach (var service in _notificationServices)
        {
            await service.SendAsync(user.Id, $"Bonus olish uchun yana {threshold - updatedBonus.Amount} qoldi :)");
        }

    }
}