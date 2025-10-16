using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class updateEmpoyyee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "Password",
                value: "thanhtam1$2a$11$VNeE3dx3kAH4jlMywC81duZnXD.jDTIHPmNkxIeYSHJovscjL7FJa");

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$VNeE3dx3kAH4jlMywC81duZnXD.jDTIHPmNkxIeYSHJovscjL7FJa");

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$VNeE3dx3kAH4jlMywC81duZnXD.jDTIHPmNkxIeYSHJovscjL7FJa");

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "EmployeeId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$VNeE3dx3kAH4jlMywC81duZnXD.jDTIHPmNkxIeYSHJovscjL7FJa");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "Password",
                value: "thanhtam1");

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "Password",
                value: "thanhtam1");

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "Password",
                value: "thanhtam1");

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "EmployeeId",
                keyValue: 4,
                column: "Password",
                value: "thanhtam1");

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
        }
    }
}
