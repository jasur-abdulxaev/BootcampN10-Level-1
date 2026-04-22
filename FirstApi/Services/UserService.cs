using FirstApi.DataAcces;
using FirstApi.Models;
using FirstApi.Services.Interfaces;

namespace FirstApi.Services;

public class UserService : IUserService
{
    private readonly IDataContext _context;

    public UserService(IDataContext context)
    {
        _context = context;
    }

    public List<User> GetAll()
        => _context.Users;

    public User? GetById(Guid id)
        => _context.Users.FirstOrDefault(u => u.Id == id);

    public User Create(User user)
    {
        user.Id = Guid.NewGuid();
        _context.Users.Add(user);
        return user;
    }

    public User? Update(User user)
    {
        var existing = _context.Users.FirstOrDefault(u => u.Id == user.Id);
        if (existing is null) return null;

        existing.FirstName = user.FirstName;
        existing.LastName = user.LastName;
        existing.EmailAddress = user.EmailAddress;
        existing.Password = user.Password;

        return existing;
    }
}