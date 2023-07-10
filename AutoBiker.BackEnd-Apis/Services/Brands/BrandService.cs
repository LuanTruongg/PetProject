using AutoBiker.BackEnd_Apis.Repositories.Brands;
using AutoBiker.BackEnd_Apis.Repositories.Products;
using AutoBiker.Database.Entities;

namespace AutoBiker.BackEnd_Apis.Services.Brands
{
    public class BrandService : IBrandService
    {
        private readonly  IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<Brand> GetBrandById(string id)
        {
            return await _brandRepository.GetByIdAsync(id);
        }

        public async Task<List<Brand>> ListAsync()
        {
            return await _brandRepository.ListAsync();
        }
    }
}
