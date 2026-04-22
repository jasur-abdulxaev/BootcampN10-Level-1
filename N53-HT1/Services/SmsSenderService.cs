using N53_HT1.Interfaces;

namespace N53_HT1.Services;

public class SmsSenderService : INotificationService
{
    public ValueTask SendAsync(Guid userId, string content)
    {
        Console.WriteLine($"Sending sms to {userId} with content: {content}");

        return new ValueTask();
    }
}
