using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class updateEmpoyyeee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$VNeE3dx3kAH4jlMywC81duZnXD.jDTIHPmNkxIeYSHJovscjL7FJa");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "Password",
                value: "thanhtam1$2a$11$VNeE3dx3kAH4jlMywC81duZnXD.jDTIHPmNkxIeYSHJovscjL7FJa");

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 10, 16, 15, 16, 27, 342, DateTimeKind.Utc).AddTicks(9021));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 10, 16, 15, 16, 27, 342, DateTimeKind.Utc).AddTicks(9024));
        }
    }
}
