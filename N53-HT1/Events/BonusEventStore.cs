using N53_HT1.Models;

namespace N53_HT1.Events;

public class BonusEventStore
{
    public event Func<Bonus, ValueTask>? BonusAchievedEvent;

    public async ValueTask CreateBonusAchievedEventAsync(Bonus bonus)
    {
        if (BonusAchievedEvent != null)
            BonusAchievedEvent?.Invoke(bonus);
    }
}

