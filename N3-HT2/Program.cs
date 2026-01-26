using System.Text.RegularExpressions;

Console.WriteLine("Email Checker. 'q' yoki 'exit' yozib chiqishingiz mumkin.");

while (true)
{
    Console.Write("Enter your email: ");
    string email = Console.ReadLine();

    // Bo‘sh kiritish
    if (string.IsNullOrWhiteSpace(email)) 
    {
        Console.WriteLine("Bo‘sh email kiritdingiz. Qayta urinib ko‘ring.");
        continue;
    }

    // Chiqarish sharti
    if (email.ToLower() == "q" || email.ToLower() == "exit")
    {
        Console.WriteLine("Exiting program...");
        break;
    }

    // Kuchaytirilgan regex
    string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    Regex regex = new Regex(pattern);

    if (regex.IsMatch(email))
        Console.WriteLine("Valid email!");
    else
        Console.WriteLine("Invalid email!");
}