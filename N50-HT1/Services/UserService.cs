using N50_HT1.Data;
using N50_HT1.Models.Entities;
using N50_HT1.Services.Interfaces;

namespace N50_HT1.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public List<User> GetAll() => _context.Users.ToList();

    public User? GetById(int id) => _context.Users.FirstOrDefault(u => u.Id == id);
}