using AutoBiker.BackEnd_Apis.Repositories.Products;
using AutoBiker.Database.Entities;
using AutoBiker.ViewModel.ApiResult.ApiProductResult;

namespace AutoBiker.BackEnd_Apis.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<List<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }

        public async Task<List<Product>> GetListByNameAsync(string Keyword)
        {
            return await _productRepository.GetListByNameAsync(Keyword);               
        }

        public Task<Product> GetByIdAsync(int id)
        {
            return _productRepository.GetByIdAsync(id);
        }

        public async Task<ProductResult> AddProductAsync(Product product)
        {
            try
            {
                await _productRepository.AddAsync(product);
                return new ProductResult(product);
            } catch (Exception ex) { 
                return new ProductResult($"Error: {ex.Message}");
            }
        }

        public async Task<ProductResult> EditProductAsync(int id , Product product)
        {
            var productEdit = await _productRepository.GetByIdAsync(id);
            productEdit.Name = product.Name;
            productEdit.OriginalPrice = product.OriginalPrice;
            productEdit.Price = product.Price;
            productEdit.Stock = product.Stock;
            productEdit.Color = product.Color;
            productEdit.BrandId = product.BrandId;            
            try
            {
                await _productRepository.EditAsync(productEdit);
                return new ProductResult(product);
            }
            catch (Exception ex)
            {
                return new ProductResult($"Error: {ex.Message}");
            }
        }

        public async Task<ProductResult> DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            try
            {
                await _productRepository.DeleteAsync(product);
                return new ProductResult(product);
            }
            catch (Exception ex)
            {
                return new ProductResult($"Error: {ex.Message}");
            }
        }

		public async Task<List<Product>> GetListByBrandNameAsync(string Keyword)
		{
			return await _productRepository.GetListByBrandNameAsync(Keyword);
		}
	}
}
