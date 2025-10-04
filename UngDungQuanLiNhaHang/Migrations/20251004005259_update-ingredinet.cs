using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class updateingredinet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4898));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4615), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4618) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4624), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4624) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4627), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4627) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4629), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4629) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4631), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4631) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4633), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4634) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4635), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4635) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4637), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4637) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 9,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4639), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4639) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 10,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4640), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4640) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 11,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4642), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4642) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 12,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4644), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4644) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 13,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4645), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4645) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 14,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4647), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4647) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 15,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4648), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4648) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 16,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4650), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4650) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 17,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4651), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4652) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 18,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4653), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4653) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 19,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4654), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4655) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 20,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4656), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4656) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 21,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4658), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4658) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 22,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4660), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4660) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 23,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4662), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4662) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 24,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4663), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4664) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 25,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4706), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4707) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 26,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4708), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4708) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 27,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4710), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4710) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 28,
                columns: new[] { "Create_At", "Update_At" },
                values: new object[] { new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4712), new DateTime(2025, 10, 4, 0, 52, 58, 495, DateTimeKind.Utc).AddTicks(4712) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
