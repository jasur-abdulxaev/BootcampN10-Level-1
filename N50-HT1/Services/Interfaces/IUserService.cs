using N50_HT1.Models.Entities;

namespace N50_HT1.Services.Interfaces;

public interface IUserService
{
    List<User> GetAll();
    User? GetById(int id);
}
