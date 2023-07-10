using AutoBiker.Database.Entities;

namespace AutoBiker.BackEnd_Apis.Services.Brands
{
    public interface IBrandService
    {
        Task<List<Brand>> ListAsync();
        Task<Brand> GetBrandById(string id);
    }
}
