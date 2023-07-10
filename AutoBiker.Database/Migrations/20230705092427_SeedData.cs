using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoBiker.Database.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "BMW", "BMW" },
                    { "DU", "Ducati" },
                    { "GPX", "GPX" },
                    { "HD", "Harley-Davidson" },
                    { "HO", "Honda" },
                    { "KA", "Kawasaki" },
                    { "KTM", "KTM" },
                    { "SU", "Suzuki" },
                    { "TR", "Triumph" },
                    { "YA", "Yamaha" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "Color", "Name", "OriginalPrice", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "HO", "Red", "Honda Wave Alpha", 20000000m, 18000000m, 10 },
                    { 2, "HO", "Black", "Honda CBR 150R", 20000000m, 18000000m, 10 },
                    { 3, "HO", "Red", "Honda CBR 250R", 20000000m, 18000000m, 10 },
                    { 4, "HO", "Red", "Honda CBR 650R", 20000000m, 18000000m, 10 },
                    { 5, "HO", "Red", "Honda CBR 1000R", 20000000m, 18000000m, 10 },
                    { 6, "SU", "Blue GP", "Suzuki GSX R150", 50000000m, 45000000m, 10 },
                    { 7, "SU", "Black", "Suzuki GSX 250R", 50000000m, 45000000m, 10 },
                    { 8, "SU", "Blue", "Suzuki GSX S150", 50000000m, 45000000m, 10 },
                    { 9, "YA", "Black", "Yamaha R15v3", 65000000m, 62000000m, 10 },
                    { 10, "YA", "Black", "Yamaha R15M", 65000000m, 62000000m, 10 },
                    { 11, "YA", "Black", "Yamaha R1", 65000000m, 62000000m, 10 },
                    { 12, "DU", "Red", "Ducati Panigale 959", 20000000m, 18000000m, 10 },
                    { 13, "BMW", "White", "BMW S1000RR", 20000000m, 18000000m, 10 },
                    { 14, "KA", "White", "Kawasaki Ninja 300", 20000000m, 18000000m, 10 },
                    { 15, "KA", "White", "Kawasaki Ninja 600", 20000000m, 18000000m, 10 },
                    { 16, "KA", "White", "Kawasaki Ninja H2", 20000000m, 18000000m, 10 },
                    { 17, "KA", "White", "Kawasaki Ninja H2R", 20000000m, 18000000m, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
