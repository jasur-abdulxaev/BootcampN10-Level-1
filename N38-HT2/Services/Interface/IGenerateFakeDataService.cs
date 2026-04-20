using N38_HT2.Models;

namespace N38_HT2.Services.Interface;

public interface IGenerateFakeDatService
{
    List<Employee> GenerateFakeEmployees(int count = 1);
    List<Order> GenerateFakeOrders(int count = 1);
    List<UserAddress> GenerateFakeUserAddress(int count = 1);
    List<BlogPost> GenerateFakeBlogPosts(int count = 1);
    List<WeatherReport> GenerateFakeWeatherReports(int count = 1);
}
