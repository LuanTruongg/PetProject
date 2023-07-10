using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoBiker.Database.Migrations
{
    public partial class SeedDataUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d843e3f3-2456-42c3-95ba-4644d98c84e7", "359fc9ad-b59a-4fed-9b60-3cb7058b06fc", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CIC", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3ca10a43-c5c2-4535-a98e-eb51df682e1a", 0, "123456789", "666e7719-b9f7-4e39-b7d2-a66cbe1e9fa1", "admin@gmail.com", true, "Admin", "Admin", false, null, "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEHGTRnQHkW2iiVYr/rSZZu/KEosDODzOcKAtSgFm6UMYJRrGhcZ6o/XZb4CkvMMENA==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d843e3f3-2456-42c3-95ba-4644d98c84e7", "3ca10a43-c5c2-4535-a98e-eb51df682e1a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d843e3f3-2456-42c3-95ba-4644d98c84e7", "3ca10a43-c5c2-4535-a98e-eb51df682e1a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d843e3f3-2456-42c3-95ba-4644d98c84e7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca10a43-c5c2-4535-a98e-eb51df682e1a");
        }
    }
}
