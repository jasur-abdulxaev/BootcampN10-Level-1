//  RegistrationService
//  UserService + UserCredentialsService ni
//  birlashtirib ro'yxatdan o'tkazadi

public class RegistrationService
{
    // Parameterized constructor orqali inject qilinadi (AccountService pattern)
    private readonly IUserService _userService;
    private readonly IUserCredentialsService _credentialsService;

    public RegistrationService(
        IUserService userService,
        IUserCredentialsService credentialsService)
    {
        _userService = userService;
        _credentialsService = credentialsService;
    }

    // ── Register ──────────────────────────────
    // 1) UserService orqali user yaratadi
    // 2) UserCredentialsService orqali parol saqlaydi
    // Ikkalasi ham muvaffaqiyatli bo'lsa true, istisno chiqsa false
    public bool Register(
        string firstName,
        string lastName,
        string emailAddress,
        string password)
    {
        try
        {
            var user = _userService.Add(firstName, lastName, emailAddress);
            _credentialsService.Add(user.Id, password);
            return true;
        }
        catch (Exception ex)
        {
            // Xato sababini ko'rsatish (debug uchun)
            Console.WriteLine($"  [Register xato] {ex.Message}");
            return false;
        }
    }
}