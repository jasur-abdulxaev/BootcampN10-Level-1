using FirstApi.Models;

namespace FirstApi.DataAcces;

public class AppFileContext : IDataContext
{
    public List<User> Users { get; } = new();
    public List<Order> Orders { get; } = new();
}