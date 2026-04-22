using N53_HT1.Models;
using System.Linq.Expressions;

namespace N53_HT1.Interfaces;

public interface IUserService
{
    IQueryable<User> Get(Expression<Func<User, bool>> predicate);

    ValueTask<User> CreateAsync(User user);
}
