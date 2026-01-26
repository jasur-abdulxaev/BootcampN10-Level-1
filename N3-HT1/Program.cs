using System.Text;

class Program
{
    static void Main()
    {
        string numbers = "1234567890";
        string letters = "abcdefghijklmnopqrstuvwxyz";
        string symbols = "!@#$%^&*";

        Console.Write("Sonlar qatnashsinmi? (y/n): ");
        char numbersA = GetYesNo();

        Console.Write("Harflar qatnashsinmi? (y/n): ");
        char lettersA = GetYesNo();

        Console.Write("Simvollar qatnashsinmi? (y/n): ");
        char symbolsA = GetYesNo();

        Console.Write("Password uzunligi: ");
        int len = GetPositiveNumber();

        Random rand = new Random();
        var allCharacters = new StringBuilder();
        var password = new StringBuilder();

        if (numbersA == 'y') allCharacters.Append(numbers);
        if (lettersA == 'y') allCharacters.Append(letters);
        if (symbolsA == 'y') allCharacters.Append(symbols);

        if (allCharacters.Length == 0)
        {
            Console.WriteLine("Siz kamida bittasini tanlashingiz kerak!");
            return;
        }

        // Har turdagi belgidan kamida bittasini qo'shish
        if (numbersA == 'y') password.Append(numbers[rand.Next(numbers.Length)]);
        if (lettersA == 'y') password.Append(letters[rand.Next(letters.Length)]);
        if (symbolsA == 'y') password.Append(symbols[rand.Next(symbols.Length)]);

        // Qolgan belgilarni random tarzda to'ldirish
        for (int i = password.Length; i < len; i++)
        {
            int next = rand.Next(allCharacters.Length);
            password.Append(allCharacters[next]);
        }

        // Parolni aralashtirish
        var passwordChars = password.ToString().ToCharArray();
        passwordChars = passwordChars.OrderBy(x => rand.Next()).ToArray();
        password.Clear();
        password.Append(passwordChars);

        Console.WriteLine($"Your password is: {password}");
    }

    // Foydalanuvchidan y/n kiritishni xavfsiz olish
    static char GetYesNo()
    {
        while (true)
        {
            string input = Console.ReadLine().ToLower();
            if (!string.IsNullOrEmpty(input))
            {
                char c = input[0];
                if (c == 'y' || c == 'n') return c;
            }
            Console.Write("Faqat 'y' yoki 'n' kiriting: ");
        }
    }

    // Musbat butun son olish
    static int GetPositiveNumber()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
                return number;
            Console.Write("Iltimos, musbat son kiriting: ");
        }
    }
}
