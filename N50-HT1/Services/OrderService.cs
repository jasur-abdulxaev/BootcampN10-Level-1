using N50_HT1.Data;
using N50_HT1.Models.Entities;
using N50_HT1.Services.Interfaces;

namespace N50_HT1.Services;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public List<Order> GetAll() => _context.Orders.ToList();

    public List<Order> GetByUserId(int userId) =>
        _context.Orders.Where(o => o.UserId == userId).ToList();
}