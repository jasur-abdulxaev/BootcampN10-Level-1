using N36_T3.Models;

namespace N36_T3.Services;

public class UserService
{
    private List<User> _users = new List<User>();

    public void CreateUser(User user)
    {
        _users.Add(user);
    }

    public List<User> GetUsers()
    {
        return _users;
    }

    public User GetUser(Guid id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    public void UpdateUser(User updatedUser)
    {
        var foundedUser = _users.FirstOrDefault(u => u.Id == updatedUser.Id);

        if (foundedUser != null)
        {
            foundedUser.FirstName = updatedUser.FirstName;
            foundedUser.LastName = updatedUser.LastName;
        }
    }

    public void DeleteUser(Guid id)
    {
        var foundedUser = _users.FirstOrDefault(u => u.Id == id);
        if (foundedUser != null)
        {
            _users.Remove(foundedUser);
        }
    }
}
