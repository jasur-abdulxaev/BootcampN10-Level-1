using N53_HT1.Models;

namespace N53_HT1.Events;

public class OrderEventStore
{
    public event Func<Order, ValueTask>? OrderCreatedEvent;

    public async ValueTask CreateOrderAddedEventAsync(Order order)
    {
        if (OrderCreatedEvent == null)
            return;

        // Invoke handlers one-by-one so a failing handler won't prevent others from running.
        var invocationList = OrderCreatedEvent.GetInvocationList();
        foreach (var d in invocationList)
        {
            if (d is Func<Order, ValueTask> handler)
            {
                try
                {
                    await handler(order);
                }
                catch
                {
                    // Swallow exceptions here or add logging as appropriate.
                }
            }
        }
    }
}
