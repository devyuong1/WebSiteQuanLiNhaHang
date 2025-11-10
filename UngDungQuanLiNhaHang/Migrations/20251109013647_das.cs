using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class das : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 11, 9, 1, 36, 46, 273, DateTimeKind.Utc).AddTicks(9305));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 11, 9, 1, 36, 46, 273, DateTimeKind.Utc).AddTicks(9309));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "Create_At",
                value: new DateTime(2025, 11, 9, 1, 36, 46, 273, DateTimeKind.Utc).AddTicks(9311));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "Create_At",
                value: new DateTime(2025, 11, 9, 1, 36, 46, 273, DateTimeKind.Utc).AddTicks(9313));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "Create_At",
                value: new DateTime(2025, 11, 9, 1, 36, 46, 273, DateTimeKind.Utc).AddTicks(9315));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "Create_At",
                value: new DateTime(2025, 11, 9, 1, 36, 46, 273, DateTimeKind.Utc).AddTicks(9317));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "Create_At",
                value: new DateTime(2025, 11, 9, 1, 36, 46, 273, DateTimeKind.Utc).AddTicks(9319));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 8,
                column: "Create_At",
                value: new DateTime(2025, 11, 9, 1, 36, 46, 273, DateTimeKind.Utc).AddTicks(9323));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 9,
                column: "Create_At",
                value: new DateTime(2025, 11, 9, 1, 36, 46, 273, DateTimeKind.Utc).AddTicks(9324));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 11, 8, 7, 29, 11, 502, DateTimeKind.Utc).AddTicks(5689));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 11, 8, 7, 29, 11, 502, DateTimeKind.Utc).AddTicks(5692));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "Create_At",
                value: new DateTime(2025, 11, 8, 7, 29, 11, 502, DateTimeKind.Utc).AddTicks(5695));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "Create_At",
                value: new DateTime(2025, 11, 8, 7, 29, 11, 502, DateTimeKind.Utc).AddTicks(5698));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "Create_At",
                value: new DateTime(2025, 11, 8, 7, 29, 11, 502, DateTimeKind.Utc).AddTicks(5700));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "Create_At",
                value: new DateTime(2025, 11, 8, 7, 29, 11, 502, DateTimeKind.Utc).AddTicks(5701));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "Create_At",
                value: new DateTime(2025, 11, 8, 7, 29, 11, 502, DateTimeKind.Utc).AddTicks(5703));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 8,
                column: "Create_At",
                value: new DateTime(2025, 11, 8, 7, 29, 11, 502, DateTimeKind.Utc).AddTicks(5705));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 9,
                column: "Create_At",
                value: new DateTime(2025, 11, 8, 7, 29, 11, 502, DateTimeKind.Utc).AddTicks(5706));
        }
    }
}
