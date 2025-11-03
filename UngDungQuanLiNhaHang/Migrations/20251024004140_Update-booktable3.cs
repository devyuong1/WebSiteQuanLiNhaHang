using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class Updatebooktable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 10, 24, 0, 41, 39, 876, DateTimeKind.Utc).AddTicks(8824));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 10, 24, 0, 41, 39, 876, DateTimeKind.Utc).AddTicks(8828));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "Create_At",
                value: new DateTime(2025, 10, 24, 0, 41, 39, 876, DateTimeKind.Utc).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "Create_At",
                value: new DateTime(2025, 10, 24, 0, 41, 39, 876, DateTimeKind.Utc).AddTicks(8832));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "Create_At",
                value: new DateTime(2025, 10, 24, 0, 41, 39, 876, DateTimeKind.Utc).AddTicks(8833));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "Create_At",
                value: new DateTime(2025, 10, 24, 0, 41, 39, 876, DateTimeKind.Utc).AddTicks(8859));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "Create_At",
                value: new DateTime(2025, 10, 24, 0, 41, 39, 876, DateTimeKind.Utc).AddTicks(8861));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 8,
                column: "Create_At",
                value: new DateTime(2025, 10, 24, 0, 41, 39, 876, DateTimeKind.Utc).AddTicks(8862));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 9,
                column: "Create_At",
                value: new DateTime(2025, 10, 24, 0, 41, 39, 876, DateTimeKind.Utc).AddTicks(8864));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 10, 24, 0, 39, 29, 846, DateTimeKind.Utc).AddTicks(4791));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 10, 24, 0, 39, 29, 846, DateTimeKind.Utc).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "Create_At",
                value: new DateTime(2025, 10, 24, 0, 39, 29, 846, DateTimeKind.Utc).AddTicks(4798));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "Create_At",
                value: new DateTime(2025, 10, 24, 0, 39, 29, 846, DateTimeKind.Utc).AddTicks(4799));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "Create_At",
                value: new DateTime(2025, 10, 24, 0, 39, 29, 846, DateTimeKind.Utc).AddTicks(4801));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "Create_At",
                value: new DateTime(2025, 10, 24, 0, 39, 29, 846, DateTimeKind.Utc).AddTicks(4803));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "Create_At",
                value: new DateTime(2025, 10, 24, 0, 39, 29, 846, DateTimeKind.Utc).AddTicks(4804));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 8,
                column: "Create_At",
                value: new DateTime(2025, 10, 24, 0, 39, 29, 846, DateTimeKind.Utc).AddTicks(4806));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 9,
                column: "Create_At",
                value: new DateTime(2025, 10, 24, 0, 39, 29, 846, DateTimeKind.Utc).AddTicks(4807));
        }
    }
}
