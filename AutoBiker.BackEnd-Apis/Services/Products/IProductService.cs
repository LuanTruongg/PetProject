using AutoBiker.Database.Entities;
using AutoBiker.ViewModel.ApiResult.ApiProductResult;

namespace AutoBiker.BackEnd_Apis.Services.Products
{
    public interface IProductService
    {
        Task<List<Product>> ListAsync();
        Task<List<Product>> GetListByNameAsync(string Keyword);
		Task<List<Product>> GetListByBrandNameAsync(string Keyword);
		Task<Product> GetByIdAsync(int id);
        Task<ProductResult> AddProductAsync(Product product);
        Task<ProductResult> EditProductAsync(int id, Product product);
        Task<ProductResult> DeleteProductAsync(int id);
    }
}
