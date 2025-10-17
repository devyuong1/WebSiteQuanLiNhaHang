using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class updateData3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "CustomerId", "Email", "FullName", "IsActive", "Password", "Phone", "RoleId" },
                values: new object[,]
                {
                    { 3, "c@gmail.com", "Nguyễn Văn C", true, "$2a$11$VNeE3dx3kAH4jlMywC81duZnXD.jDTIHPmNkxIeYSHJovscjL7FJa", "0909092381", 4 },
                    { 4, "b@gmail.com", "Nguyễn Văn D", true, "$2a$11$VNeE3dx3kAH4jlMywC81duZnXD.jDTIHPmNkxIeYSHJovscjL7FJa", "0909092339", 4 },
                    { 5, "e@gmail.com", "Nguyễn Văn E", true, "$2a$11$VNeE3dx3kAH4jlMywC81duZnXD.jDTIHPmNkxIeYSHJovscjL7FJa", "0909022389", 4 },
                    { 6, "f@gmail.com", "Nguyễn Văn F", true, "$2a$11$VNeE3dx3kAH4jlMywC81duZnXD.jDTIHPmNkxIeYSHJovscjL7FJa", "0909092389", 4 },
                    { 7, "q@gmail.com", "Nguyễn Văn Q", true, "$2a$11$VNeE3dx3kAH4jlMywC81duZnXD.jDTIHPmNkxIeYSHJovscjL7FJa", "0909099389", 4 }
                });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 10, 17, 13, 8, 37, 338, DateTimeKind.Utc).AddTicks(9352));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 10, 17, 13, 8, 37, 338, DateTimeKind.Utc).AddTicks(9355));

            migrationBuilder.InsertData(
                table: "invoices",
                columns: new[] { "InvoiceId", "AddressId", "Create_At", "InvoiceStatusId", "InvoiceType", "IsPayment", "Note", "PaymentMethodId", "TotalAmount", "TotalQuantity", "customerId", "customersCustomerId", "employeeId", "tableId", "tablesTableId" },
                values: new object[,]
                {
                    { 3, 1, new DateTime(2025, 10, 17, 13, 8, 37, 338, DateTimeKind.Utc).AddTicks(9357), 4, false, true, null, 3, 50000.0, 1, 1, null, 0, null, null },
                    { 4, 1, new DateTime(2025, 10, 17, 13, 8, 37, 338, DateTimeKind.Utc).AddTicks(9359), 4, false, true, null, 3, 50000.0, 1, 2, null, 0, null, null },
                    { 5, 1, new DateTime(2025, 10, 17, 13, 8, 37, 338, DateTimeKind.Utc).AddTicks(9361), 4, false, true, null, 3, 50000.0, 1, 3, null, 0, null, null },
                    { 6, 1, new DateTime(2025, 10, 17, 13, 8, 37, 338, DateTimeKind.Utc).AddTicks(9362), 4, false, true, null, 3, 50000.0, 1, 4, null, 0, null, null },
                    { 7, 1, new DateTime(2025, 10, 17, 13, 8, 37, 338, DateTimeKind.Utc).AddTicks(9364), 4, false, true, null, 3, 50000.0, 1, 5, null, 0, null, null },
                    { 8, 1, new DateTime(2025, 10, 17, 13, 8, 37, 338, DateTimeKind.Utc).AddTicks(9366), 4, false, true, null, 3, 50000.0, 1, 6, null, 0, null, null },
                    { 9, 1, new DateTime(2025, 10, 17, 13, 8, 37, 338, DateTimeKind.Utc).AddTicks(9367), 4, false, true, null, 3, 50000.0, 1, 7, null, 0, null, null }
                });

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 7,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "AverageRating", "TotalReviews" },
                values: new object[] { 3.7000000000000002, 7 });

            migrationBuilder.InsertData(
                table: "invoicesItems",
                columns: new[] { "InvoiceItemId", "InvoiceId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 5, 3, 50000.0, 1, 1 },
                    { 6, 4, 50000.0, 1, 1 },
                    { 7, 5, 50000.0, 1, 1 },
                    { 8, 6, 50000.0, 1, 1 },
                    { 9, 7, 50000.0, 1, 1 },
                    { 10, 8, 50000.0, 1, 1 },
                    { 11, 9, 50000.0, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "productReviews",
                columns: new[] { "ProductReviewId", "Comment", "Create_At", "CustomerId", "InvoiceId", "ProductId", "Rating" },
                values: new object[,]
                {
                    { 1, "Good", new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 1, 5 },
                    { 2, "Sản phẩm tốt", new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 1, 5 },
                    { 3, "5 sao", new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, 1, 5 },
                    { 4, "Tạm ổn ", new DateTime(2025, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 6, 1, 4 },
                    { 5, "Hợp khẩu vị", new DateTime(2025, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 7, 1, 4 },
                    { 6, "Dở ", new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 8, 1, 1 },
                    { 7, "Không ngon", new DateTime(2025, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 9, 1, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "invoicesItems",
                keyColumn: "InvoiceItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "invoicesItems",
                keyColumn: "InvoiceItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "invoicesItems",
                keyColumn: "InvoiceItemId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "invoicesItems",
                keyColumn: "InvoiceItemId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "invoicesItems",
                keyColumn: "InvoiceItemId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "invoicesItems",
                keyColumn: "InvoiceItemId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "invoicesItems",
                keyColumn: "InvoiceItemId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "productReviews",
                keyColumn: "ProductReviewId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "productReviews",
                keyColumn: "ProductReviewId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "productReviews",
                keyColumn: "ProductReviewId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "productReviews",
                keyColumn: "ProductReviewId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "productReviews",
                keyColumn: "ProductReviewId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "productReviews",
                keyColumn: "ProductReviewId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "productReviews",
                keyColumn: "ProductReviewId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "CustomerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "CustomerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "Create_At",
                value: new DateTime(2025, 10, 17, 12, 31, 56, 822, DateTimeKind.Utc).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "Create_At",
                value: new DateTime(2025, 10, 17, 12, 31, 56, 822, DateTimeKind.Utc).AddTicks(1085));

            migrationBuilder.UpdateData(
                table: "productOptions",
                keyColumn: "ProductOptionId",
                keyValue: 7,
                column: "ProductId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "AverageRating", "TotalReviews" },
                values: new object[] { 5.0, 1 });
        }
    }
}
