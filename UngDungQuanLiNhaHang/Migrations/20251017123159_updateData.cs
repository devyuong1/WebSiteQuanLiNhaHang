using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class updateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 10, 17, 12, 31, 56, 822, DateTimeKind.Utc).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 10, 17, 12, 31, 56, 822, DateTimeKind.Utc).AddTicks(1085));

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 1,
                column: "OptionName",
                value: "1 phần thịt bò ");

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 2,
                column: "OptionName",
                value: "1 phần thịt bò ");

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 3,
                column: "OptionName",
                value: "1 phần thịt mọc ");

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 4,
                column: "OptionName",
                value: "1 phần cá đuối");

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 5,
                column: "OptionName",
                value: "1 phần tôm sú");

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 6,
                column: "OptionName",
                value: "1 phần mực");

            migrationBuilder.InsertData(
                table: "productOptions",
                columns: new[] { "ProductOptionId", "IngredientId", "OptionName", "OptionValue", "Price", "ProductId", "Unit" },
                values: new object[,]
                {
                    { 7, 7, "1 phần bún ", 300.0, 10000.0, 10, "g" },
                    { 8, 7, "1 phần bún", 300.0, 100000.0, 9, "g" }
                });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 25,
                column: "CategoryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 26,
                column: "CategoryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 27,
                column: "CategoryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 28,
                column: "CategoryId",
                value: 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 10, 17, 1, 7, 22, 341, DateTimeKind.Utc).AddTicks(4366));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 10, 17, 1, 7, 22, 341, DateTimeKind.Utc).AddTicks(4369));

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 1,
                column: "OptionName",
                value: " Thịt bò ");

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 2,
                column: "OptionName",
                value: " Thịt bò ");

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 3,
                column: "OptionName",
                value: " Mọc ");

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 4,
                column: "OptionName",
                value: " Cá đuối  ");

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 5,
                column: "OptionName",
                value: " Tôm Sú  ");

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 6,
                column: "OptionName",
                value: " Mực  ");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 25,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 26,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 27,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 28,
                column: "CategoryId",
                value: 5);
        }
    }
}
