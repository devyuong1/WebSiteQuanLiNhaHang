using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class updatedd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ConversionRate",
                table: "ingredients",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "UsageUnit",
                table: "ingredients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 10.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 40.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                columns: new[] { "ConversionRate", "UsageUnit" },
                values: new object[] { 10.0, "ml" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 4,
                columns: new[] { "ConversionRate", "UsageUnit" },
                values: new object[] { 10.0, "ml" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 30.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 20.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 20.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 20.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 50.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 5.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 5.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 40.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 30.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 30.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 30.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 3.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 3.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 30.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 3.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                columns: new[] { "ConversionRate", "Price", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 80000.0, 20.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 2.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 20.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                columns: new[] { "ConversionRate", "Unit", "UsageUnit" },
                values: new object[] { 30.0, "khay", "quả" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 20.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 25,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 200.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 26,
                columns: new[] { "ConversionRate", "Unit", "UsageUnit" },
                values: new object[] { 30.0, "Thùng", "gói" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 27,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 20.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 28,
                columns: new[] { "ConversionRate", "Quantity", "Unit", "UsageUnit" },
                values: new object[] { 1000.0, 20.0, "kg", "g" });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 10, 27, 15, 4, 27, 983, DateTimeKind.Utc).AddTicks(7880));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 10, 27, 15, 4, 27, 983, DateTimeKind.Utc).AddTicks(7883));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "Create_At",
                value: new DateTime(2025, 10, 27, 15, 4, 27, 983, DateTimeKind.Utc).AddTicks(7885));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "Create_At",
                value: new DateTime(2025, 10, 27, 15, 4, 27, 983, DateTimeKind.Utc).AddTicks(7886));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "Create_At",
                value: new DateTime(2025, 10, 27, 15, 4, 27, 983, DateTimeKind.Utc).AddTicks(7888));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "Create_At",
                value: new DateTime(2025, 10, 27, 15, 4, 27, 983, DateTimeKind.Utc).AddTicks(7889));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "Create_At",
                value: new DateTime(2025, 10, 27, 15, 4, 27, 983, DateTimeKind.Utc).AddTicks(7891));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 8,
                column: "Create_At",
                value: new DateTime(2025, 10, 27, 15, 4, 27, 983, DateTimeKind.Utc).AddTicks(7893));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 9,
                column: "Create_At",
                value: new DateTime(2025, 10, 27, 15, 4, 27, 983, DateTimeKind.Utc).AddTicks(7894));

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 18,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 500.0, "g" });

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 20,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 500.0, "g" });

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 22,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 500.0, "g" });

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 24,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 500.0, "g" });

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 35,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 1000.0, "g" });

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 36,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 1000.0, "g" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConversionRate",
                table: "ingredients");

            migrationBuilder.DropColumn(
                name: "UsageUnit",
                table: "ingredients");

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 10000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 40000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 30000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 20000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 20000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 2000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 50000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 20000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 20000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 40000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 30000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 300000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 30000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 30000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 3000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 30000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 30000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                columns: new[] { "Price", "Quantity", "Unit" },
                values: new object[] { 800000.0, 200000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 200000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 200000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 23,
                column: "Unit",
                value: "trứng");

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 20000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 25,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 20000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 26,
                column: "Unit",
                value: "gói");

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 27,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 20000.0, "g" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 28,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 20000.0, "g" });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 10, 27, 0, 45, 51, 394, DateTimeKind.Utc).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 10, 27, 0, 45, 51, 394, DateTimeKind.Utc).AddTicks(8266));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "Create_At",
                value: new DateTime(2025, 10, 27, 0, 45, 51, 394, DateTimeKind.Utc).AddTicks(8269));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "Create_At",
                value: new DateTime(2025, 10, 27, 0, 45, 51, 394, DateTimeKind.Utc).AddTicks(8270));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "Create_At",
                value: new DateTime(2025, 10, 27, 0, 45, 51, 394, DateTimeKind.Utc).AddTicks(8272));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "Create_At",
                value: new DateTime(2025, 10, 27, 0, 45, 51, 394, DateTimeKind.Utc).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "Create_At",
                value: new DateTime(2025, 10, 27, 0, 45, 51, 394, DateTimeKind.Utc).AddTicks(8275));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 8,
                column: "Create_At",
                value: new DateTime(2025, 10, 27, 0, 45, 51, 394, DateTimeKind.Utc).AddTicks(8277));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 9,
                column: "Create_At",
                value: new DateTime(2025, 10, 27, 0, 45, 51, 394, DateTimeKind.Utc).AddTicks(8279));

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 18,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 2.0, "con" });

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 20,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 2.0, "con" });

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 22,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 1.0, "con" });

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 24,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 1.0, "con" });

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 35,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 1.0, "kg" });

            migrationBuilder.UpdateData(
                table: "recipes",
                keyColumn: "RecipeId",
                keyValue: 36,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 1.0, "kg" });
        }
    }
}
