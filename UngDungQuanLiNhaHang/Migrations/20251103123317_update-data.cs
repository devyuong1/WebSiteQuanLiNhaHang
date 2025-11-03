using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class updatedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "paymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 3,
                column: "PaymentMethodName",
                value: "Thanh toán khi nhận hàng");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "paymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 3,
                column: "PaymentMethodName",
                value: "Thahh Toán Khi Nhận Hàng");
        }
    }
}
