using Microsoft.Extensions.DependencyInjection;
using N23_HT1.Dto;
using N23_HT1.Interfaces;
using N23_HT1.Repositories;
using N23_HT1.Services;
using System.Text;
using Task = System.Threading.Tasks.Task;

namespace N23_HT1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            var serviceProvider = ConfigureServices();
            var productService = serviceProvider.GetRequiredService<IProductService>();

            Console.WriteLine("=== N23-HT1: TOP 5 PRODUCTS ===\n");
            await DisplayTopProducts(productService);

            Console.WriteLine("\n\n=== REAL PROJECT EXAMPLES ===\n");
            await DisplayHighRatedProducts(productService);
            await DisplayFilteredProducts(productService);
            await UpdateProductInventory(productService);
            await GetProductDetails(productService);

            Console.ReadKey();
        }

        private static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            return services.BuildServiceProvider();
        }

        private static async Task DisplayTopProducts(IProductService productService)
        {
            var request = new TopProductsRequestDto
            {
                Count = 5,
                OnlyInStock = true
            };

            var result = await productService.GetTopProductsAsync(request);

            if (result.Success)
            {
                Console.WriteLine($"✓ {result.Message}\n");
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.DisplayText);
                }
            }
            else
            {
                Console.WriteLine($"✗ {result.Message}");
                result.Errors.ForEach(e => Console.WriteLine($"  - {e}"));
            }
        }

        private static async Task DisplayHighRatedProducts(IProductService productService)
        {
            Console.WriteLine("--- High Rated Products (4+ stars) ---\n");

            var request = new TopProductsRequestDto
            {
                Count = 10,
                MinStars = 4,
                OnlyInStock = true
            };

            var result = await productService.GetTopProductsAsync(request);

            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine($"{product.Name} - {product.Stars}⭐ - {product.Inventory} units");
                }
            }
        }

        private static async Task DisplayFilteredProducts(IProductService productService)
        {
            Console.WriteLine("\n--- Filtered Products (3-4 stars, 30-80 inventory) ---\n");

            var filter = new ProductFilterDto
            {
                MinStars = 3,
                MaxStars = 4,
                MinInventory = 30,
                MaxInventory = 80,
                PageSize = 5,
                PageNumber = 1
            };

            var result = await productService.GetProductsByFilterAsync(filter);

            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine($"{product.Name} - {product.Stars}⭐ - {product.Inventory} units");
                }
            }
        }

        private static async Task UpdateProductInventory(IProductService productService)
        {
            Console.WriteLine("\n--- Updating Inventory ---\n");

            int productId = 1;
            int newInventory = 100;

            var result = await productService.UpdateInventoryAsync(productId, newInventory);

            if (result.Success)
            {
                Console.WriteLine($"✓ {result.Message}");
                Console.WriteLine($"  Updated: {result.Data.DisplayText}");
            }
            else
            {
                Console.WriteLine($"✗ {result.Message}");
            }
        }

        private static async Task GetProductDetails(IProductService productService)
        {
            Console.WriteLine("\n--- Get Product by ID ---\n");

            var result = await productService.GetProductByIdAsync(9);

            if (result.Success)
            {
                var product = result.Data;
                Console.WriteLine($"ID: {product.Id}");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Rating: {product.Stars}⭐");
                Console.WriteLine($"Stock: {product.Inventory} units");
            }
            else
            {
                Console.WriteLine($"✗ {result.Message}");
            }
        }
    }
}
