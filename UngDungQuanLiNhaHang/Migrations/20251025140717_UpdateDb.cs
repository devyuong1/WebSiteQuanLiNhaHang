using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "suppliers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "recipes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "productOptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 10, 25, 14, 7, 16, 991, DateTimeKind.Utc).AddTicks(7179));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 10, 25, 14, 7, 16, 991, DateTimeKind.Utc).AddTicks(7182));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "Create_At",
                value: new DateTime(2025, 10, 25, 14, 7, 16, 991, DateTimeKind.Utc).AddTicks(7184));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "Create_At",
                value: new DateTime(2025, 10, 25, 14, 7, 16, 991, DateTimeKind.Utc).AddTicks(7186));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "Create_At",
                value: new DateTime(2025, 10, 25, 14, 7, 16, 991, DateTimeKind.Utc).AddTicks(7188));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "Create_At",
                value: new DateTime(2025, 10, 25, 14, 7, 16, 991, DateTimeKind.Utc).AddTicks(7189));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "Create_At",
                value: new DateTime(2025, 10, 25, 14, 7, 16, 991, DateTimeKind.Utc).AddTicks(7191));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 8,
                column: "Create_At",
                value: new DateTime(2025, 10, 25, 14, 7, 16, 991, DateTimeKind.Utc).AddTicks(7193));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 9,
                column: "Create_At",
                value: new DateTime(2025, 10, 25, 14, 7, 16, 991, DateTimeKind.Utc).AddTicks(7194));

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 1,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 2,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 3,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 4,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 5,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 6,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 7,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 8,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 8,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 9,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 10,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 11,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 12,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 13,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 14,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 15,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 16,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 17,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 18,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 19,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 20,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 21,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 22,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 23,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 24,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 25,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 26,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 27,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 28,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 1,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 2,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 3,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 4,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 5,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 6,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 7,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 8,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 9,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 10,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 11,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 12,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 13,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 14,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 15,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 16,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 17,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 18,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 19,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 20,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 21,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 22,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 23,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 24,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 25,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 26,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 27,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 28,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 29,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 30,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 31,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 32,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 33,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 34,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 35,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 36,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 37,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 38,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 39,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 40,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 41,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 42,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 43,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 44,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 45,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 46,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 47,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 48,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 49,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 50,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "suppliers",
                keyColumn: "SupplierID",
                keyValue: 1,
                column: "isDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "suppliers",
                keyColumn: "SupplierID",
                keyValue: 2,
                column: "isDelete",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "suppliers");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "recipes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "products");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "productOptions");

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 10, 25, 6, 33, 23, 28, DateTimeKind.Utc).AddTicks(2674));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 10, 25, 6, 33, 23, 28, DateTimeKind.Utc).AddTicks(2680));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "Create_At",
                value: new DateTime(2025, 10, 25, 6, 33, 23, 28, DateTimeKind.Utc).AddTicks(2682));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "Create_At",
                value: new DateTime(2025, 10, 25, 6, 33, 23, 28, DateTimeKind.Utc).AddTicks(2684));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "Create_At",
                value: new DateTime(2025, 10, 25, 6, 33, 23, 28, DateTimeKind.Utc).AddTicks(2685));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "Create_At",
                value: new DateTime(2025, 10, 25, 6, 33, 23, 28, DateTimeKind.Utc).AddTicks(2687));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "Create_At",
                value: new DateTime(2025, 10, 25, 6, 33, 23, 28, DateTimeKind.Utc).AddTicks(2689));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 8,
                column: "Create_At",
                value: new DateTime(2025, 10, 25, 6, 33, 23, 28, DateTimeKind.Utc).AddTicks(2690));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 9,
                column: "Create_At",
                value: new DateTime(2025, 10, 25, 6, 33, 23, 28, DateTimeKind.Utc).AddTicks(2692));
        }
    }
}
