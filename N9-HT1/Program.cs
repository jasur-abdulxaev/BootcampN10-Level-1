
using System.Text.RegularExpressions;
Console.OutputEncoding = System.Text.Encoding.UTF8;

var emails = new[]
{
    "azizbek10@gmail.com",         // valid
    "ilhom@.com",                  // invalid
    "abdug'ani@example.com",       // invalid
    "abdurahmon@mail.ru",          // valid
    "firdavs.doter@email.uz",      // valid
    "jasurabdulxaev@gmail.com",    // valid
    "user_name@mail.co.uk",        // valid - subdomain
    "user+tag@gmail.com",          // valid - plus belgisi
    "user-name@example.com",       // valid - tire
    "..user@gmail.com",            // invalid - bosh nuqta
    "user@domain..com"             // invalid - ketma-ket nuqta
};

var pattern = @"^[a-zA-Z0-9]([a-zA-Z0-9._+\-]*[a-zA-Z0-9])?@[a-zA-Z0-9]([a-zA-Z0-9\-]*[a-zA-Z0-9])?(\.[a-zA-Z]{2,})+$";

var regEx = new Regex(pattern);

Console.WriteLine("╔══════════════════════════════════════════╗");
Console.WriteLine("║         Email Validator Natijalar        ║");
Console.WriteLine("╚══════════════════════════════════════════╝\n");

int validCount = 0, invalidCount = 0;

foreach (var email in emails)
{
    if (regEx.IsMatch(email))
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"  ✔  {email,-30} → Valid");
        validCount++;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"  ✔  {email,-30} → Invalid");
        invalidCount++;
    }
    Console.ResetColor();
}

Console.WriteLine("\n──────────────────────────────────────────");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine($"  Jami: {emails.Length} | ✔ Valid: {validCount} | ✘ Invalid: {invalidCount}");
Console.ResetColor();