using AutoBiker.Database.Context;
using AutoBiker.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoBiker.BackEnd_Apis.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly AutoBikerDbContext _context;

        public ProductRepository(AutoBikerDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> ListAsync()
        {
            return await _context.Products.Include(x=> x.Brand).ToListAsync();
        }
        public async Task<List<Product>> GetListByNameAsync(string Keyword)
        {
            return await _context.Products.Where(x => x.Name.Contains(Keyword)).Include(x => x.Brand).ToListAsync();
        }
        public  async Task<Product> GetByIdAsync(int id)
        {
            var product = _context.Products.Include(x => x.Brand).FirstOrDefault(x => x.Id == id);
            if (product == null)            
                return null;            
            return product;

            
        }
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> EditAsync(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return _context.Products.Include(x => x.Brand).FirstOrDefault(x => x.Id == product.Id);
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
