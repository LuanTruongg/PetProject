using AutoBiker.Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiker.Database.SeedData
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Brand>().HasData(
                new Brand() {Id = "SU", Name = "Suzuki" },
                new Brand() { Id = "HO", Name = "Honda" },
                new Brand() { Id = "YA", Name = "Yamaha" },
                new Brand() { Id = "KA", Name = "Kawasaki" },
                new Brand() { Id = "DU", Name = "Ducati" },
                new Brand() { Id = "BMW", Name = "BMW" },
                new Brand() { Id = "HD", Name = "Harley-Davidson" },
                new Brand() { Id = "TR", Name = "Triumph" },
                new Brand() { Id = "KTM", Name = "KTM" },
                new Brand() { Id = "GPX", Name = "GPX" }
                );
            builder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "Honda Wave Alpha", OriginalPrice = 20000000, Price = 18000000, Color = "Red", Stock = 10, BrandId = "HO" },
                new Product() { Id = 2, Name = "Honda CBR 150R", OriginalPrice = 20000000, Price = 18000000, Color = "Black", Stock = 10, BrandId = "HO" },
                new Product() { Id = 3, Name = "Honda CBR 250R", OriginalPrice = 20000000, Price = 18000000, Color = "Red", Stock = 10, BrandId = "HO" },
                new Product() { Id = 4, Name = "Honda CBR 650R", OriginalPrice = 20000000, Price = 18000000, Color = "Red", Stock = 10, BrandId = "HO" },
                new Product() { Id = 5, Name = "Honda CBR 1000R", OriginalPrice = 20000000, Price = 18000000, Color = "Red", Stock = 10, BrandId = "HO" },
                new Product() { Id = 6, Name = "Suzuki GSX R150", OriginalPrice = 50000000, Price = 45000000, Color = "Blue GP", Stock = 10, BrandId = "SU" },
                new Product() { Id = 7, Name = "Suzuki GSX 250R", OriginalPrice = 50000000, Price = 45000000, Color = "Black", Stock = 10, BrandId = "SU" },
                new Product() { Id = 8, Name = "Suzuki GSX S150", OriginalPrice = 50000000, Price = 45000000, Color = "Blue", Stock = 10, BrandId = "SU" },
                new Product() { Id = 9, Name = "Yamaha R15v3", OriginalPrice = 65000000, Price = 62000000, Color = "Black", Stock = 10, BrandId = "YA" },
                new Product() { Id = 10, Name = "Yamaha R15M", OriginalPrice = 65000000, Price = 62000000, Color = "Black", Stock = 10, BrandId = "YA" },
                new Product() { Id = 11, Name = "Yamaha R1", OriginalPrice = 65000000, Price = 62000000, Color = "Black", Stock = 10, BrandId = "YA" },
                new Product() { Id = 12, Name = "Ducati Panigale 959", OriginalPrice = 20000000, Price = 18000000, Color = "Red", Stock = 10, BrandId = "DU" },
                new Product() { Id = 13, Name = "BMW S1000RR", OriginalPrice = 20000000, Price = 18000000, Color = "White", Stock = 10, BrandId = "BMW" },
                new Product() { Id = 14, Name = "Kawasaki Ninja 300", OriginalPrice = 20000000, Price = 18000000, Color = "White", Stock = 10, BrandId = "KA" },
                new Product() { Id = 15, Name = "Kawasaki Ninja 600", OriginalPrice = 20000000, Price = 18000000, Color = "White", Stock = 10, BrandId = "KA" },
                new Product() { Id = 16, Name = "Kawasaki Ninja H2", OriginalPrice = 20000000, Price = 18000000, Color = "White", Stock = 10, BrandId = "KA" },
                new Product() { Id = 17, Name = "Kawasaki Ninja H2R", OriginalPrice = 20000000, Price = 18000000, Color = "White", Stock = 10, BrandId = "KA" }
                );

            var hasher = new PasswordHasher<AppUser>();

            var adminId = new Guid("3CA10A43-C5C2-4535-A98E-EB51DF682E1A");

            builder.Entity<AppUser>().HasData(
                new AppUser() { 
                    Id = adminId.ToString(),
                    UserName = "admin",
                    NormalizedUserName = "admin",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "admin@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "admin"),
                    SecurityStamp = string.Empty,
                    FirstName = "Admin",
                    LastName = "Admin",
                    CIC = "123456789",
                }
                );
            var roleAdminId = new Guid("D843E3F3-2456-42C3-95BA-4644D98C84E7");
            var roleStaffId = new Guid("0A273554-A735-4F31-9C65-625385BF9B62");
            var roleCustomerId = new Guid("8E1F0D64-AA1D-472E-8C37-7D8D7E5F4701");
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = roleAdminId.ToString(),
                    Name = "Admin",
                    NormalizedName = "Admin",
                },
                new IdentityRole()
                {
                    Id = roleStaffId.ToString(),
                    Name = "Staff",
                    NormalizedName = "Staff",
                },
                new IdentityRole()
                {
                    Id = roleCustomerId.ToString(),
                    Name = "Customer",
                    NormalizedName = "Customer",
                }
                );
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = roleAdminId.ToString(), 
                    UserId = adminId.ToString(),
                });
        }
    }
}
