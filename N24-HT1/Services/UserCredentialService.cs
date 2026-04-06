using System.Text.RegularExpressions;

public class UserCredentialsService : IUserCredentialsService
{
    private readonly List<UserCredentials> _credentials = [];

    // Parol kuchlilik qoidalari:
    //   - kamida 8 ta belgi
    //   - kamida 1 ta katta harf
    //   - kamida 1 ta raqam
    private static readonly Regex StrongPasswordRegex =
        new(@"^(?=.*[A-Z])(?=.*\d).{8,}$", RegexOptions.Compiled);

    // ── Add ───────────────────────────────────
    public UserCredentials Add(Guid userId, string password)
    {
        if (!StrongPasswordRegex.IsMatch(password))
            throw new ArgumentException(
                "Parol kuchsiz! Kamida: 8 ta belgi, 1 ta katta harf, 1 ta raqam bo'lishi shart.");

        var credential = new UserCredentials
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Password = password     // Real loyihada: BCrypt.Hash(password)
        };

        _credentials.Add(credential);
        return credential;
    }

    // ── GetByUserId ───────────────────────────
    public UserCredentials? GetByUserId(Guid userId)
        => _credentials.FirstOrDefault(c => c.UserId == userId);
}