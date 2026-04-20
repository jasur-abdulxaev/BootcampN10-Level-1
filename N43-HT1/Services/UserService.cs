using N43_HT1.Models;
using N43_HT1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace N43_HT1.Services;

public class UserService : IUserService
{
    private List<User> _users;

    public UserService()
    {
        _users = new List<User>();
    }

    public User Create(User? user)
    {
        if (user != null)
        {
            _users.Add(user);
            return user;
        }
        throw new ArgumentNullException(nameof(user), "User is null");
    }

    public bool Delete(Guid id)
    {
        var foundedUser = _users.FirstOrDefault(user => user.Id == id);
        if (foundedUser != null)
        {
            _users.Remove(foundedUser);
            return true;
        }
        return false;
    }

    public User? Get(Guid id)
    {
        return _users.FirstOrDefault(user => user.Id == id);
    }

    public List<User> GetAll()
    {
        return _users.ToList();
    }

    public User Update(User user)
    {
        var foundedUser = Get(user.Id);
        if (foundedUser != null)
        {
            foundedUser.FirstName = user.FirstName;
            foundedUser.LastName = user.LastName;
            foundedUser.IsActive = user.IsActive;
            return foundedUser;
        }
        throw new ArgumentNullException($"User with id {user.Id} not found");
    }
}
