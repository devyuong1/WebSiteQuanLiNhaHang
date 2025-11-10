using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class dta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 11, 8, 2, 4, 47, 606, DateTimeKind.Utc).AddTicks(4039));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 11, 8, 2, 4, 47, 606, DateTimeKind.Utc).AddTicks(4042));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "Create_At",
                value: new DateTime(2025, 11, 8, 2, 4, 47, 606, DateTimeKind.Utc).AddTicks(4044));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "Create_At",
                value: new DateTime(2025, 11, 8, 2, 4, 47, 606, DateTimeKind.Utc).AddTicks(4046));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "Create_At",
                value: new DateTime(2025, 11, 8, 2, 4, 47, 606, DateTimeKind.Utc).AddTicks(4048));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "Create_At",
                value: new DateTime(2025, 11, 8, 2, 4, 47, 606, DateTimeKind.Utc).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "Create_At",
                value: new DateTime(2025, 11, 8, 2, 4, 47, 606, DateTimeKind.Utc).AddTicks(4051));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 8,
                column: "Create_At",
                value: new DateTime(2025, 11, 8, 2, 4, 47, 606, DateTimeKind.Utc).AddTicks(4054));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 9,
                column: "Create_At",
                value: new DateTime(2025, 11, 8, 2, 4, 47, 606, DateTimeKind.Utc).AddTicks(4055));

            migrationBuilder.InsertData(
                table: "paymentMethods",
                columns: new[] { "PaymentMethodId", "PaymentMethodName" },
                values: new object[] { 4, "Thanh toán tại cửa hàng." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "paymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 11, 3, 12, 33, 15, 88, DateTimeKind.Utc).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 11, 3, 12, 33, 15, 88, DateTimeKind.Utc).AddTicks(3026));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "Create_At",
                value: new DateTime(2025, 11, 3, 12, 33, 15, 88, DateTimeKind.Utc).AddTicks(3028));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "Create_At",
                value: new DateTime(2025, 11, 3, 12, 33, 15, 88, DateTimeKind.Utc).AddTicks(3030));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "Create_At",
                value: new DateTime(2025, 11, 3, 12, 33, 15, 88, DateTimeKind.Utc).AddTicks(3032));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "Create_At",
                value: new DateTime(2025, 11, 3, 12, 33, 15, 88, DateTimeKind.Utc).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "Create_At",
                value: new DateTime(2025, 11, 3, 12, 33, 15, 88, DateTimeKind.Utc).AddTicks(3035));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 8,
                column: "Create_At",
                value: new DateTime(2025, 11, 3, 12, 33, 15, 88, DateTimeKind.Utc).AddTicks(3037));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 9,
                column: "Create_At",
                value: new DateTime(2025, 11, 3, 12, 33, 15, 88, DateTimeKind.Utc).AddTicks(3040));
        }
    }
}
