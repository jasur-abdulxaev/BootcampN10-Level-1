namespace N41_HT1.Services.Interfaces;

public interface ISafeQueue<TItem>
{
    void Enqueue(TItem item);
    TItem Dequeue();
}
