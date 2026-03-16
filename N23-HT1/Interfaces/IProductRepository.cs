using N23_HT1.Dto;
using N23_HT1.Models;

namespace N23_HT1.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetTopProductsAsync(int count);
        Task<IEnumerable<Product>> GetByFilterAsync(ProductFilterDto filter);
        Task<Product> AddAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
        Task<int> GetCountAsync();
        Task<bool> ExistsAsync(int id);
    }
}