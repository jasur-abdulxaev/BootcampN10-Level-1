using FirstApi.DataAcces;
using FirstApi.Models;
using FirstApi.Services.Interfaces;

namespace FirstApi.Services;

public class OrderService : IOrderService
{
    private readonly IDataContext _context;

    public OrderService(IDataContext context)
    {
        _context = context;
    }

    public List<Order> GetAll()
        => _context.Orders;

    public Order? GetById(Guid id)
        => _context.Orders.FirstOrDefault(o => o.Id == id);

    public Order Create(Order order)
    {
        order.Id = Guid.NewGuid();
        _context.Orders.Add(order);
        return order;
    }

    public Order? Update(Order order)
    {
        var existing = _context.Orders.FirstOrDefault(o => o.Id == order.Id);
        if (existing is null) return null;

        existing.Amount = order.Amount;
        existing.UserId = order.UserId;

        return existing;
    }
}