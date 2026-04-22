using N53_HT1.Models;
using System.Linq.Expressions;

namespace N53_HT1.Interfaces;

public interface IBonusService
{
    IQueryable<Bonus> Get(Expression<Func<Bonus, bool>> predicate);

    ValueTask<Bonus> CreateAsync(Bonus bonus);

    ValueTask<Bonus> UpdateAsync(Bonus bonus);
}
