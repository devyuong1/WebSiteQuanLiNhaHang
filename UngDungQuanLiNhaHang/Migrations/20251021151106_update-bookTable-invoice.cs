using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class updatebookTableinvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HangfireJobId",
                table: "invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HangfireJobId",
                table: "bookTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                columns: new[] { "Create_At", "HangfireJobId" },
                values: new object[] { new DateTime(2025, 10, 21, 15, 11, 3, 262, DateTimeKind.Utc).AddTicks(6410), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                columns: new[] { "Create_At", "HangfireJobId" },
                values: new object[] { new DateTime(2025, 10, 21, 15, 11, 3, 262, DateTimeKind.Utc).AddTicks(6414), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "Create_At", "HangfireJobId" },
                values: new object[] { new DateTime(2025, 10, 21, 15, 11, 3, 262, DateTimeKind.Utc).AddTicks(6417), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "Create_At", "HangfireJobId" },
                values: new object[] { new DateTime(2025, 10, 21, 15, 11, 3, 262, DateTimeKind.Utc).AddTicks(6418), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "Create_At", "HangfireJobId" },
                values: new object[] { new DateTime(2025, 10, 21, 15, 11, 3, 262, DateTimeKind.Utc).AddTicks(6421), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "Create_At", "HangfireJobId" },
                values: new object[] { new DateTime(2025, 10, 21, 15, 11, 3, 262, DateTimeKind.Utc).AddTicks(6423), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "Create_At", "HangfireJobId" },
                values: new object[] { new DateTime(2025, 10, 21, 15, 11, 3, 262, DateTimeKind.Utc).AddTicks(6425), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 8,
                columns: new[] { "Create_At", "HangfireJobId" },
                values: new object[] { new DateTime(2025, 10, 21, 15, 11, 3, 262, DateTimeKind.Utc).AddTicks(6427), null });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 9,
                columns: new[] { "Create_At", "HangfireJobId" },
                values: new object[] { new DateTime(2025, 10, 21, 15, 11, 3, 262, DateTimeKind.Utc).AddTicks(6428), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HangfireJobId",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "HangfireJobId",
                table: "bookTables");

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 10, 17, 14, 27, 56, 891, DateTimeKind.Utc).AddTicks(3634));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 10, 17, 14, 27, 56, 891, DateTimeKind.Utc).AddTicks(3637));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "Create_At",
                value: new DateTime(2025, 10, 17, 14, 27, 56, 891, DateTimeKind.Utc).AddTicks(3639));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "Create_At",
                value: new DateTime(2025, 10, 17, 14, 27, 56, 891, DateTimeKind.Utc).AddTicks(3641));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "Create_At",
                value: new DateTime(2025, 10, 17, 14, 27, 56, 891, DateTimeKind.Utc).AddTicks(3642));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "Create_At",
                value: new DateTime(2025, 10, 17, 14, 27, 56, 891, DateTimeKind.Utc).AddTicks(3644));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "Create_At",
                value: new DateTime(2025, 10, 17, 14, 27, 56, 891, DateTimeKind.Utc).AddTicks(3645));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 8,
                column: "Create_At",
                value: new DateTime(2025, 10, 17, 14, 27, 56, 891, DateTimeKind.Utc).AddTicks(3647));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 9,
                column: "Create_At",
                value: new DateTime(2025, 10, 17, 14, 27, 56, 891, DateTimeKind.Utc).AddTicks(3649));
        }
    }
}
