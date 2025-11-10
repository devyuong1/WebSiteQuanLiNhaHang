using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class das2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoices_tables_tablesTableId",
                table: "invoices");

            migrationBuilder.DropIndex(
                name: "IX_invoices_tablesTableId",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "tablesTableId",
                table: "invoices");

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 11, 9, 2, 34, 47, 753, DateTimeKind.Utc).AddTicks(2324));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 11, 9, 2, 34, 47, 753, DateTimeKind.Utc).AddTicks(2329));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "Create_At",
                value: new DateTime(2025, 11, 9, 2, 34, 47, 753, DateTimeKind.Utc).AddTicks(2332));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "Create_At",
                value: new DateTime(2025, 11, 9, 2, 34, 47, 753, DateTimeKind.Utc).AddTicks(2334));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "Create_At",
                value: new DateTime(2025, 11, 9, 2, 34, 47, 753, DateTimeKind.Utc).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "Create_At",
                value: new DateTime(2025, 11, 9, 2, 34, 47, 753, DateTimeKind.Utc).AddTicks(2338));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "Create_At",
                value: new DateTime(2025, 11, 9, 2, 34, 47, 753, DateTimeKind.Utc).AddTicks(2340));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 8,
                column: "Create_At",
                value: new DateTime(2025, 11, 9, 2, 34, 47, 753, DateTimeKind.Utc).AddTicks(2344));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 9,
                column: "Create_At",
                value: new DateTime(2025, 11, 9, 2, 34, 47, 753, DateTimeKind.Utc).AddTicks(2346));

            migrationBuilder.CreateIndex(
                name: "IX_invoices_tableId",
                table: "invoices",
                column: "tableId");

            migrationBuilder.AddForeignKey(
                name: "FK_invoices_tables_tableId",
                table: "invoices",
                column: "tableId",
                principalTable: "tables",
                principalColumn: "TableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoices_tables_tableId",
                table: "invoices");

            migrationBuilder.DropIndex(
                name: "IX_invoices_tableId",
                table: "invoices");

            migrationBuilder.AddColumn<int>(
                name: "tablesTableId",
                table: "invoices",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                columns: new[] { "Create_At", "tablesTableId" },
                values: new object[] { new DateTime(2025, 11, 9, 1, 36, 46, 273, DateTimeKind.Utc).AddTicks(9305), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                columns: new[] { "Create_At", "tablesTableId" },
                values: new object[] { new DateTime(2025, 11, 9, 1, 36, 46, 273, DateTimeKind.Utc).AddTicks(9309), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "Create_At", "tablesTableId" },
                values: new object[] { new DateTime(2025, 11, 9, 1, 36, 46, 273, DateTimeKind.Utc).AddTicks(9311), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "Create_At", "tablesTableId" },
                values: new object[] { new DateTime(2025, 11, 9, 1, 36, 46, 273, DateTimeKind.Utc).AddTicks(9313), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "Create_At", "tablesTableId" },
                values: new object[] { new DateTime(2025, 11, 9, 1, 36, 46, 273, DateTimeKind.Utc).AddTicks(9315), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "Create_At", "tablesTableId" },
                values: new object[] { new DateTime(2025, 11, 9, 1, 36, 46, 273, DateTimeKind.Utc).AddTicks(9317), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "Create_At", "tablesTableId" },
                values: new object[] { new DateTime(2025, 11, 9, 1, 36, 46, 273, DateTimeKind.Utc).AddTicks(9319), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 8,
                columns: new[] { "Create_At", "tablesTableId" },
                values: new object[] { new DateTime(2025, 11, 9, 1, 36, 46, 273, DateTimeKind.Utc).AddTicks(9323), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 9,
                columns: new[] { "Create_At", "tablesTableId" },
                values: new object[] { new DateTime(2025, 11, 9, 1, 36, 46, 273, DateTimeKind.Utc).AddTicks(9324), null });

            migrationBuilder.CreateIndex(
                name: "IX_invoices_tablesTableId",
                table: "invoices",
                column: "tablesTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_invoices_tables_tablesTableId",
                table: "invoices",
                column: "tablesTableId",
                principalTable: "tables",
                principalColumn: "TableId");
        }
    }
}
