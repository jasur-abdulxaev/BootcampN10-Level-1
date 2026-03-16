using N23_HT1.Dto;
using N23_HT1.Interfaces;
using N23_HT1.Models;

namespace N23_HT1.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products;
        private int _nextId;

        public ProductRepository()
        {
            _nextId = 1;
            _products = SeedData();
        }

        private List<Product> SeedData()
        {
            return new List<Product>
            {
                new Product("iPhone 12", 4, 60) { Id = _nextId++ },
                new Product("Samsung Galaxy S21", 4, 75) { Id = _nextId++ },
                new Product("Google Pixel 5", 4, 50) { Id = _nextId++ },
                new Product("OnePlus 9 Pro", 4, 60) { Id = _nextId++ },
                new Product("Xiaomi Mi 11", 4, 80) { Id = _nextId++ },
                new Product("Sony Xperia 1 III", 3, 40) { Id = _nextId++ },
                new Product("LG Wing", 3, 30) { Id = _nextId++ },
                new Product("Motorola Edge+", 3, 35) { Id = _nextId++ },
                new Product("Iphone 14", 5, 10) { Id = _nextId++ },
                new Product("Asus ROG Phone 5", 4, 70) { Id = _nextId++ }
            };
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult(_products.Where(p => p.IsActive).AsEnumerable());
        }

        public Task<Product> GetByIdAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id && p.IsActive);
            return Task.FromResult(product);
        }

        public Task<IEnumerable<Product>> GetTopProductsAsync(int count)
        {
            var topProducts = _products
                .Where(p => p.IsActive)
                .OrderByDescending(p => p.Stars)
                .ThenByDescending(p => p.Inventory)
                .Take(count)
                .AsEnumerable();

            return Task.FromResult(topProducts);
        }

        public async Task<IEnumerable<Product>> GetByFilterAsync(ProductFilterDto filter)
        {
            var filteredProducts = _products.AsQueryable();

            if (filter.MinStars.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.Stars >= filter.MinStars.Value);
            }

            if (filter.MaxStars.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.Stars <= filter.MaxStars.Value);
            }

            if (filter.MinInventory.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.Inventory >= filter.MinInventory.Value);
            }

            if (filter.MaxInventory.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.Inventory <= filter.MaxInventory.Value);
            }

            if (filter.IsActive.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.IsActive == filter.IsActive.Value);
            }

            var results = filteredProducts
                .OrderByDescending(p => p.Stars)
                .ThenByDescending(p => p.Inventory)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToList();

            return await Task.FromResult(results);
        }

        public Task<Product> AddAsync(Product product)
        {
            product.Id = _nextId++;
            _products.Add(product);
            return Task.FromResult(product);
        }

        public Task<Product> UpdateAsync(Product product)
        {
            var existing = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existing == null)
                return Task.FromResult<Product>(null);

            existing.Name = product.Name;
            existing.Stars = product.Stars;
            existing.Inventory = product.Inventory;
            existing.IsActive = product.IsActive;

            return Task.FromResult(existing);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return Task.FromResult(false);

            product.IsActive = false;
            return Task.FromResult(true);
        }

        public Task<int> GetCountAsync()
        {
            var count = _products.Count(p => p.IsActive);
            return Task.FromResult(count);
        }

        public Task<bool> ExistsAsync(int id)
        {
            var exists = _products.Any(p => p.Id == id && p.IsActive);
            return Task.FromResult(exists);
        }
    }
}