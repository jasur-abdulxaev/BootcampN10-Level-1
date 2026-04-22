using FirstApi.Models;

namespace FirstApi.DataAcces;

public interface IDataContext
{
    List<User> Users { get; }
    List<Order> Orders { get; }
}