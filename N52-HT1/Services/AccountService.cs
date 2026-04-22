using N52_HT1.Models;
using N52_HT1.Services.Interfaces;

namespace N52_HT1.Services;

// Barcha operatsiyalarni coordinate qiladi
// UserFoundationService + biznes logika
public class AccountService : IAccountService
{
    private readonly IUserFoundationService _userFoundation;

    public AccountService(IUserFoundationService userFoundation)
    {
        _userFoundation = userFoundation;
    }

    public ServiceResult<User> Register(User user)
    {
        // Kelajakda: validatsiya, role berish, audit log va boshqalar shu yerda
        return _userFoundation.AddUser(user);
    }

    public ServiceResult<User> GetById(Guid id)
        => _userFoundation.GetById(id);

    public ServiceResult<List<User>> GetAll()
        => _userFoundation.GetAll();

    public ServiceResult<User> UpdateUser(User user)
        => _userFoundation.UpdateUser(user);

    public ServiceResult DeleteUser(Guid id)
        => _userFoundation.DeleteUser(id);
}
