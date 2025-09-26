using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "purchaseInvoice");

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6719));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6468), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6470) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6477), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6477) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6479), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6480) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6481), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6482) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6483), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6483) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6486), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6486) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6488), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6488) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6489), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 9,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6491), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6491) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 10,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6493), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6493) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 11,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6494), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6495) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 12,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6496), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6496) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 13,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6498), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6498) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 14,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6499), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6499) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 15,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6501), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6501) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 16,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6502), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6503) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 17,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6504), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6504) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 18,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6505), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6506) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 19,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6507), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6507) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 20,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6509), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6509) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 21,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6510), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6511) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 22,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6513), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6513) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 23,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6514), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6515) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 24,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6544), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6544) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 25,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6545), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6546) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 26,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6547), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6547) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 27,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6549), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6549) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 28,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6550), new DateTime(2025, 9, 26, 15, 58, 1, 443, DateTimeKind.Utc).AddTicks(6551) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "purchaseInvoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(6033));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(6036));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5730), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5732) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5740), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5740) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5742), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5743) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5744), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5744) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5746), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5746) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5748), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5748) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5750), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5751) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5752), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5752) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 9,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5754), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5754) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 10,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5755), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5756) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 11,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5814), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5814) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 12,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5816), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5816) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 13,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5818), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5818) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 14,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5819), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5819) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 15,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5821), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5821) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 16,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5822), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5823) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 17,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5824), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5824) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 18,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5826), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5826) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 19,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5828), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5828) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 20,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5829), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5829) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 21,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5831), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5831) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 22,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5832), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5833) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 23,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5835), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5835) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 24,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5837), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5837) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 25,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5838), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5839) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 26,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5840), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5840) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 27,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5842), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5842) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 28,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5843), new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5844) });
        }
    }
}
