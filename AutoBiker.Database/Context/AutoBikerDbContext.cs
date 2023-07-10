using AutoBiker.Database.Configuration;
using AutoBiker.Database.Entities;
using AutoBiker.Database.SeedData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiker.Database.Context
{
    public class AutoBikerDbContext : IdentityDbContext<AppUser>
    {
        public AutoBikerDbContext(DbContextOptions<AutoBikerDbContext> options): base (options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new BrandConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());

            builder.Seed();

        }
        #region
        public DbSet<Product> Products { get; set; }
        #endregion
        #region
        public DbSet<Brand> Brands { get; set; }
        #endregion
    }
}
