using FirstApi.Models;

namespace FirstApi.Services.Interfaces;

public interface IUserService
{
    List<User> GetAll();
    User? GetById(Guid id);
    User Create(User user);
    User? Update(User user);
}