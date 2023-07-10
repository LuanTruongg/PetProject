using AutoBiker.Database.Entities;

namespace AutoBiker.BackEnd_Apis.Repositories.Products
{
    public interface IProductRepository
    {
        Task<List<Product>> ListAsync();
        Task<List<Product>> GetListByNameAsync(string keyword);
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task<Product> EditAsync(Product product);

        Task DeleteAsync(Product product);
    }
}
