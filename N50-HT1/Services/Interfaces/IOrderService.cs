using N50_HT1.Models.Entities;

namespace N50_HT1.Services.Interfaces;

public interface IOrderService
{
    List<Order> GetAll();
    List<Order> GetByUserId(int userId);
}
