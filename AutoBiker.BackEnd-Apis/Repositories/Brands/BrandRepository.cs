using AutoBiker.Database.Context;
using AutoBiker.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoBiker.BackEnd_Apis.Repositories.Brands
{
    public class BrandRepository : IBrandRepository
    {
        private readonly AutoBikerDbContext _context;

        public BrandRepository(AutoBikerDbContext context)
        {
            _context = context;
        }

        public async Task<Brand> GetByIdAsync(string id)
        {
            return await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Brand>> ListAsync()
        {
            return await _context.Brands.ToListAsync();
        }
    }
}
