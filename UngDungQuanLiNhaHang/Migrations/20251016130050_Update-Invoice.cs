using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_productReviews_InvoiceId",
                table: "productReviews");

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 10, 16, 13, 0, 48, 574, DateTimeKind.Utc).AddTicks(9225));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 10, 16, 13, 0, 48, 574, DateTimeKind.Utc).AddTicks(9228));

            migrationBuilder.CreateIndex(
                name: "IX_productReviews_InvoiceId",
                table: "productReviews",
                column: "InvoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_productReviews_InvoiceId",
                table: "productReviews");

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 10, 16, 10, 37, 27, 446, DateTimeKind.Utc).AddTicks(5887));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 10, 16, 10, 37, 27, 446, DateTimeKind.Utc).AddTicks(5891));

            migrationBuilder.CreateIndex(
                name: "IX_productReviews_InvoiceId",
                table: "productReviews",
                column: "InvoiceId",
                unique: true);
        }
    }
}
