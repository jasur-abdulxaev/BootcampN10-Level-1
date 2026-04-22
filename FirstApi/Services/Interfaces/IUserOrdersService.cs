using FirstApi.Models;

namespace FirstApi.Services.Interfaces;

public interface IUserOrdersService
{
    List<Order> GetOrdersByUserId(Guid userId);
}