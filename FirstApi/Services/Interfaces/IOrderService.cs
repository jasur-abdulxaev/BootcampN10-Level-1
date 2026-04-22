using FirstApi.Models;

namespace FirstApi.Services.Interfaces;

public interface IOrderService
{
    List<Order> GetAll();
    Order? GetById(Guid id);
    Order Create(Order order);
    Order? Update(Order order);
}