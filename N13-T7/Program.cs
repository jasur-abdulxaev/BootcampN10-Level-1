
class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public override string ToString() => $"{FirstName} {LastName}, {Age}";
}

class Program
{
    static void Main()
    {
        var users = new List<User>
        {
            new User { FirstName = "Alice", LastName = "Smith", Age = 30 },
            new User { FirstName = "Bob", LastName = "Johnson", Age = 25 },
            new User { FirstName = "Charlie", LastName = "Brown", Age = 35 },
            new User { FirstName = "Diana", LastName = "Prince", Age = 28 },
            new User { FirstName = "Eve", LastName = "Davis", Age = 22 }
        };

        var queue = new Queue<User>();
        foreach (var user in users)
            queue.Enqueue(user);

        bool isSameOrder = true;
        int index = 0;

        while (queue.Count > 0)
        {
            var fromQueue = queue.Dequeue();
            Console.WriteLine(fromQueue);

            if (fromQueue != users[index])
                isSameOrder = false;

            index++;
        }

        Console.WriteLine($"\nOutput: {isSameOrder}");
    }
}