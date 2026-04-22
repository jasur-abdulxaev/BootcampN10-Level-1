using N53_HT1.Models;
using System.Linq.Expressions;

namespace N53_HT1.Interfaces;

public interface IOrderService
{
    IQueryable<Order> Get(Expression<Func<Order, bool>> predicate);

    ValueTask<Order> CreateAsync(Order order);
}
