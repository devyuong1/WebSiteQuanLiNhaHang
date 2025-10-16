using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class updatebooktable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "bookTables");

            migrationBuilder.AddColumn<int>(
                name: "productOptionId",
                table: "orderItemOptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "employeeId",
                table: "invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "bookTableStatusId",
                table: "bookTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookTableStatus",
                columns: table => new
                {
                    bookTableStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTableStatus", x => x.bookTableStatusId);
                });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                columns: new[] { "Create_At", "Note", "employeeId" },
                values: new object[] { new DateTime(2025, 10, 16, 10, 37, 27, 446, DateTimeKind.Utc).AddTicks(5887), null, 0 });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                columns: new[] { "Create_At", "Note", "employeeId" },
                values: new object[] { new DateTime(2025, 10, 16, 10, 37, 27, 446, DateTimeKind.Utc).AddTicks(5891), null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_bookTables_bookTableStatusId",
                table: "bookTables",
                column: "bookTableStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookTables_BookTableStatus_bookTableStatusId",
                table: "bookTables",
                column: "bookTableStatusId",
                principalTable: "BookTableStatus",
                principalColumn: "bookTableStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookTables_BookTableStatus_bookTableStatusId",
                table: "bookTables");

            migrationBuilder.DropTable(
                name: "BookTableStatus");

            migrationBuilder.DropIndex(
                name: "IX_bookTables_bookTableStatusId",
                table: "bookTables");

            migrationBuilder.DropColumn(
                name: "productOptionId",
                table: "orderItemOptions");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "employeeId",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "bookTableStatusId",
                table: "bookTables");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "bookTables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 10, 11, 7, 57, 55, 719, DateTimeKind.Utc).AddTicks(1339));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 10, 11, 7, 57, 55, 719, DateTimeKind.Utc).AddTicks(1342));
        }
    }
}
