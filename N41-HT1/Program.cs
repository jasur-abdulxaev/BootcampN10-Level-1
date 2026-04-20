
using N41_HT1.Services;

var queue = new SafeQueue<int>();

var tasks = new List<Task>()
{
    new (() => queue.Enqueue(1)),
    new (() => queue.Enqueue(4)),
    new (() => queue.Enqueue(5)),
    new (() => queue.Enqueue(23))
};

Parallel.ForEach(tasks, task => task.Start());
await Task.WhenAll(tasks);


Console.WriteLine(queue.Dequeue()); //1
Console.WriteLine(queue.Dequeue()); //4
Console.WriteLine(queue.Dequeue()); //5
Console.WriteLine(queue.Dequeue()); //23