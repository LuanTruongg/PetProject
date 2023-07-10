using AutoBiker.Database.Entities;

namespace AutoBiker.BackEnd_Apis.Repositories.Brands
{
    public interface IBrandRepository
    {
        Task<List<Brand>> ListAsync();
        Task<Brand> GetByIdAsync(string id);
    }
}
