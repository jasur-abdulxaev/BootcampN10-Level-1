using N52_HT1.Models;

namespace N52_HT1.Services.Interfaces;

public interface IAccountService
{
    ServiceResult<User> Register(User user);
    ServiceResult<User> GetById(Guid id);
    ServiceResult<List<User>> GetAll();
    ServiceResult<User> UpdateUser(User user);
    ServiceResult DeleteUser(Guid id);
}
