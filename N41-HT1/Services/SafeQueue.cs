using N41_HT1.Services.Interfaces;

namespace N41_HT1.Services;

public class SafeQueue<TItem> : ISafeQueue<TItem>
{
    private List<TItem> _items;
    private readonly object _locker = new object();

    public SafeQueue()
    {
        _items = new List<TItem>();
    }

    public TItem Dequeue()
    {
        lock (_locker)
        {
            var target = _items.FirstOrDefault();
            if (target is not null)
            {
                _items.Remove(target);
                return target;
            }

            throw new InvalidOperationException("Collection has 0 element");
        }
    }

    public void Enqueue(TItem item)
    {
        lock (_locker)
        {
            if (item == null)
                throw new ArgumentNullException("Item is null");

            _items.Add(item);
        }
    }
}
