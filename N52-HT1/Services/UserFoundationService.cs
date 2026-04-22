using N52_HT1.Data.DataAcces;
using N52_HT1.Events;
using N52_HT1.Models;
using N52_HT1.Services.Interfaces;

namespace N52_HT1.Services;

// Faqat CRUD + event raise qiladi. Email haqida hech narsa bilmaydi.
public class UserFoundationService : IUserFoundationService
{
    private readonly IDataContext _context;
    private readonly AccountEventStore _eventStore;

    public UserFoundationService(IDataContext context, AccountEventStore eventStore)
    {
        _context = context;
        _eventStore = eventStore;
    }

    public ServiceResult<User> AddUser(User user)
    {
        var exists = _context.Users.Any(u => u.Email == user.Email);
        if (exists)
            return ServiceResult<User>.Failure(MessageConstants.User.AlreadyExists);

        user.Id = Guid.NewGuid();
        user.CreatedAt = DateTime.UtcNow;

        _context.Users.Add(user);
        _context.SaveChanges();

        // Email yuborish bilmaymiz — faqat event raise qilamiz
        _eventStore.RaiseUserCreated(user);

        return ServiceResult<User>.Success(user, MessageConstants.User.Created);
    }

    public ServiceResult<User> GetById(Guid id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);

        return user is null
            ? ServiceResult<User>.Failure(MessageConstants.User.NotFound)
            : ServiceResult<User>.Success(user);
    }

    public ServiceResult<List<User>> GetAll()
    {
        return ServiceResult<List<User>>.Success(_context.Users);
    }

    public ServiceResult<User> UpdateUser(User updated)
    {
        var existing = _context.Users.FirstOrDefault(u => u.Id == updated.Id);
        if (existing is null)
            return ServiceResult<User>.Failure(MessageConstants.User.NotFound);

        existing.FirstName = updated.FirstName;
        existing.LastName = updated.LastName;
        existing.Email = updated.Email;
        existing.Password = updated.Password;

        _context.SaveChanges();

        return ServiceResult<User>.Success(existing, MessageConstants.User.Updated);
    }

    public ServiceResult DeleteUser(Guid id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user is null)
            return ServiceResult.Failure(MessageConstants.User.NotFound);

        _context.Users.Remove(user);
        _context.SaveChanges();

        return ServiceResult.Success(MessageConstants.User.Deleted);
    }
}
