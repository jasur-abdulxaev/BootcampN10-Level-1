
class Program
{
    static void Main()
    {
        var numbers = new List<int> { 11, 15, 17, 20, 23, 29, 30, 90, 37 };

        var primeNumbers = numbers.Where(n => IsPrime(n))
            .OrderByDescending(n => n)
            .ToList();

        foreach (var prime in primeNumbers)
        {
            Console.WriteLine(prime);
        }
    }

    static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;
        for (int i = 3; i <= Math.Sqrt(number); i += 2)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}