using N39_HT2.Services;

var accountService = new AccountService();

try
{
    var result = await accountService.RegisterAsync("Jasur", "Abdulhayev", "jasurabdulxaev@gmail.com", "J@sur1223");
    if (result)
        Console.WriteLine("Muvaffaqqiatli ro'yhatdan o'tdingiz!");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Argument xatosi: {ex.Message}");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Amal xatosi: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}