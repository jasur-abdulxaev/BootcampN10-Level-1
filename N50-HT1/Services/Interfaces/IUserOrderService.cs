using N50_HT1.Models.DTOs;

namespace N50_HT1.Services.Interfaces;

public interface IUserOrderService
{
    UserOrderDto? GetUserOrdersByUserId(int userId);
}
