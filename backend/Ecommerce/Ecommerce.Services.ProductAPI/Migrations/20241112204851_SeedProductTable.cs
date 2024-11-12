using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("1433c03b-2e97-4535-962f-31c4b89e875a"), "Product Z", 29.99m, 25 },
                    { new Guid("28ec15db-cf38-47e9-b228-7fc5fad3dbff"), "Product X", 9.99m, 100 },
                    { new Guid("7b99905c-24b1-45a3-b453-30316effa3d4"), "Product Y", 19.99m, 50 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1433c03b-2e97-4535-962f-31c4b89e875a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("28ec15db-cf38-47e9-b228-7fc5fad3dbff"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7b99905c-24b1-45a3-b453-30316effa3d4"));
        }
    }
}
