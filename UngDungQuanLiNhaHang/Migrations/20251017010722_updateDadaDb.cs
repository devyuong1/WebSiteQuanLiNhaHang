using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class updateDadaDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookTables_BookTableStatus_bookTableStatusId",
                table: "bookTables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookTableStatus",
                table: "BookTableStatus");

            migrationBuilder.RenameTable(
                name: "BookTableStatus",
                newName: "bookTableStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookTableStatuses",
                table: "bookTableStatuses",
                column: "bookTableStatusId");

            migrationBuilder.InsertData(
                table: "bookTableStatuses",
                columns: new[] { "bookTableStatusId", "status" },
                values: new object[,]
                {
                    { 1, "Chờ Xác Nhận" },
                    { 2, "Đã Xác Nhận" },
                    { 3, "Hoàn Thành" },
                    { 4, "Đã Hủy" }
                });

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
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 200000.0, "g" });

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
                value: new DateTime(2025, 10, 17, 1, 7, 22, 341, DateTimeKind.Utc).AddTicks(4366));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 10, 17, 1, 7, 22, 341, DateTimeKind.Utc).AddTicks(4369));

            migrationBuilder.InsertData(
                table: "productOptions",
                columns: new[] { "ProductOptionId", "IngredientId", "OptionName", "OptionValue", "Price", "ProductId", "Unit" },
                values: new object[,]
                {
                    { 1, 1, " Thịt bò ", 100.0, 30000.0, 1, "g" },
                    { 2, 1, " Thịt bò ", 100.0, 30000.0, 2, "g" },
                    { 3, 10, " Mọc ", 100.0, 30000.0, 3, "g" },
                    { 4, 18, " Cá đuối  ", 150.0, 20000.0, 10, "g" },
                    { 5, 11, " Tôm Sú  ", 100.0, 150000.0, 9, "g" },
                    { 6, 12, " Mực  ", 100.0, 150000.0, 9, "g" }
                });

            migrationBuilder.InsertData(
                table: "tables",
                columns: new[] { "TableId", "Capacity", "Status" },
                values: new object[,]
                {
                    { 1, 4, false },
                    { 2, 4, false },
                    { 3, 6, false },
                    { 4, 6, false },
                    { 5, 8, false },
                    { 6, 8, false },
                    { 7, 6, false },
                    { 8, 6, false },
                    { 9, 8, false },
                    { 10, 8, false },
                    { 11, 8, false },
                    { 12, 8, false },
                    { 13, 8, false },
                    { 14, 8, false },
                    { 15, 8, false },
                    { 16, 8, false },
                    { 17, 8, false },
                    { 18, 8, false },
                    { 19, 8, false },
                    { 20, 10, false },
                    { 21, 10, false },
                    { 22, 10, false }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_bookTables_bookTableStatuses_bookTableStatusId",
                table: "bookTables",
                column: "bookTableStatusId",
                principalTable: "bookTableStatuses",
                principalColumn: "bookTableStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookTables_bookTableStatuses_bookTableStatusId",
                table: "bookTables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookTableStatuses",
                table: "bookTableStatuses");

            migrationBuilder.DeleteData(
                table: "bookTableStatuses",
                keyColumn: "bookTableStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "bookTableStatuses",
                keyColumn: "bookTableStatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "bookTableStatuses",
                keyColumn: "bookTableStatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "bookTableStatuses",
                keyColumn: "bookTableStatusId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 22);

            migrationBuilder.RenameTable(
                name: "bookTableStatuses",
                newName: "BookTableStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookTableStatus",
                table: "BookTableStatus",
                column: "bookTableStatusId");

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 10.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 4.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 5,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 3.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 6,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 2.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 7,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 2.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 8,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 2.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 9,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 5.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 10,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 2.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 11,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 2.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 12,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 4.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 13,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 3.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 14,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 3.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 15,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 3.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 16,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 3.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 17,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 3.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 18,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 3.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 19,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 3.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 20,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 20.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 21,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 20.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 22,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 20.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 24,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 20.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 25,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 20.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 27,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 20.0, "kg" });

            migrationBuilder.UpdateData(
                table: "ingredients",
                keyColumn: "IngredientId",
                keyValue: 28,
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 20.0, "kg" });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 10, 16, 15, 26, 40, 849, DateTimeKind.Utc).AddTicks(9917));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 10, 16, 15, 26, 40, 849, DateTimeKind.Utc).AddTicks(9920));

            migrationBuilder.AddForeignKey(
                name: "FK_bookTables_BookTableStatus_bookTableStatusId",
                table: "bookTables",
                column: "bookTableStatusId",
                principalTable: "BookTableStatus",
                principalColumn: "bookTableStatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
