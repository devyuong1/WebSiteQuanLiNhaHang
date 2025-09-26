using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UngDungQuanLiNhaHang.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.CartId);
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
                    categoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_products_categories_categoryId",
                        column: x => x.categoryId,
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
                    roleId = table.Column<int>(type: "int", nullable: false),
                    cartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_customers_carts_cartId",
                        column: x => x.cartId,
                        principalTable: "carts",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK_customers_roles_roleId",
                        column: x => x.roleId,
                        principalTable: "roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    cartId = table.Column<int>(type: "int", nullable: false),
                    CartsCartId = table.Column<int>(type: "int", nullable: true),
                    productId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_cartItems_carts_CartsCartId",
                        column: x => x.CartsCartId,
                        principalTable: "carts",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK_cartItems_products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    ImagesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagesUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    productsProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.ImagesId);
                    table.ForeignKey(
                        name: "FK_images_products_productsProductId",
                        column: x => x.productsProductId,
                        principalTable: "products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ingredientId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    productsProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipes", x => x.RecipeId);
                    table.ForeignKey(
                        name: "FK_recipes_ingredients_ingredientId",
                        column: x => x.ingredientId,
                        principalTable: "ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_recipes_products_productsProductId",
                        column: x => x.productsProductId,
                        principalTable: "products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hamlet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    restaurantId = table.Column<int>(type: "int", nullable: true),
                    employeeId = table.Column<int>(type: "int", nullable: true),
                    customerId = table.Column<int>(type: "int", nullable: true),
                    customersCustomerId = table.Column<int>(type: "int", nullable: true),
                    supplierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_addresses_customers_customersCustomerId",
                        column: x => x.customersCustomerId,
                        principalTable: "customers",
                        principalColumn: "CustomerId");
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
                    paymentMethodId = table.Column<int>(type: "int", nullable: false),
                    invoiceStatusId = table.Column<int>(type: "int", nullable: false),
                    addressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_invoices_addresses_addressId",
                        column: x => x.addressId,
                        principalTable: "addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_invoices_customers_customersCustomerId",
                        column: x => x.customersCustomerId,
                        principalTable: "customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_invoices_invoicesStatus_invoiceStatusId",
                        column: x => x.invoiceStatusId,
                        principalTable: "invoicesStatus",
                        principalColumn: "InvoiceStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_invoices_paymentMethods_paymentMethodId",
                        column: x => x.paymentMethodId,
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
                    addressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurants", x => x.RestaurantId);
                    table.ForeignKey(
                        name: "FK_restaurants_addresses_addressId",
                        column: x => x.addressId,
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
                    addressID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.SupplierID);
                    table.ForeignKey(
                        name: "FK_suppliers_addresses_addressID",
                        column: x => x.addressID,
                        principalTable: "addresses",
                        principalColumn: "AddressId",
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
                    productId = table.Column<int>(type: "int", nullable: false),
                    productsProductId = table.Column<int>(type: "int", nullable: true),
                    invoiceId = table.Column<int>(type: "int", nullable: false),
                    invoicesInvoiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoicesItems", x => x.InvoiceItemId);
                    table.ForeignKey(
                        name: "FK_invoicesItems_invoices_invoicesInvoiceId",
                        column: x => x.invoicesInvoiceId,
                        principalTable: "invoices",
                        principalColumn: "InvoiceId");
                    table.ForeignKey(
                        name: "FK_invoicesItems_products_productsProductId",
                        column: x => x.productsProductId,
                        principalTable: "products",
                        principalColumn: "ProductId");
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
                    customerId = table.Column<int>(type: "int", nullable: false),
                    customersCustomerId = table.Column<int>(type: "int", nullable: true),
                    invoiceId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    productsProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productReviews", x => x.ProductReviewId);
                    table.ForeignKey(
                        name: "FK_productReviews_customers_customersCustomerId",
                        column: x => x.customersCustomerId,
                        principalTable: "customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_productReviews_invoices_invoiceId",
                        column: x => x.invoiceId,
                        principalTable: "invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productReviews_products_productsProductId",
                        column: x => x.productsProductId,
                        principalTable: "products",
                        principalColumn: "ProductId");
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
                    addressId = table.Column<int>(type: "int", nullable: false),
                    restaurantId = table.Column<int>(type: "int", nullable: false),
                    restaurantsRestaurantId = table.Column<int>(type: "int", nullable: true),
                    roleId = table.Column<int>(type: "int", nullable: false),
                    rolesRoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_employees_addresses_addressId",
                        column: x => x.addressId,
                        principalTable: "addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employees_restaurants_restaurantsRestaurantId",
                        column: x => x.restaurantsRestaurantId,
                        principalTable: "restaurants",
                        principalColumn: "RestaurantId");
                    table.ForeignKey(
                        name: "FK_employees_roles_rolesRoleId",
                        column: x => x.rolesRoleId,
                        principalTable: "roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "purchaseInvoice",
                columns: table => new
                {
                    PurchaseInvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Totalamount = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPayment = table.Column<bool>(type: "bit", nullable: false),
                    supplierId = table.Column<int>(type: "int", nullable: false),
                    suppliersSupplierID = table.Column<int>(type: "int", nullable: true),
                    employeeId = table.Column<int>(type: "int", nullable: false),
                    employeesEmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseInvoice", x => x.PurchaseInvoiceId);
                    table.ForeignKey(
                        name: "FK_purchaseInvoice_employees_employeesEmployeeId",
                        column: x => x.employeesEmployeeId,
                        principalTable: "employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_purchaseInvoice_suppliers_suppliersSupplierID",
                        column: x => x.suppliersSupplierID,
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
                name: "purchaseInvoiceItem",
                columns: table => new
                {
                    PurchaseInvoiceItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    purchaseInvoiceId = table.Column<int>(type: "int", nullable: false),
                    ingredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseInvoiceItem", x => x.PurchaseInvoiceItemID);
                    table.ForeignKey(
                        name: "FK_purchaseInvoiceItem_ingredients_ingredientId",
                        column: x => x.ingredientId,
                        principalTable: "ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchaseInvoiceItem_purchaseInvoice_purchaseInvoiceId",
                        column: x => x.purchaseInvoiceId,
                        principalTable: "purchaseInvoice",
                        principalColumn: "PurchaseInvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "addresses",
                columns: new[] { "AddressId", "District", "Hamlet", "HouseNumber", "IsDefault", "Province", "Street", "customerId", "customersCustomerId", "employeeId", "restaurantId", "supplierId" },
                values: new object[,]
                {
                    { 1, "Phường Ninh Kiều", " Khu vực 7", "123", true, "Cần Thơ", "Đường 3/2", null, null, null, null, null },
                    { 2, "Phường Ninh Kiều", " Khu vực 7", "124", true, "Cần Thơ", "Đường Nguyễn Văn Cừ", null, null, null, null, null },
                    { 3, "Phường Ninh Kiều", " Khu vực 7", "125", true, "Cần Thơ", "Đường 30/4", null, null, null, null, null },
                    { 4, "Phường Ninh Kiều", " Khu vực 7", "32", true, "Cần Thơ", "Đường 19/8", null, null, null, null, null },
                    { 5, "Phường Cái Răng", " Khu vực 6", "54", true, "Cần Thơ", "Đường 19/8", null, null, null, null, null },
                    { 6, "Phường Ninh Kiều", " Khu vực 7", "23", true, "Cần Thơ", "Đường 19/8", null, null, null, null, null },
                    { 7, "Phường Cái Răng", " Khu vực 7", "45", true, "Cần Thơ", "Đường Lê Bình", null, null, null, null, null },
                    { 8, "Phường Thốt Nốt", " Khu vực 7", "45", true, "Cần Thơ", "Đường Lê Bình", null, null, null, null, null }
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
                table: "images",
                columns: new[] { "ImagesId", "ImagesUrl", "productId", "productsProductId" },
                values: new object[,]
                {
                    { 1, "/ImageProducts/product1.png", 1, null },
                    { 2, "/ImageProducts/product2.png", 2, null },
                    { 3, "/ImageProducts/product3.png", 3, null },
                    { 4, "/ImageProducts/product4.png", 4, null },
                    { 5, "/ImageProducts/product5.png", 5, null },
                    { 6, "/ImageProducts/product6.png", 6, null },
                    { 7, "/ImageProducts/product7.png", 7, null },
                    { 8, "/ImageProducts/product8.png", 8, null },
                    { 9, "/ImageProducts/product9.png", 9, null },
                    { 10, "/ImageProducts/product10.png", 10, null },
                    { 11, "/ImageProducts/product11.png", 11, null },
                    { 12, "/ImageProducts/product12.png", 12, null },
                    { 13, "/ImageProducts/product13.png", 13, null },
                    { 14, "/ImageProducts/product14.png", 14, null },
                    { 15, "/ImageProducts/product15.png", 15, null },
                    { 16, "/ImageProducts/product16.png", 16, null },
                    { 17, "/ImageProducts/product17.png", 17, null },
                    { 18, "/ImageProducts/product18.png", 18, null },
                    { 19, "/ImageProducts/product19.png", 19, null },
                    { 20, "/ImageProducts/product20.png", 20, null },
                    { 21, "/ImageProducts/product21.png", 21, null },
                    { 22, "/ImageProducts/product22.png", 22, null },
                    { 23, "/ImageProducts/product23.png", 23, null },
                    { 24, "/ImageProducts/product24.png", 24, null },
                    { 25, "/ImageProducts/product25.png", 25, null },
                    { 26, "/ImageProducts/product26.png", 26, null },
                    { 27, "/ImageProducts/product27.png", 27, null },
                    { 28, "/ImageProducts/product28.png", 28, null }
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
                table: "invoicesItems",
                columns: new[] { "InvoiceItemId", "Price", "Quantity", "invoiceId", "invoicesInvoiceId", "productId", "productsProductId" },
                values: new object[,]
                {
                    { 1, 75000.0, 2, 1, null, 4, null },
                    { 2, 250000.0, 1, 1, null, 8, null },
                    { 3, 120000.0, 1, 2, null, 22, null },
                    { 4, 150000.0, 1, 2, null, 19, null }
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
                columns: new[] { "CustomerId", "Email", "FullName", "IsActive", "Password", "Phone", "cartId", "roleId" },
                values: new object[,]
                {
                    { 1, "a@gmail.com", "Nguyễn Văn A", true, "thanhtam1", "0909092321", null, 4 },
                    { 2, "b@gmail.com", "Nguyễn Văn B", true, "thanhtam1", "0909092389", null, 4 }
                });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "EmployeeId", "Email", "Fullname", "IsActive", "Password", "Phone", "UserName", "addressId", "restaurantId", "restaurantsRestaurantId", "roleId", "rolesRoleId" },
                values: new object[,]
                {
                    { 1, "tam@gmail.com", "Nguyễn Thanh Tâm", true, "thanhtam1", "0909092324", "tam@gmail.com", 2, 1, null, 1, null },
                    { 2, "thien@gmail.com", "Nguyễn Thanh Thiên", true, "thanhtam1", "0909092325", "thien@gmail.com", 3, 1, null, 2, null },
                    { 3, "qui@gmail.com", "Nguyễn Hoàng Quí", true, "thanhtam1", "0909092326", "qui@gmail.com", 4, 1, null, 3, null },
                    { 4, "phuc@gmail.com", "Nguyễn Hoàng Phúc", true, "thanhtam1", "0909092327", "phuc@gmail.com", 5, 1, null, 3, null }
                });

            migrationBuilder.InsertData(
                table: "invoices",
                columns: new[] { "InvoiceId", "Create_At", "InvoiceType", "IsPayment", "TotalAmount", "TotalQuantity", "addressId", "customerId", "customersCustomerId", "invoiceStatusId", "paymentMethodId", "tableId", "tablesTableId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(6033), false, true, 400000.0, 3, 1, 1, null, 4, 1, null, null },
                    { 2, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(6036), false, false, 270000.0, 2, 1, 1, null, 4, 3, null, null }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "AverageRating", "Create_At", "Description", "IsActive", "Price", "PriceSale", "ProductName", "Quantity", "SoldCount", "TotalReviews", "Update_At", "categoryId" },
                values: new object[,]
                {
                    { 1, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5730), "", true, 50000.0, 45000.0, "Phở Bò", 40, 2000, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5732), 5 },
                    { 2, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5740), "", true, 55000.0, 50000.0, "Bún Bò", 40, 100, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5740), 5 },
                    { 3, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5742), "", true, 55000.0, 50000.0, "Bún Mọc", 30, 100, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5743), 5 },
                    { 4, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5744), "", true, 80000.0, 75000.0, "Bún Hải Sản", 30, 100, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5744), 5 },
                    { 5, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5746), "", true, 250000.0, 250000.0, "Cua Sốt Bơ Tỏi", 30, 100, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5746), 1 },
                    { 6, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5748), "", true, 250000.0, 250000.0, "Cua Sốt Phô Mai", 30, 100, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5748), 1 },
                    { 7, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5750), "", true, 250000.0, 250000.0, "Tôm Hùm Sốt Bơ Tỏi", 30, 100, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5751), 1 },
                    { 8, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5752), "", true, 250000.0, 250000.0, "Tôm Hùm Sốt Phô Mai", 30, 100, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5752), 1 },
                    { 9, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5754), "", true, 300000.0, 250000.0, "Lẩu Hải Sản", 30, 100, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5754), 3 },
                    { 10, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5755), "", true, 200000.0, 200000.0, "Lẩu Cá Đuối", 30, 100, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5756), 3 },
                    { 11, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5814), "", true, 200000.0, 200000.0, "Mực Hấp ", 30, 100, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5814), 2 },
                    { 12, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5816), "", true, 100000.0, 90000.0, "Bò Nướng Ngói", 30, 100, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5816), 4 },
                    { 13, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5818), "", true, 80000.0, 70000.0, "Hàu Nướng Mỡ Hành", 30, 200, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5818), 4 },
                    { 14, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5819), "", true, 80000.0, 70000.0, "Hàu Nướng Phô Mai", 30, 200, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5819), 4 },
                    { 15, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5821), "", true, 80000.0, 70000.0, "Ốc Móng Tay Cháy Tỏi", 30, 200, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5821), 1 },
                    { 16, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5822), "", true, 80000.0, 70000.0, "Miến Xào Thịt Cua", 30, 200, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5823), 1 },
                    { 17, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5824), "", true, 150000.0, 140000.0, "Ốc Hương Sốt Trứng Muối", 50, 200, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5824), 1 },
                    { 18, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5826), "", true, 150000.0, 140000.0, "Cơm Chiên Hải Sản", 50, 200, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5826), 1 },
                    { 19, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5828), "", true, 150000.0, 140000.0, "Mì Xào Bò", 50, 200, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5828), 1 },
                    { 20, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5829), "", true, 120000.0, 100000.0, "Sò Huyết Cháy Tỏi", 50, 200, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5829), 1 },
                    { 21, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5831), "", true, 120000.0, 100000.0, "Sò Huyết Sốt Thái", 50, 200, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5831), 1 },
                    { 22, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5832), "1 phần gồm 300g mực tươi hấp với hành và các gia vị.", true, 120000.0, 100000.0, "Mực Hấp Hành", 50, 200, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5833), 2 },
                    { 23, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5835), "1 phần gồm 1 con cá mú hấp vớ  các gia vị.", true, 200000.0, 100000.0, "Cá Mú Hấp", 50, 200, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5835), 2 },
                    { 24, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5837), "1 phần gồm 500g Nghêu", true, 200000.0, 100000.0, "Nghêu Hấp", 50, 200, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5837), 2 },
                    { 25, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5838), "", true, 20000.0, 18000.0, "Coca Cola Lon", 50, 200, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5839), 5 },
                    { 26, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5840), "", true, 20000.0, 18000.0, "Pepsi Lon", 50, 200, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5840), 5 },
                    { 27, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5842), "", true, 25000.0, 22000.0, "Bia Tiger Lon", 50, 200, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5842), 5 },
                    { 28, 5.0, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5843), "", true, 30000.0, 25000.0, "Bia Heniken Lon", 50, 200, 1, new DateTime(2025, 9, 26, 14, 52, 22, 235, DateTimeKind.Utc).AddTicks(5844), 5 }
                });

            migrationBuilder.InsertData(
                table: "recipes",
                columns: new[] { "RecipeId", "Quantity", "Unit", "ingredientId", "productId", "productsProductId" },
                values: new object[,]
                {
                    { 1, 100.0, "g", 1, 1, null },
                    { 2, 200.0, "g", 2, 1, null },
                    { 3, 300.0, "ml", 3, 1, null },
                    { 4, 100.0, "g", 1, 2, null },
                    { 5, 300.0, "ml", 4, 2, null },
                    { 6, 50.0, "g", 5, 2, null },
                    { 7, 50.0, "g", 6, 2, null },
                    { 8, 200.0, "g", 7, 2, null },
                    { 9, 100.0, "g", 9, 3, null },
                    { 10, 50.0, "g", 8, 3, null },
                    { 11, 100.0, "g", 7, 3, null },
                    { 12, 50.0, "g", 10, 3, null },
                    { 13, 50.0, "g", 11, 4, null },
                    { 14, 50.0, "g", 12, 4, null },
                    { 15, 50.0, "g", 14, 4, null },
                    { 16, 50.0, "g", 15, 4, null },
                    { 17, 150.0, "g", 7, 4, null },
                    { 18, 2.0, "con", 14, 5, null },
                    { 19, 100.0, "g", 16, 5, null },
                    { 20, 2.0, "con", 14, 6, null },
                    { 21, 100.0, "g", 17, 6, null },
                    { 22, 1.0, "con", 13, 7, null },
                    { 23, 100.0, "g", 16, 7, null },
                    { 24, 1.0, "con", 13, 8, null },
                    { 25, 100.0, "g", 17, 8, null },
                    { 26, 200.0, "g", 11, 9, null },
                    { 27, 200.0, "g", 12, 9, null },
                    { 28, 200.0, "g", 14, 9, null },
                    { 29, 200.0, "g", 1, 9, null },
                    { 30, 200.0, "g", 7, 9, null },
                    { 31, 500.0, "g", 18, 10, null },
                    { 32, 200.0, "g", 19, 10, null },
                    { 33, 300.0, "g", 11, 11, null },
                    { 34, 200.0, "g", 1, 12, null },
                    { 35, 1.0, "kg", 20, 13, null },
                    { 36, 1.0, "kg", 20, 14, null },
                    { 37, 300.0, "g", 21, 15, null },
                    { 38, 200.0, "g", 22, 16, null },
                    { 39, 200.0, "g", 14, 16, null },
                    { 40, 300.0, "g", 24, 17, null },
                    { 41, 100.0, "g", 23, 17, null },
                    { 42, 200.0, "g", 12, 18, null },
                    { 43, 200.0, "g", 11, 18, null },
                    { 44, 200.0, "g", 25, 18, null },
                    { 45, 300.0, "g", 26, 19, null },
                    { 46, 200.0, "g", 1, 19, null },
                    { 47, 300.0, "g", 27, 20, null },
                    { 48, 300.0, "g", 27, 21, null },
                    { 49, 300.0, "g", 11, 22, null },
                    { 50, 500.0, "g", 28, 23, null }
                });

            migrationBuilder.InsertData(
                table: "restaurants",
                columns: new[] { "RestaurantId", "CloseTime", "Email", "OpenTime", "Phone", "RestaurantName", "addressId" },
                values: new object[] { 1, new TimeSpan(0, 23, 30, 0, 0), "ThanhThien@gmail.com", new TimeSpan(0, 10, 0, 0, 0), "0989000030", "Nhà Hàng Thanh Thiên", 1 });

            migrationBuilder.InsertData(
                table: "suppliers",
                columns: new[] { "SupplierID", "Email", "Phone", "SupplierName", "addressID" },
                values: new object[,]
                {
                    { 1, "ctyabc@gmail.com", "0239092399", "Công Ty Thực Phẩm Sạch ABC", 7 },
                    { 2, "haisan23@gmail.com", "0239092459", "Công Ty Hải Sản Cà Mau", 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_customersCustomerId",
                table: "addresses",
                column: "customersCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_bookTables_CustomersCustomerId",
                table: "bookTables",
                column: "CustomersCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_bookTables_TablesTableId",
                table: "bookTables",
                column: "TablesTableId");

            migrationBuilder.CreateIndex(
                name: "IX_cartItems_CartsCartId",
                table: "cartItems",
                column: "CartsCartId");

            migrationBuilder.CreateIndex(
                name: "IX_cartItems_ProductsProductId",
                table: "cartItems",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_customers_cartId",
                table: "customers",
                column: "cartId",
                unique: true,
                filter: "[cartId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_customers_roleId",
                table: "customers",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_addressId",
                table: "employees",
                column: "addressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees_restaurantsRestaurantId",
                table: "employees",
                column: "restaurantsRestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_rolesRoleId",
                table: "employees",
                column: "rolesRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_images_productsProductId",
                table: "images",
                column: "productsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_addressId",
                table: "invoices",
                column: "addressId");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_customersCustomerId",
                table: "invoices",
                column: "customersCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_invoiceStatusId",
                table: "invoices",
                column: "invoiceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_paymentMethodId",
                table: "invoices",
                column: "paymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_tablesTableId",
                table: "invoices",
                column: "tablesTableId");

            migrationBuilder.CreateIndex(
                name: "IX_invoicesItems_invoicesInvoiceId",
                table: "invoicesItems",
                column: "invoicesInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_invoicesItems_productsProductId",
                table: "invoicesItems",
                column: "productsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_productReviews_customersCustomerId",
                table: "productReviews",
                column: "customersCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_productReviews_invoiceId",
                table: "productReviews",
                column: "invoiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_productReviews_productsProductId",
                table: "productReviews",
                column: "productsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_products_categoryId",
                table: "products",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseInvoice_employeesEmployeeId",
                table: "purchaseInvoice",
                column: "employeesEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseInvoice_suppliersSupplierID",
                table: "purchaseInvoice",
                column: "suppliersSupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseInvoiceItem_ingredientId",
                table: "purchaseInvoiceItem",
                column: "ingredientId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseInvoiceItem_purchaseInvoiceId",
                table: "purchaseInvoiceItem",
                column: "purchaseInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_recipes_ingredientId",
                table: "recipes",
                column: "ingredientId");

            migrationBuilder.CreateIndex(
                name: "IX_recipes_productsProductId",
                table: "recipes",
                column: "productsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_refreshTokens_CustomersCustomerId",
                table: "refreshTokens",
                column: "CustomersCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_refreshTokens_EmployeesEmployeeId",
                table: "refreshTokens",
                column: "EmployeesEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_restaurants_addressId",
                table: "restaurants",
                column: "addressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_addressID",
                table: "suppliers",
                column: "addressID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookTables");

            migrationBuilder.DropTable(
                name: "cartItems");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "invoicesItems");

            migrationBuilder.DropTable(
                name: "productReviews");

            migrationBuilder.DropTable(
                name: "purchaseInvoiceItem");

            migrationBuilder.DropTable(
                name: "recipes");

            migrationBuilder.DropTable(
                name: "refreshTokens");

            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropTable(
                name: "purchaseInvoice");

            migrationBuilder.DropTable(
                name: "ingredients");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "invoicesStatus");

            migrationBuilder.DropTable(
                name: "paymentMethods");

            migrationBuilder.DropTable(
                name: "tables");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "suppliers");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "restaurants");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
