using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class Updatebooktable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookTables_customers_CustomersCustomerId",
                table: "bookTables");

            migrationBuilder.DropIndex(
                name: "IX_bookTables_CustomersCustomerId",
                table: "bookTables");

            migrationBuilder.DropColumn(
                name: "CustomersCustomerId",
                table: "bookTables");

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

            migrationBuilder.CreateIndex(
                name: "IX_bookTables_customerId",
                table: "bookTables",
                column: "customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookTables_customers_customerId",
                table: "bookTables",
                column: "customerId",
                principalTable: "customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookTables_customers_customerId",
                table: "bookTables");

            migrationBuilder.DropIndex(
                name: "IX_bookTables_customerId",
                table: "bookTables");

            migrationBuilder.AddColumn<int>(
                name: "CustomersCustomerId",
                table: "bookTables",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 10, 21, 15, 11, 3, 262, DateTimeKind.Utc).AddTicks(6410));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 10, 21, 15, 11, 3, 262, DateTimeKind.Utc).AddTicks(6414));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "Create_At",
                value: new DateTime(2025, 10, 21, 15, 11, 3, 262, DateTimeKind.Utc).AddTicks(6417));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "Create_At",
                value: new DateTime(2025, 10, 21, 15, 11, 3, 262, DateTimeKind.Utc).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "Create_At",
                value: new DateTime(2025, 10, 21, 15, 11, 3, 262, DateTimeKind.Utc).AddTicks(6421));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "Create_At",
                value: new DateTime(2025, 10, 21, 15, 11, 3, 262, DateTimeKind.Utc).AddTicks(6423));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "Create_At",
                value: new DateTime(2025, 10, 21, 15, 11, 3, 262, DateTimeKind.Utc).AddTicks(6425));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 8,
                column: "Create_At",
                value: new DateTime(2025, 10, 21, 15, 11, 3, 262, DateTimeKind.Utc).AddTicks(6427));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 9,
                column: "Create_At",
                value: new DateTime(2025, 10, 21, 15, 11, 3, 262, DateTimeKind.Utc).AddTicks(6428));

            migrationBuilder.CreateIndex(
                name: "IX_bookTables_CustomersCustomerId",
                table: "bookTables",
                column: "CustomersCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookTables_customers_CustomersCustomerId",
                table: "bookTables",
                column: "CustomersCustomerId",
                principalTable: "customers",
                principalColumn: "CustomerId");
        }
    }
}
