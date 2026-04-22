using N52_HT1.Models;

namespace N52_HT1.Events;

public class AccountEventStore
{
    // User bu eventni raise qiladi
    // Account notificationService bu eventga subscribe bo'ladi
    public event Action<User>? OnUserCreated;

    public void RaiseUserCreated(User user)
    {
        OnUserCreated?.Invoke(user);
    }
}
