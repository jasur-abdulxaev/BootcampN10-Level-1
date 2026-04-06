public class UserService : IUserService
{
    // In-memory storage (real loyihada repository inject qilinadi)
    private readonly List<User> _users = [];

    // ── Get ───────────────────────────────────
    // O'chirilmagan userlarni pageToken indeksidan boshlab pageSize ta qaytaradi
    public List<User> Get(int pageSize, int pageToken)
        => _users
            .Where(u => !u.IsDeleted)
            .Skip(pageToken)
            .Take(pageSize)
            .ToList();

    // ── Search ────────────────────────────────
    // firstName, lastName yoki emailda kalit so'z bo'lsa tanlaydi (case-insensitive)
    public List<User> Search(string searchKeyword, int pageSize, int pageToken)
    {
        var kw = searchKeyword.Trim();

        return _users
            .Where(u => !u.IsDeleted &&
                        (u.FirstName.Contains(kw, StringComparison.OrdinalIgnoreCase) ||
                         u.LastName.Contains(kw, StringComparison.OrdinalIgnoreCase) ||
                         u.EmailAddress.Contains(kw, StringComparison.OrdinalIgnoreCase)))
            .Skip(pageToken)
            .Take(pageSize)
            .ToList();
    }

    // ── Filter ────────────────────────────────
    // Nullable shartlar: qiymat berilsa filter qo'llanadi, null bo'lsa o'tkazib yuboriladi
    public List<User> Filter(UserFilterModel model)
    {
        var query = _users.Where(u => !u.IsDeleted);

        if (model.FirstName is not null)
            query = query.Where(u =>
                u.FirstName.Contains(model.FirstName, StringComparison.OrdinalIgnoreCase));

        if (model.LastName is not null)
            query = query.Where(u =>
                u.LastName.Contains(model.LastName, StringComparison.OrdinalIgnoreCase));

        return query
            .Skip(model.PageToken)
            .Take(model.PageSize)
            .ToList();
    }

    // ── Add ───────────────────────────────────
    // Email unique bo'lishini tekshirib yangi user yaratadi
    public User Add(string firstName, string lastName, string emailAddress)
    {
        bool emailExists = _users.Any(u =>
            u.EmailAddress.Equals(emailAddress, StringComparison.OrdinalIgnoreCase));

        if (emailExists)
            throw new InvalidOperationException(
                $"'{emailAddress}' email allaqachon ro'yxatda mavjud.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            EmailAddress = emailAddress,
            IsDeleted = false
        };

        _users.Add(user);
        return user;
    }

    // ── Update ────────────────────────────────
    // Id bo'yicha topib, hamma fieldlarini yangilaydi
    public User Update(User user)
    {
        var existing = _users.FirstOrDefault(u => u.Id == user.Id && !u.IsDeleted)
            ?? throw new KeyNotFoundException($"Id={user.Id} bo'yicha aktiv user topilmadi.");

        existing.FirstName = user.FirstName;
        existing.LastName = user.LastName;
        existing.EmailAddress = user.EmailAddress;

        return existing;
    }

    // ── Delete ────────────────────────────────
    // Soft delete: ma'lumotlar o'chirilmaydi, faqat IsDeleted = true
    public void Delete(Guid id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id && !u.IsDeleted)
            ?? throw new KeyNotFoundException($"Id={id} bo'yicha aktiv user topilmadi.");

        user.IsDeleted = true;
    }
}