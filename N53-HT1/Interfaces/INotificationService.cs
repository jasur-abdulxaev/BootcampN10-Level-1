namespace N53_HT1.Interfaces;

public interface INotificationService
{
    ValueTask SendAsync(Guid userId, string content);
}