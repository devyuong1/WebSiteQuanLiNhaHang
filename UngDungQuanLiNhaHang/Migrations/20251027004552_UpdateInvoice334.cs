using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInvoice334 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoices_customers_customersCustomerId",
                table: "invoices");

            migrationBuilder.DropIndex(
                name: "IX_invoices_customersCustomerId",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "customersCustomerId",
                table: "invoices");

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

            migrationBuilder.CreateIndex(
                name: "IX_invoices_customerId",
                table: "invoices",
                column: "customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_invoices_customers_customerId",
                table: "invoices",
                column: "customerId",
                principalTable: "customers",
                principalColumn: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoices_customers_customerId",
                table: "invoices");

            migrationBuilder.DropIndex(
                name: "IX_invoices_customerId",
                table: "invoices");

            migrationBuilder.AddColumn<int>(
                name: "customersCustomerId",
                table: "invoices",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                columns: new[] { "Create_At", "customersCustomerId" },
                values: new object[] { new DateTime(2025, 10, 25, 14, 51, 31, 457, DateTimeKind.Utc).AddTicks(3148), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                columns: new[] { "Create_At", "customersCustomerId" },
                values: new object[] { new DateTime(2025, 10, 25, 14, 51, 31, 457, DateTimeKind.Utc).AddTicks(3152), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "Create_At", "customersCustomerId" },
                values: new object[] { new DateTime(2025, 10, 25, 14, 51, 31, 457, DateTimeKind.Utc).AddTicks(3154), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "Create_At", "customersCustomerId" },
                values: new object[] { new DateTime(2025, 10, 25, 14, 51, 31, 457, DateTimeKind.Utc).AddTicks(3156), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "Create_At", "customersCustomerId" },
                values: new object[] { new DateTime(2025, 10, 25, 14, 51, 31, 457, DateTimeKind.Utc).AddTicks(3158), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "Create_At", "customersCustomerId" },
                values: new object[] { new DateTime(2025, 10, 25, 14, 51, 31, 457, DateTimeKind.Utc).AddTicks(3159), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "Create_At", "customersCustomerId" },
                values: new object[] { new DateTime(2025, 10, 25, 14, 51, 31, 457, DateTimeKind.Utc).AddTicks(3161), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 8,
                columns: new[] { "Create_At", "customersCustomerId" },
                values: new object[] { new DateTime(2025, 10, 25, 14, 51, 31, 457, DateTimeKind.Utc).AddTicks(3163), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 9,
                columns: new[] { "Create_At", "customersCustomerId" },
                values: new object[] { new DateTime(2025, 10, 25, 14, 51, 31, 457, DateTimeKind.Utc).AddTicks(3164), null });

            migrationBuilder.CreateIndex(
                name: "IX_invoices_customersCustomerId",
                table: "invoices",
                column: "customersCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_invoices_customers_customersCustomerId",
                table: "invoices",
                column: "customersCustomerId",
                principalTable: "customers",
                principalColumn: "CustomerId");
        }
    }
}
