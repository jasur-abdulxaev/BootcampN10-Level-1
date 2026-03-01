class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }

    public User(string firstName, string lastName, string middleName)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }

    public override bool Equals(object? obj)
    {
        if (obj is User other)
            return FirstName == other.FirstName
                && LastName == other.LastName
                && MiddleName == other.MiddleName;
        return false;
    }

    public override int GetHashCode() => HashCode.Combine(FirstName, LastName, MiddleName);

    public override string ToString() => $"{FirstName} {LastName} {MiddleName}";
}

class Program
{
    static void Main()
    {
        Queue<User> queue = new Queue<User>();

        queue.Enqueue(new User("Peter", "Michael", "Brown"));
        queue.Enqueue(new User("John", "David", "Smith"));
        queue.Enqueue(new User("Mary", "Anne", "Jones"));
        queue.Enqueue(new User("G'ishmat", "G'ishmatov", "G'ishmatovich"));

        Console.Write("Ismingizni kiriting: ");
        string firstName = Console.ReadLine();

        Console.Write("Familiyangizni kiriting: ");
        string lastName = Console.ReadLine();

        Console.Write("Sharifingizni kiriting: ");
        string middleName = Console.ReadLine();

        User newUser = new User(firstName, lastName, middleName);

        if (queue.Contains(newUser))
        {
            Console.WriteLine($"\n{firstName}, uje navbatdasanku!");
        }
        else
        {
            queue.Enqueue(newUser);
            Console.WriteLine("\nNavbatga qo'shildingiz! Hozirgi navbat:\n");

            int index = 1;
            foreach (var user in queue)
            {
                Console.WriteLine($"    {index}. {user}");
                index++;
            }
        }

    }
}