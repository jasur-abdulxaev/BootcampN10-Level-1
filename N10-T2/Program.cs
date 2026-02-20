using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Random random = new Random();
int secretNumber = random.Next(1, 11);

Console.WriteLine("🎮 1 va 10 orasidagi sonni toping!");

while (true)
{
    Console.Write("Sonni kiriting: ");
    string input = Console.ReadLine()!;

    try
    {
        // int.Parse o'zi FormatException throw qiladi
        int guess = int.Parse(input);

        // Noto'g'ri son bo'lsa ArgumentOutOfRangeException
        if (guess != secretNumber)
            throw new ArgumentOutOfRangeException(nameof(guess), "You couldn't guess it");

        // To'g'ri topildi
        Console.WriteLine("🎉 Congrats! You guessed it");
        break;
    }
    catch (FormatException)
    {
        Console.WriteLine("❌ Not a number");
    }
    catch (ArgumentOutOfRangeException)
    {
        Console.WriteLine("❌ You couldn't guess it");
    }
}
