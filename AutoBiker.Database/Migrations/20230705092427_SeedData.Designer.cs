﻿// <auto-generated />
using AutoBiker.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoBiker.Database.Migrations
{
    [DbContext(typeof(AutoBikerDbContext))]
    [Migration("20230705092427_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AutoBiker.Database.Entities.Brand", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Brands", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "SU",
                            Name = "Suzuki"
                        },
                        new
                        {
                            Id = "HO",
                            Name = "Honda"
                        },
                        new
                        {
                            Id = "YA",
                            Name = "Yamaha"
                        },
                        new
                        {
                            Id = "KA",
                            Name = "Kawasaki"
                        },
                        new
                        {
                            Id = "DU",
                            Name = "Ducati"
                        },
                        new
                        {
                            Id = "BMW",
                            Name = "BMW"
                        },
                        new
                        {
                            Id = "HD",
                            Name = "Harley-Davidson"
                        },
                        new
                        {
                            Id = "TR",
                            Name = "Triumph"
                        },
                        new
                        {
                            Id = "KTM",
                            Name = "KTM"
                        },
                        new
                        {
                            Id = "GPX",
                            Name = "GPX"
                        });
                });

            modelBuilder.Entity("AutoBiker.Database.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BrandId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = "HO",
                            Color = "Red",
                            Name = "Honda Wave Alpha",
                            OriginalPrice = 20000000m,
                            Price = 18000000m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 2,
                            BrandId = "HO",
                            Color = "Black",
                            Name = "Honda CBR 150R",
                            OriginalPrice = 20000000m,
                            Price = 18000000m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 3,
                            BrandId = "HO",
                            Color = "Red",
                            Name = "Honda CBR 250R",
                            OriginalPrice = 20000000m,
                            Price = 18000000m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 4,
                            BrandId = "HO",
                            Color = "Red",
                            Name = "Honda CBR 650R",
                            OriginalPrice = 20000000m,
                            Price = 18000000m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 5,
                            BrandId = "HO",
                            Color = "Red",
                            Name = "Honda CBR 1000R",
                            OriginalPrice = 20000000m,
                            Price = 18000000m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 6,
                            BrandId = "SU",
                            Color = "Blue GP",
                            Name = "Suzuki GSX R150",
                            OriginalPrice = 50000000m,
                            Price = 45000000m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 7,
                            BrandId = "SU",
                            Color = "Black",
                            Name = "Suzuki GSX 250R",
                            OriginalPrice = 50000000m,
                            Price = 45000000m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 8,
                            BrandId = "SU",
                            Color = "Blue",
                            Name = "Suzuki GSX S150",
                            OriginalPrice = 50000000m,
                            Price = 45000000m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 9,
                            BrandId = "YA",
                            Color = "Black",
                            Name = "Yamaha R15v3",
                            OriginalPrice = 65000000m,
                            Price = 62000000m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 10,
                            BrandId = "YA",
                            Color = "Black",
                            Name = "Yamaha R15M",
                            OriginalPrice = 65000000m,
                            Price = 62000000m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 11,
                            BrandId = "YA",
                            Color = "Black",
                            Name = "Yamaha R1",
                            OriginalPrice = 65000000m,
                            Price = 62000000m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 12,
                            BrandId = "DU",
                            Color = "Red",
                            Name = "Ducati Panigale 959",
                            OriginalPrice = 20000000m,
                            Price = 18000000m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 13,
                            BrandId = "BMW",
                            Color = "White",
                            Name = "BMW S1000RR",
                            OriginalPrice = 20000000m,
                            Price = 18000000m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 14,
                            BrandId = "KA",
                            Color = "White",
                            Name = "Kawasaki Ninja 300",
                            OriginalPrice = 20000000m,
                            Price = 18000000m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 15,
                            BrandId = "KA",
                            Color = "White",
                            Name = "Kawasaki Ninja 600",
                            OriginalPrice = 20000000m,
                            Price = 18000000m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 16,
                            BrandId = "KA",
                            Color = "White",
                            Name = "Kawasaki Ninja H2",
                            OriginalPrice = 20000000m,
                            Price = 18000000m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 17,
                            BrandId = "KA",
                            Color = "White",
                            Name = "Kawasaki Ninja H2R",
                            OriginalPrice = 20000000m,
                            Price = 18000000m,
                            Stock = 10
                        });
                });

            modelBuilder.Entity("AutoBiker.Database.Entities.Product", b =>
                {
                    b.HasOne("AutoBiker.Database.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("AutoBiker.Database.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
