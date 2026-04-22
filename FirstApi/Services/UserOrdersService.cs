using FirstApi.Models;
using FirstApi.Services.Interfaces;

namespace FirstApi.Services;

public class UserOrdersService : IUserOrdersService
{
    private readonly IOrderService _orderService;

    public UserOrdersService(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public List<Order> GetOrdersByUserId(Guid userId)
        => _orderService.GetAll()
                        .Where(o => o.UserId == userId)
                        .ToList();
}