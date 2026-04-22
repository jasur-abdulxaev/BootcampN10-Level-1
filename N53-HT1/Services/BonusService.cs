using N53_HT1.DataAccess;
using N53_HT1.Interfaces;
using N53_HT1.Models;
using System.Linq.Expressions;

namespace N53_HT1.Services;

public class BonusService : IBonusService
{
    private readonly IDataContext _context;

    public BonusService(IDataContext context)
    {
        _context = context;
    }

    public async ValueTask<Bonus> CreateAsync(Bonus bonus)
    {
        var entity = await _context.Bonuses.AddAsync(bonus);

        await _context.SaveChangesAsync();

        return entity.Entity;
    }

    public IQueryable<Bonus> Get(Expression<Func<Bonus, bool>> predicate)
        => _context.Bonuses.Where(predicate.Compile()).AsQueryable();

    public async ValueTask<Bonus> UpdateAsync(Bonus bonus)
    {
        var found = _context.Bonuses.FirstOrDefault(x => x.Id == bonus.Id);

        if (found is null)
            throw new Exception("Bonus not fount.");

        found.Amount = bonus.Amount;

        await _context.SaveChangesAsync();

        return bonus;
    }
}
