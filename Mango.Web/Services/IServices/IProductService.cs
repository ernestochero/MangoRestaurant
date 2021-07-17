using System.Threading.Tasks;
using Mango.Web.Models;

namespace Mango.Web.Services.IServices
{
    public interface IProductService: IBaseService
    {
        Task<T> GetAllProductsAsync<T>();
        Task<T> GetProductByIdAsync<T>(int id);
        Task<T> CreateProductAsync<T>(ProductDto productDto);
        Task<T> UpdateProductAsync<T>(ProductDto productDto);
        Task<T> DeleteProductsAsync<T>(int id);
    }
}