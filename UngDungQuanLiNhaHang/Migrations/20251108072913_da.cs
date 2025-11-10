using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class da : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "tables",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 1,
                column: "Description",
                value: "Bàn tầng trệt");

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 2,
                column: "Description",
                value: "Bàn tầng trệt");

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 3,
                column: "Description",
                value: "Bàn tầng trệt");

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 4,
                column: "Description",
                value: "Bàn tầng trệt");

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 5,
                column: "Description",
                value: "Bàn tầng trệt");

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 6,
                column: "Description",
                value: "Bàn tầng trệt");

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 7,
                column: "Description",
                value: "Bàn tầng trệt");

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 8,
                column: "Description",
                value: "Bàn tầng trệt");

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 9,
                column: "Description",
                value: "Bàn tầng trệt");

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 10,
                column: "Description",
                value: "Bàn tầng trệt");

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 11,
                column: "Description",
                value: "Bàn tầng trệt");

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 12,
                column: "Description",
                value: "Bàn tầng trệt");

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 13,
                column: "Description",
                value: "Bàn tầng trệt");

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 14,
                column: "Description",
                value: "Bàn tầng 1");

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 15,
                column: "Description",
                value: "Bàn tầng 1");

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 16,
                column: "Description",
                value: "Bàn tầng 1");

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 17,
                column: "Description",
                value: "Bàn tầng 1");

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 18,
                column: "Description",
                value: "Bàn tầng 1");

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 19,
                column: "Description",
                value: "Bàn tầng 1");

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 20,
                column: "Description",
                value: "Bàn tầng 1");

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 21,
                column: "Description",
                value: "Bàn tầng 1");

            migrationBuilder.UpdateData(
                table: "tables",
                keyColumn: "TableId",
                keyValue: 22,
                column: "Description",
                value: "Bàn tầng 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "tables");

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
        }
    }
}
