class User
{
    private string _fullName;

    private string _firstName;
    private string _lastName;
    private string _middleName;

    public string FirstName
    {
        get => _firstName;
        set
        {
            _firstName = value;
            _fullName = $"{_firstName} {_lastName} {_middleName}";
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            _lastName = value;
            _fullName = $"{_firstName} {_lastName} {_middleName}";
        }
    }

    public string MiddleName
    {
        get => _middleName;
        set
        {
            _middleName = value;
            _fullName = $"{_firstName} {_lastName} {_middleName}";
        }
    }

    public string FullName
    {
        get => _fullName;
    }

    public User(string firstName, string lastName, string middleName)
    {
        _firstName = firstName;
        _lastName = lastName;
        _middleName = middleName;
        _fullName = $"{_firstName} {_lastName} {_middleName}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is User other)
            return GetHashCode() == other.GetHashCode();
        return false;
    }

    public override int GetHashCode() => HashCode.Combine(FirstName, LastName, MiddleName);

    public override string ToString() => FullName;
}

class Program
{
    static void Main()
    {
        User user1 = new User("John", "Smith", "David");
        User user2 = new User("John", "Smith", "David");

        Console.WriteLine($"User 1: {user1}");
        Console.WriteLine($"User 2: {user2}");
        Console.WriteLine();
        Console.WriteLine($"User 1 HashCode: {user1.GetHashCode()}");
        Console.WriteLine($"User 2 hashCode: {user2.GetHashCode()}");
        Console.WriteLine();
        Console.WriteLine($"Ular Tengmi: {user1.Equals(user2)}\n");

        //ism ozgarganda fullName avtomatik yangilanadi
        user1.FirstName = "Peter";
        Console.WriteLine($"Usr 1 o'zgartirilgan: {user1}");
        Console.WriteLine($"Tengmi: {user1.Equals(user2)}");
    }
}
