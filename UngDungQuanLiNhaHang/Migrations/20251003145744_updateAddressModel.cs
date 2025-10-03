using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class updateAddressModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HouseNumber",
                table: "addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4519));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4522));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4244), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4246) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4251), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4251) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4253), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4254) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4255), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4255) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4285), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4285) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4289), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4290) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4291), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4291) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4293), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4293) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 9,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4294), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4295) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 10,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4296), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4296) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 11,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4298), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4298) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 12,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4299), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4300) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 13,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4301), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4301) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 14,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4303), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4303) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 15,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4304), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4304) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 16,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4306), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4306) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 17,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4307), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4308) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 18,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4309), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4309) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 19,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4311), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4311) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 20,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4312), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4312) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 21,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4314), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4314) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 22,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4316), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4317) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 23,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4318), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4318) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 24,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4319), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4320) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 25,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4321), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4321) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 26,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4322), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4323) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 27,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4324), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4324) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 28,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4326), new DateTime(2025, 10, 3, 14, 57, 43, 631, DateTimeKind.Utc).AddTicks(4326) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HouseNumber",
                table: "addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
