using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoBiker.Database.Migrations
{
    public partial class updateRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d843e3f3-2456-42c3-95ba-4644d98c84e7",
                column: "ConcurrencyStamp",
                value: "7f1ff20c-d980-4e4d-a8b0-4e69433dd344");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a273554-a735-4f31-9c65-625385bf9b62", "814d6ca5-90d2-4234-bd38-6fe1a357dba5", "Staff", "Staff" },
                    { "8e1f0d64-aa1d-472e-8c37-7d8d7e5f4701", "5977ac0b-c6cc-4e62-aac5-9e5ea970c6c8", "Customer", "Customer" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca10a43-c5c2-4535-a98e-eb51df682e1a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2900b07a-20d4-4ca2-9c35-b7077dc55490", "AQAAAAEAACcQAAAAED/jZvGVo4P02UN32aTqxoEomca90M6PDGCNQeJ1RCuBCyoiu86rqeCNzMOyBWAGGg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a273554-a735-4f31-9c65-625385bf9b62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e1f0d64-aa1d-472e-8c37-7d8d7e5f4701");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d843e3f3-2456-42c3-95ba-4644d98c84e7",
                column: "ConcurrencyStamp",
                value: "359fc9ad-b59a-4fed-9b60-3cb7058b06fc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ca10a43-c5c2-4535-a98e-eb51df682e1a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "666e7719-b9f7-4e39-b7d2-a66cbe1e9fa1", "AQAAAAEAACcQAAAAEHGTRnQHkW2iiVYr/rSZZu/KEosDODzOcKAtSgFm6UMYJRrGhcZ6o/XZb4CkvMMENA==" });
        }
    }
}
