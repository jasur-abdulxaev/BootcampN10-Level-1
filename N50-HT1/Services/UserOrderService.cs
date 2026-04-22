using N50_HT1.Models.DTOs;
using N50_HT1.Services.Interfaces;

namespace N50_HT1.Services;

public class UserOrderService : IUserOrderService
{
    private readonly IUserService _userService;
    private readonly IOrderService _orderService;

    public UserOrderService(IUserService userService, IOrderService orderService)
    {
        _userService = userService;
        _orderService = orderService;
    }

    public UserOrderDto? GetUserOrdersByUserId(int userId)
    {
        var user = _userService.GetById(userId);

        if (user is null) return null;

        var orders = _orderService.GetByUserId(userId);

        return new UserOrderDto
        {
            UserId = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Orders = orders.Select(o => new OrderDto
            {
                Id = o.Id,
                ProductName = o.ProductName,
                TotalPrice = o.TotalPrice,
                CreatedAt = o.CreatedAt,
            }).ToList()
        };
    }
}