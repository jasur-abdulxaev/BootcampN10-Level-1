using N23_HT1.Dto;
using N23_HT1.Models;

namespace N23_HT1.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResult<List<ProductDto>>> GetTopProductsAsync(TopProductsRequestDto request);
        Task<ServiceResult<List<ProductDto>>> GetProductsByFilterAsync(ProductFilterDto filter);
        Task<ServiceResult<ProductDto>> GetProductByIdAsync(int id);
        Task<ServiceResult<ProductDto>> CreateProductAsync(Product product);
        Task<ServiceResult<ProductDto>> UpdateInventoryAsync(int id, int newInventory);
        Task<ServiceResult<bool>> DeleteProductAsync(int id);
    }

    public class ServiceResult<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public static ServiceResult<T> SuccessResult(T data, string message = null)
        {
            return new ServiceResult<T>
            {
                Success = true,
                Data = data,
                Message = message,
                Errors = new List<string>()
            };
        }

        public static ServiceResult<T> FailureResult(string message, List<string> errors = null)
        {
            return new ServiceResult<T>
            {
                Success = false,
                Data = default(T),
                Message = message,
                Errors = errors ?? new List<string>()
            };
        }
    }
}