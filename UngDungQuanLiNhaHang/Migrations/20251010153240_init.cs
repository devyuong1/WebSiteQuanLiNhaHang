using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hamlet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    MinQuantity = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredients", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "invoicesStatus",
                columns: table => new
                {
                    InvoiceStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoicesStatus", x => x.InvoiceStatusId);
                });

            migrationBuilder.CreateTable(
                name: "paymentMethods",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethodName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentMethods", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "tables",
                columns: table => new
                {
                    TableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tables", x => x.TableId);
                });

            migrationBuilder.CreateTable(
                name: "restaurants",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CloseTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurants", x => x.RestaurantId);
                    table.ForeignKey(
                        name: "FK_restaurants_addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.SupplierID);
                    table.ForeignKey(
                        name: "FK_suppliers_addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PriceSale = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SoldCount = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AverageRating = table.Column<double>(type: "float", nullable: false),
                    TotalReviews = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_products_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_customers_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_employees_addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employees_restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "restaurants",
                        principalColumn: "RestaurantId");
                    table.ForeignKey(
                        name: "FK_employees_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    ImagesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagesUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.ImagesId);
                    table.ForeignKey(
                        name: "FK_images_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productOptions",
                columns: table => new
                {
                    ProductOptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productOptions", x => x.ProductOptionId);
                    table.ForeignKey(
                        name: "FK_productOptions_ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productOptions_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipes", x => x.RecipeId);
                    table.ForeignKey(
                        name: "FK_recipes_ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_recipes_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "addressCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addressCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_addressCustomers_addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_addressCustomers_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookTables",
                columns: table => new
                {
                    BookTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepositAmount = table.Column<double>(type: "float", nullable: false),
                    IsDepositPaid = table.Column<bool>(type: "bit", nullable: false),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    TablesTableId = table.Column<int>(type: "int", nullable: true),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    CustomersCustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookTables", x => x.BookTableId);
                    table.ForeignKey(
                        name: "FK_bookTables_customers_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalTable: "customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_bookTables_tables_TablesTableId",
                        column: x => x.TablesTableId,
                        principalTable: "tables",
                        principalColumn: "TableId");
                });

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_carts_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPayment = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceType = table.Column<bool>(type: "bit", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: true),
                    customersCustomerId = table.Column<int>(type: "int", nullable: true),
                    tableId = table.Column<int>(type: "int", nullable: true),
                    tablesTableId = table.Column<int>(type: "int", nullable: true),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    InvoiceStatusId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_invoices_addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_invoices_customers_customersCustomerId",
                        column: x => x.customersCustomerId,
                        principalTable: "customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_invoices_invoicesStatus_InvoiceStatusId",
                        column: x => x.InvoiceStatusId,
                        principalTable: "invoicesStatus",
                        principalColumn: "InvoiceStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_invoices_paymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "paymentMethods",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_invoices_tables_tablesTableId",
                        column: x => x.tablesTableId,
                        principalTable: "tables",
                        principalColumn: "TableId");
                });

            migrationBuilder.CreateTable(
                name: "purchaseInvoice",
                columns: table => new
                {
                    PurchaseInvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Totalamount = table.Column<double>(type: "float", nullable: false),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPayment = table.Column<bool>(type: "bit", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseInvoice", x => x.PurchaseInvoiceId);
                    table.ForeignKey(
                        name: "FK_purchaseInvoice_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchaseInvoice_suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "suppliers",
                        principalColumn: "SupplierID");
                });

            migrationBuilder.CreateTable(
                name: "refreshTokens",
                columns: table => new
                {
                    RefreshTokensId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerId = table.Column<int>(type: "int", nullable: true),
                    CustomersCustomerId = table.Column<int>(type: "int", nullable: true),
                    employeeId = table.Column<int>(type: "int", nullable: true),
                    EmployeesEmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refreshTokens", x => x.RefreshTokensId);
                    table.ForeignKey(
                        name: "FK_refreshTokens_customers_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalTable: "customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_refreshTokens_employees_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "employees",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "cartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_cartItems_carts_CartId",
                        column: x => x.CartId,
                        principalTable: "carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cartItems_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "invoicesItems",
                columns: table => new
                {
                    InvoiceItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoicesItems", x => x.InvoiceItemId);
                    table.ForeignKey(
                        name: "FK_invoicesItems_invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_invoicesItems_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productReviews",
                columns: table => new
                {
                    ProductReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productReviews", x => x.ProductReviewId);
                    table.ForeignKey(
                        name: "FK_productReviews_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productReviews_invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productReviews_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseInvoiceItem",
                columns: table => new
                {
                    PurchaseInvoiceItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseInvoiceId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseInvoiceItem", x => x.PurchaseInvoiceItemID);
                    table.ForeignKey(
                        name: "FK_purchaseInvoiceItem_ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchaseInvoiceItem_purchaseInvoice_PurchaseInvoiceId",
                        column: x => x.PurchaseInvoiceId,
                        principalTable: "purchaseInvoice",
                        principalColumn: "PurchaseInvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderItemOptions",
                columns: table => new
                {
                    OrderItemOptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderItemOptionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    InvoiceItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItemOptions", x => x.OrderItemOptionId);
                    table.ForeignKey(
                        name: "FK_orderItemOptions_invoicesItems_InvoiceItemId",
                        column: x => x.InvoiceItemId,
                        principalTable: "invoicesItems",
                        principalColumn: "InvoiceItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "addresses",
                columns: new[] { "AddressId", "District", "Hamlet", "HouseNumber", "IsDefault", "Province", "Street" },
                values: new object[,]
                {
                    { 1, "Phường Ninh Kiều", " Khu vực 7", "123", true, "Cần Thơ", "Đường 3/2" },
                    { 2, "Phường Ninh Kiều", " Khu vực 7", "124", true, "Cần Thơ", "Đường Nguyễn Văn Cừ" },
                    { 3, "Phường Ninh Kiều", " Khu vực 7", "125", true, "Cần Thơ", "Đường 30/4" },
                    { 4, "Phường Ninh Kiều", " Khu vực 7", "32", true, "Cần Thơ", "Đường 19/8" },
                    { 5, "Phường Cái Răng", " Khu vực 6", "54", true, "Cần Thơ", "Đường 19/8" },
                    { 6, "Phường Ninh Kiều", " Khu vực 7", "23", true, "Cần Thơ", "Đường 19/8" },
                    { 7, "Phường Cái Răng", " Khu vực 7", "45", true, "Cần Thơ", "Đường Lê Bình" },
                    { 8, "Phường Thốt Nốt", " Khu vực 7", "45", true, "Cần Thơ", "Đường Lê Bình" },
                    { 9, "Phường Thốt Nốt", " Khu vực 7", "45", true, "Cần Thơ", "Đường Lê Bình" },
                    { 10, "Phường Thốt Nốt", " Khu vực 7", "45", true, "Cần Thơ", "Đường Lê Bình" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryId", "CategoryName", "IsActive" },
                values: new object[,]
                {
                    { 1, "Món Xào", true },
                    { 2, "Món Hấp", true },
                    { 3, "Món Lẩu", true },
                    { 4, "Món Nướng", true },
                    { 5, "Món Bún/Phở", true },
                    { 6, "Nước Uống", true }
                });

            migrationBuilder.InsertData(
                table: "ingredients",
                columns: new[] { "IngredientId", "IngredientName", "IsActive", "MinQuantity", "Price", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 1, "Thịt Bò", true, 1.0, 200000.0, 10.0, "kg" },
                    { 2, "Bánh Phở", true, 1.0, 30000.0, 4.0, "kg" },
                    { 3, "Nước Phở", true, 1.0, 10000.0, 10.0, "lít" },
                    { 4, "Nước Bún Bò", true, 1.0, 10000.0, 10.0, "lít" },
                    { 5, "Giò Heo ", true, 1.0, 120000.0, 3.0, "kg" },
                    { 6, "Huyết Heo", true, 1.0, 100000.0, 2.0, "kg" },
                    { 7, "Bún", true, 1.0, 15000.0, 2.0, "kg" },
                    { 8, "Chả Lụa", true, 1.0, 100000.0, 2.0, "kg" },
                    { 9, "Thịt Heo", true, 1.0, 200000.0, 5.0, "kg" },
                    { 10, "Mọc", true, 1.0, 150000.0, 2.0, "kg" },
                    { 11, "Mực", true, 1.0, 250000.0, 2.0, "kg" },
                    { 12, "Tôm sú", true, 1.0, 250000.0, 4.0, "kg" },
                    { 13, "Tôm Hùm", true, 1.0, 450000.0, 3.0, "kg" },
                    { 14, "Cua", true, 1.0, 350000.0, 3.0, "kg" },
                    { 15, "Ghẹ", true, 1.0, 300000.0, 3.0, "kg" },
                    { 16, "Bơ", true, 1.0, 100000.0, 3.0, "kg" },
                    { 17, "Phô mai", true, 1.0, 100000.0, 3.0, "kg" },
                    { 18, "Cá Đuối", true, 1.0, 100000.0, 3.0, "kg" },
                    { 19, "Măng Chua", true, 1.0, 100000.0, 3.0, "kg" },
                    { 20, "Hàu", true, 5.0, 800000.0, 20.0, "kg" },
                    { 21, "Óc móng tay", true, 5.0, 100000.0, 20.0, "kg" },
                    { 22, "Miến", true, 5.0, 50000.0, 20.0, "kg" },
                    { 23, "Trứng Muối", true, 2.0, 100000.0, 20.0, "trứng" },
                    { 24, "Ốc Hương", true, 2.0, 200000.0, 20.0, "kg" },
                    { 25, "Gạo", true, 2.0, 20000.0, 20.0, "kg" },
                    { 26, "Mì", true, 20.0, 5000.0, 200.0, "gói" },
                    { 27, "Sò Huyết", true, 2.0, 200000.0, 20.0, "kg" },
                    { 28, "Cá Mú", true, 2.0, 250000.0, 20.0, "kg" }
                });

            migrationBuilder.InsertData(
                table: "invoicesStatus",
                columns: new[] { "InvoiceStatusId", "Description", "InvoiceStatusName" },
                values: new object[,]
                {
                    { 1, "Chờ Xác Nhận", "Pending" },
                    { 2, "Đã Xác Nhận", "Confirmed" },
                    { 3, "Đang Giao Hàng", "Shipping" },
                    { 4, "Đã Giao", "Delivered" },
                    { 5, "Đã Hủy", "Cancelled" },
                    { 6, "Trả hàng", "Returned" }
                });

            migrationBuilder.InsertData(
                table: "paymentMethods",
                columns: new[] { "PaymentMethodId", "PaymentMethodName" },
                values: new object[,]
                {
                    { 1, "VNPay" },
                    { 2, "MoMo" },
                    { 3, "Thahh Toán Khi Nhận Hàng" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "RoleId", "Description", "IsActive", "RoleName" },
                values: new object[,]
                {
                    { 1, "Chủ nhà hàng", true, "Admin" },
                    { 2, "Quản lí", true, "Manager" },
                    { 3, "Nhân viên", true, "Employee" },
                    { 4, "Khách Hàng", true, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "CustomerId", "Email", "FullName", "IsActive", "Password", "Phone", "RoleId" },
                values: new object[,]
                {
                    { 1, "a@gmail.com", "Nguyễn Văn A", true, "$2a$11$VNeE3dx3kAH4jlMywC81duZnXD.jDTIHPmNkxIeYSHJovscjL7FJa", "0909092321", 4 },
                    { 2, "b@gmail.com", "Nguyễn Văn B", true, "$2a$11$VNeE3dx3kAH4jlMywC81duZnXD.jDTIHPmNkxIeYSHJovscjL7FJa", "0909092389", 4 }
                });

            migrationBuilder.InsertData(
                table: "invoices",
                columns: new[] { "InvoiceId", "AddressId", "Create_At", "InvoiceStatusId", "InvoiceType", "IsPayment", "PaymentMethodId", "TotalAmount", "TotalQuantity", "customerId", "customersCustomerId", "tableId", "tablesTableId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 10, 10, 15, 32, 40, 317, DateTimeKind.Utc).AddTicks(8938), 4, false, true, 1, 400000.0, 3, 1, null, null, null },
                    { 2, 1, new DateTime(2025, 10, 10, 15, 32, 40, 317, DateTimeKind.Utc).AddTicks(8941), 4, false, false, 3, 270000.0, 2, 1, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "AverageRating", "CategoryId", "Create_At", "Description", "IsActive", "Price", "PriceSale", "ProductName", "Quantity", "SoldCount", "TotalReviews", "Update_At" },
                values: new object[,]
                {
                    { 1, 5.0, 5, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 50000.0, 45000.0, "Phở Bò", 40, 2000, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 5.0, 5, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 55000.0, 50000.0, "Bún Bò", 40, 100, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 5.0, 5, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 55000.0, 50000.0, "Bún Mọc", 30, 100, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 5.0, 5, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 80000.0, 75000.0, "Bún Hải Sản", 30, 100, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5.0, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 250000.0, 250000.0, "Cua Sốt Bơ Tỏi", 30, 100, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 5.0, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 250000.0, 250000.0, "Cua Sốt Phô Mai", 30, 100, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 5.0, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 250000.0, 250000.0, "Tôm Hùm Sốt Bơ Tỏi", 30, 100, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 5.0, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 250000.0, 250000.0, "Tôm Hùm Sốt Phô Mai", 30, 100, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 5.0, 3, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 300000.0, 250000.0, "Lẩu Hải Sản", 30, 100, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 5.0, 3, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 200000.0, 200000.0, "Lẩu Cá Đuối", 30, 100, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 5.0, 2, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 200000.0, 200000.0, "Mực Hấp ", 30, 100, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 5.0, 4, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 100000.0, 90000.0, "Bò Nướng Ngói", 30, 100, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 5.0, 4, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 80000.0, 70000.0, "Hàu Nướng Mỡ Hành", 30, 200, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 5.0, 4, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 80000.0, 70000.0, "Hàu Nướng Phô Mai", 30, 200, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 5.0, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 80000.0, 70000.0, "Ốc Móng Tay Cháy Tỏi", 30, 200, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 5.0, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 80000.0, 70000.0, "Miến Xào Thịt Cua", 30, 200, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 5.0, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 150000.0, 140000.0, "Ốc Hương Sốt Trứng Muối", 50, 200, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 5.0, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 150000.0, 140000.0, "Cơm Chiên Hải Sản", 50, 200, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 5.0, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 150000.0, 140000.0, "Mì Xào Bò", 50, 200, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 5.0, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 120000.0, 100000.0, "Sò Huyết Cháy Tỏi", 50, 200, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 5.0, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 120000.0, 100000.0, "Sò Huyết Sốt Thái", 50, 200, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 5.0, 2, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "1 phần gồm 300g mực tươi hấp với hành và các gia vị.", true, 120000.0, 100000.0, "Mực Hấp Hành", 50, 200, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 5.0, 2, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "1 phần gồm 1 con cá mú hấp vớ  các gia vị.", true, 200000.0, 100000.0, "Cá Mú Hấp", 50, 200, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 5.0, 2, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "1 phần gồm 500g Nghêu", true, 200000.0, 100000.0, "Nghêu Hấp", 50, 200, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 5.0, 5, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 20000.0, 18000.0, "Coca Cola Lon", 50, 200, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 5.0, 5, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 20000.0, 18000.0, "Pepsi Lon", 50, 200, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 5.0, 5, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 25000.0, 22000.0, "Bia Tiger Lon", 50, 200, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 5.0, 5, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 30000.0, 25000.0, "Bia Heniken Lon", 50, 200, 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "restaurants",
                columns: new[] { "RestaurantId", "AddressId", "CloseTime", "Email", "OpenTime", "Phone", "RestaurantName" },
                values: new object[] { 1, 1, new TimeSpan(0, 23, 30, 0, 0), "ThanhThien@gmail.com", new TimeSpan(0, 10, 0, 0, 0), "0989000030", "Nhà Hàng Thanh Thiên" });

            migrationBuilder.InsertData(
                table: "suppliers",
                columns: new[] { "SupplierID", "AddressId", "Email", "Phone", "SupplierName" },
                values: new object[,]
                {
                    { 1, 7, "ctyabc@gmail.com", "0239092399", "Công Ty Thực Phẩm Sạch ABC" },
                    { 2, 8, "haisan23@gmail.com", "0239092459", "Công Ty Hải Sản Cà Mau" }
                });

            migrationBuilder.InsertData(
                table: "addressCustomers",
                columns: new[] { "Id", "AddressId", "CustomerId" },
                values: new object[,]
                {
                    { 1, 9, 1 },
                    { 2, 10, 2 }
                });

            migrationBuilder.InsertData(
                table: "carts",
                columns: new[] { "CartId", "CustomerId", "TotalAmount", "TotalQuantity" },
                values: new object[,]
                {
                    { 1, 1, 0.0, 0 },
                    { 2, 2, 0.0, 0 }
                });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "EmployeeId", "AddressId", "Email", "Fullname", "IsActive", "Password", "Phone", "RestaurantId", "RoleId", "UserName" },
                values: new object[,]
                {
                    { 1, 2, "tam@gmail.com", "Nguyễn Thanh Tâm", true, "thanhtam1", "0909092324", 1, 1, "tam@gmail.com" },
                    { 2, 3, "thien@gmail.com", "Nguyễn Thanh Thiên", true, "thanhtam1", "0909092325", 1, 2, "thien@gmail.com" },
                    { 3, 4, "qui@gmail.com", "Nguyễn Hoàng Quí", true, "thanhtam1", "0909092326", 1, 3, "qui@gmail.com" },
                    { 4, 5, "phuc@gmail.com", "Nguyễn Hoàng Phúc", true, "thanhtam1", "0909092327", 1, 3, "phuc@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "images",
                columns: new[] { "ImagesId", "ImagesUrl", "ProductId" },
                values: new object[,]
                {
                    { 1, "/ImageProducts/product1.png", 1 },
                    { 2, "/ImageProducts/product2.png", 2 },
                    { 3, "/ImageProducts/product3.png", 3 },
                    { 4, "/ImageProducts/product4.png", 4 },
                    { 5, "/ImageProducts/product5.png", 5 },
                    { 6, "/ImageProducts/product6.png", 6 },
                    { 7, "/ImageProducts/product7.png", 7 },
                    { 8, "/ImageProducts/product8.png", 8 },
                    { 9, "/ImageProducts/product9.png", 9 },
                    { 10, "/ImageProducts/product10.png", 10 },
                    { 11, "/ImageProducts/product11.png", 11 },
                    { 12, "/ImageProducts/product12.png", 12 },
                    { 13, "/ImageProducts/product13.png", 13 },
                    { 14, "/ImageProducts/product14.png", 14 },
                    { 15, "/ImageProducts/product15.png", 15 },
                    { 16, "/ImageProducts/product16.png", 16 },
                    { 17, "/ImageProducts/product17.png", 17 },
                    { 18, "/ImageProducts/product18.png", 18 },
                    { 19, "/ImageProducts/product19.png", 19 },
                    { 20, "/ImageProducts/product20.png", 20 },
                    { 21, "/ImageProducts/product21.png", 21 },
                    { 22, "/ImageProducts/product22.png", 22 },
                    { 23, "/ImageProducts/product23.png", 23 },
                    { 24, "/ImageProducts/product24.png", 24 },
                    { 25, "/ImageProducts/product25.png", 25 },
                    { 26, "/ImageProducts/product26.png", 26 },
                    { 27, "/ImageProducts/product27.png", 27 },
                    { 28, "/ImageProducts/product28.png", 28 }
                });

            migrationBuilder.InsertData(
                table: "invoicesItems",
                columns: new[] { "InvoiceItemId", "InvoiceId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 75000.0, 4, 2 },
                    { 2, 1, 250000.0, 8, 1 },
                    { 3, 2, 120000.0, 22, 1 },
                    { 4, 2, 150000.0, 19, 1 }
                });

            migrationBuilder.InsertData(
                table: "recipes",
                columns: new[] { "RecipeId", "IngredientId", "ProductId", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 1, 1, 1, 100.0, "g" },
                    { 2, 2, 1, 200.0, "g" },
                    { 3, 3, 1, 300.0, "ml" },
                    { 4, 1, 2, 100.0, "g" },
                    { 5, 4, 2, 300.0, "ml" },
                    { 6, 5, 2, 50.0, "g" },
                    { 7, 6, 2, 50.0, "g" },
                    { 8, 7, 2, 200.0, "g" },
                    { 9, 9, 3, 100.0, "g" },
                    { 10, 8, 3, 50.0, "g" },
                    { 11, 7, 3, 100.0, "g" },
                    { 12, 10, 3, 50.0, "g" },
                    { 13, 11, 4, 50.0, "g" },
                    { 14, 12, 4, 50.0, "g" },
                    { 15, 14, 4, 50.0, "g" },
                    { 16, 15, 4, 50.0, "g" },
                    { 17, 7, 4, 150.0, "g" },
                    { 18, 14, 5, 2.0, "con" },
                    { 19, 16, 5, 100.0, "g" },
                    { 20, 14, 6, 2.0, "con" },
                    { 21, 17, 6, 100.0, "g" },
                    { 22, 13, 7, 1.0, "con" },
                    { 23, 16, 7, 100.0, "g" },
                    { 24, 13, 8, 1.0, "con" },
                    { 25, 17, 8, 100.0, "g" },
                    { 26, 11, 9, 200.0, "g" },
                    { 27, 12, 9, 200.0, "g" },
                    { 28, 14, 9, 200.0, "g" },
                    { 29, 1, 9, 200.0, "g" },
                    { 30, 7, 9, 200.0, "g" },
                    { 31, 18, 10, 500.0, "g" },
                    { 32, 19, 10, 200.0, "g" },
                    { 33, 11, 11, 300.0, "g" },
                    { 34, 1, 12, 200.0, "g" },
                    { 35, 20, 13, 1.0, "kg" },
                    { 36, 20, 14, 1.0, "kg" },
                    { 37, 21, 15, 300.0, "g" },
                    { 38, 22, 16, 200.0, "g" },
                    { 39, 14, 16, 200.0, "g" },
                    { 40, 24, 17, 300.0, "g" },
                    { 41, 23, 17, 100.0, "g" },
                    { 42, 12, 18, 200.0, "g" },
                    { 43, 11, 18, 200.0, "g" },
                    { 44, 25, 18, 200.0, "g" },
                    { 45, 26, 19, 300.0, "g" },
                    { 46, 1, 19, 200.0, "g" },
                    { 47, 27, 20, 300.0, "g" },
                    { 48, 27, 21, 300.0, "g" },
                    { 49, 11, 22, 300.0, "g" },
                    { 50, 28, 23, 500.0, "g" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_addressCustomers_AddressId",
                table: "addressCustomers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_addressCustomers_CustomerId",
                table: "addressCustomers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_bookTables_CustomersCustomerId",
                table: "bookTables",
                column: "CustomersCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_bookTables_TablesTableId",
                table: "bookTables",
                column: "TablesTableId");

            migrationBuilder.CreateIndex(
                name: "IX_cartItems_CartId",
                table: "cartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_cartItems_ProductId",
                table: "cartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_carts_CustomerId",
                table: "carts",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customers_RoleId",
                table: "customers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_AddressId",
                table: "employees",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_RestaurantId",
                table: "employees",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_RoleId",
                table: "employees",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_images_ProductId",
                table: "images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_AddressId",
                table: "invoices",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_customersCustomerId",
                table: "invoices",
                column: "customersCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_InvoiceStatusId",
                table: "invoices",
                column: "InvoiceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_PaymentMethodId",
                table: "invoices",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_tablesTableId",
                table: "invoices",
                column: "tablesTableId");

            migrationBuilder.CreateIndex(
                name: "IX_invoicesItems_InvoiceId",
                table: "invoicesItems",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_invoicesItems_ProductId",
                table: "invoicesItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItemOptions_InvoiceItemId",
                table: "orderItemOptions",
                column: "InvoiceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_productOptions_IngredientId",
                table: "productOptions",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_productOptions_ProductId",
                table: "productOptions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_productReviews_CustomerId",
                table: "productReviews",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_productReviews_InvoiceId",
                table: "productReviews",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_productReviews_ProductId",
                table: "productReviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseInvoice_EmployeeId",
                table: "purchaseInvoice",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseInvoice_SupplierId",
                table: "purchaseInvoice",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseInvoiceItem_IngredientId",
                table: "purchaseInvoiceItem",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseInvoiceItem_PurchaseInvoiceId",
                table: "purchaseInvoiceItem",
                column: "PurchaseInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_recipes_IngredientId",
                table: "recipes",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_recipes_ProductId",
                table: "recipes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_refreshTokens_CustomersCustomerId",
                table: "refreshTokens",
                column: "CustomersCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_refreshTokens_EmployeesEmployeeId",
                table: "refreshTokens",
                column: "EmployeesEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_restaurants_AddressId",
                table: "restaurants",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_AddressId",
                table: "suppliers",
                column: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addressCustomers");

            migrationBuilder.DropTable(
                name: "bookTables");

            migrationBuilder.DropTable(
                name: "cartItems");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "orderItemOptions");

            migrationBuilder.DropTable(
                name: "productOptions");

            migrationBuilder.DropTable(
                name: "productReviews");

            migrationBuilder.DropTable(
                name: "purchaseInvoiceItem");

            migrationBuilder.DropTable(
                name: "recipes");

            migrationBuilder.DropTable(
                name: "refreshTokens");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropTable(
                name: "invoicesItems");

            migrationBuilder.DropTable(
                name: "purchaseInvoice");

            migrationBuilder.DropTable(
                name: "ingredients");

            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "suppliers");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "invoicesStatus");

            migrationBuilder.DropTable(
                name: "paymentMethods");

            migrationBuilder.DropTable(
                name: "tables");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "restaurants");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "addresses");
        }
    }
}
