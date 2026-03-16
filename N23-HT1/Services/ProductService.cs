using N23_HT1.Dto;
using N23_HT1.Interfaces;
using N23_HT1.Models;

namespace N23_HT1.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<ServiceResult<List<ProductDto>>> GetTopProductsAsync(TopProductsRequestDto request)
        {
            try
            {
                if (request.Count <= 0)
                {
                    return ServiceResult<List<ProductDto>>.FailureResult(
                        "Count must be greater than zero.",
                        new List<string> { "Invalid count parameter." }
                    );
                }

                var products = await _repository.GetAllAsync();
                var query = products.AsQueryable();

                if (request.MinStars.HasValue)
                {
                    query = query.Where(p => p.Stars >= request.MinStars.Value);
                }

                if (request.OnlyInStock)
                {
                    query = query.Where(p => p.Inventory > 0);
                }

                var topProducts = query
                    .OrderByDescending(p => p.Stars)
                    .ThenByDescending(p => p.Inventory)
                    .Take(request.Count)
                    .Select(MapToDto)
                    .ToList();

                return ServiceResult<List<ProductDto>>.SuccessResult(
                    topProducts,
                    $"Retrieved top {topProducts.Count} products"
                );
            }
            catch (Exception ex)
            {
                return ServiceResult<List<ProductDto>>.FailureResult(
                    "An error occurred while retrieving products.",
                    new List<string> { ex.Message }
                );
            }
        }

        public async Task<ServiceResult<List<ProductDto>>> GetProductsByFilterAsync(ProductFilterDto filter)
        {
            try
            {
                var products = await _repository.GetByFilterAsync(filter);
                var productDtos = products.Select(MapToDto).ToList();

                return ServiceResult<List<ProductDto>>.SuccessResult(
                    productDtos,
                    $"Retrieved {productDtos.Count} products matching filter criteria."
                );
            }
            catch (Exception ex)
            {
                return ServiceResult<List<ProductDto>>.FailureResult(
                    "An error occurred while retrieving products.",
                    new List<string> { ex.Message }
                );
            }
        }

        public async Task<ServiceResult<ProductDto>> GetProductByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return ServiceResult<ProductDto>.FailureResult(
                        "Invalid product ID.",
                        new List<string> { "ID must be greater than 0." }
                    );
                }

                var product = await _repository.GetByIdAsync(id);

                if (product == null)
                {
                    return ServiceResult<ProductDto>.FailureResult(
                        $"Product with ID {id} not found.",
                        new List<string> { "Product not found." }
                    );
                }

                return ServiceResult<ProductDto>.SuccessResult(
                    MapToDto(product),
                    $"Retrieved product with ID {id}."
                );
            }
            catch (Exception ex)
            {
                return ServiceResult<ProductDto>.FailureResult(
                    "An error occurred while retrieving the product.",
                    new List<string> { ex.Message }
                );
            }
        }

        public async Task<ServiceResult<ProductDto>> CreateProductAsync(Product product)
        {
            try
            {
                if (!product.IsValid(out var errors))
                {
                    return ServiceResult<ProductDto>.FailureResult(
                        "Product validation failed.",
                        errors
                    );
                }

                var createdProduct = await _repository.AddAsync(product);

                return ServiceResult<ProductDto>.SuccessResult(
                    MapToDto(createdProduct),
                    "Product created successfully."
                );
            }
            catch (Exception ex)
            {
                return ServiceResult<ProductDto>.FailureResult(
                    "Error creating product.",
                    new List<string> { ex.Message }
                );
            }
        }

        public async Task<ServiceResult<ProductDto>> UpdateInventoryAsync(int id, int newInventory)
        {
            try
            {
                if (newInventory < 0)
                {
                    return ServiceResult<ProductDto>.FailureResult(
                        "Inventory cannot be negative.",
                        new List<string> { "Invalid inventory value." }
                    );
                }

                var product = await _repository.GetByIdAsync(id);
                if (product == null)
                {
                    return ServiceResult<ProductDto>.FailureResult(
                        $"Product with ID {id} not found.",
                        new List<string> { "Product not found." }
                    );
                }

                product.Inventory = newInventory;
                var updatedProduct = await _repository.UpdateAsync(product);

                return ServiceResult<ProductDto>.SuccessResult(
                    MapToDto(updatedProduct),
                    "Inventory updated successfully."
                );
            }
            catch (Exception ex)
            {
                return ServiceResult<ProductDto>.FailureResult(
                    "Error updating inventory.",
                    new List<string> { ex.Message }
                );
            }
        }

        public async Task<ServiceResult<bool>> DeleteProductAsync(int id)
        {
            try
            {
                var exists = await _repository.ExistsAsync(id);
                if (!exists)
                {
                    return ServiceResult<bool>.FailureResult(
                        $"Product with ID {id} not found.",
                        new List<string> { "Product not found." }
                    );
                }

                var result = await _repository.DeleteAsync(id);

                return ServiceResult<bool>.SuccessResult(
                    result,
                    result ? "Product deleted successfully." : "Failed to delete product."
                );
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.FailureResult(
                    "Error deleting product.",
                    new List<string> { ex.Message }
                );
            }
        }

        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Stars = product.Stars,
                Inventory = product.Inventory,
                DisplayText = $"{product.Name} - {product.Inventory} in stock"
            };
        }
    }
}