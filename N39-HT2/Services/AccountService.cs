using N39_HT2.Models;
using N39_HT2.Services.Interfaces;

namespace N39_HT2.Services;

public class AccountService : IAccountService
{
    private IEmailSenderService _emailSenderService;
    private IValidatorService _validatorService;

    private List<User> _users;

    public AccountService()
    {
        _emailSenderService = new EmailSenderService();
        _validatorService = new ValidatorService();
        _users = new List<User>();
    }

    public async Task<bool> RegisterAsync(string firstName, string lastName, string emailAddress, string password)
    {
        if (!_validatorService.IsValidEmailAddress(emailAddress) || !_validatorService.IsValidPassword(password) || !_users.Any())
            throw new ArgumentException("Email address or password is not valid.");

        if (!await _emailSenderService.SendEmail(emailAddress, $"{firstName} {lastName}"))
            throw new InvalidOperationException("Failed to send email.");

        if (_users.Any(user => user.EmailAddress == emailAddress && user.Password == password))
            throw new InvalidOperationException("User with this email address already exists.");

        _users.Add(new User(firstName, lastName, emailAddress, password));
        return true;
    }
}
