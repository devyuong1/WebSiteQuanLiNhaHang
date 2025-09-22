using Microsoft.EntityFrameworkCore;
using UngDungQuanLiNhaHang.Models;

namespace UngDungQuanLiNhaHang.Data {
    public class DataDbConText : DbContext {

        public DataDbConText(DbContextOptions<DataDbConText> options) :base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.EnableSensitiveDataLogging(); // Bật chi tiết lỗi
        }

        public DbSet<Address> addresses { get; set; }
        public DbSet<Restaurants> restaurants { get; set; }
        public DbSet<Roles> roles { get; set; }
        public DbSet<Customers> customers { get; set; }
        public DbSet<Employees> employees { get; set; }
        public DbSet<Suppliers> suppliers { get; set; }
        public DbSet<Categorys> categories { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Carts> carts { get; set; }
        public DbSet<CartItems> cartItems { get; set; }
        public DbSet<Invoices> invoices { get; set; }
        public DbSet<InvoiceStatus> invoicesStatus { get; set; }
        public DbSet<PaymentMethod> paymentMethods { get; set; }
        public DbSet<InvoiceItems> invoicesItems { get; set; }
        public DbSet<Images> images { get; set; }
        public DbSet<Ingredient> ingredients { get; set; }

        public DbSet<PurchaseInvoice> purchaseInvoice { get; set; }
        public DbSet<PurchaseInvoiceItem> purchaseInvoiceItem { get; set; }
        public DbSet<ProductReviews> productReviews { get; set; }
        public DbSet<Recipes> recipes { get; set; }

        public DbSet<RefreshTokens> refreshTokens { get; set; }
        public DbSet<Tables> tables { get; set; }
        public DbSet<BookTable> bookTables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Roles>().HasData(
                   new Roles { RoleId = 1, RoleName = "Admin", Description = "Chủ nhà hàng" },
                   new Roles { RoleId = 2, RoleName = "Manager", Description = "Quản lí" },
                   new Roles { RoleId = 3, RoleName = "Employee", Description = "Nhân viên" },
                   new Roles { RoleId = 4, RoleName = "Customer", Description = "Khách Hàng" }

               );

            modelBuilder.Entity<Address>().HasData(
                new Address {
                    AddressId = 1,
                    Province = "Cần Thơ",
                    District = "Phường Ninh Kiều",
                    Hamlet = " Khu vực 7",
                    Street = "Đường 3/2",
                    HouseNumber = "123"
                },
                new Address {
                    AddressId = 2,
                    Province = "Cần Thơ",
                    District = "Phường Ninh Kiều",
                    Hamlet = " Khu vực 7",
                    Street = "Đường Nguyễn Văn Cừ",
                    HouseNumber = "124"
                },
                new Address {
                    AddressId = 3,
                    Province = "Cần Thơ",
                    District = "Phường Ninh Kiều",
                    Hamlet = " Khu vực 7",
                    Street = "Đường 30/4",
                    HouseNumber = "125"
                },
                new Address {
                    AddressId = 4,
                    Province = "Cần Thơ",
                    District = "Phường Ninh Kiều",
                    Hamlet = " Khu vực 7",
                    Street = "Đường 19/8",
                    HouseNumber = "32"
                },
                 new Address {
                     AddressId = 5,
                     Province = "Cần Thơ",
                     District = "Phường Cái Răng",
                     Hamlet = " Khu vực 6",
                     Street = "Đường 19/8",
                     HouseNumber = "54"
                 },
                  new Address {
                      AddressId = 6,
                      Province = "Cần Thơ",
                      District = "Phường Ninh Kiều",
                      Hamlet = " Khu vực 7",
                      Street = "Đường 19/8",
                      HouseNumber = "23"
                  },
                  new Address {
                      AddressId = 7,
                      Province = "Cần Thơ",
                      District = "Phường Cái Răng",
                      Hamlet = " Khu vực 7",
                      Street = "Đường Lê Bình",
                      HouseNumber = "45"
                  },
                   new Address {
                       AddressId = 8,
                       Province = "Cần Thơ",
                       District = "Phường Thốt Nốt",
                       Hamlet = " Khu vực 7",
                       Street = "Đường Lê Bình",
                       HouseNumber = "45"
                   }
            );
            modelBuilder.Entity<Restaurants>().HasData(
                new Restaurants {
                    RestaurantId = 1,
                    RestaurantName = "Nhà Hàng Thanh Thiên",
                    Email = "ThanhThien@gmail.com",
                    Phone = "0989000030",
                    addressId = 1,
                    CloseTime = new TimeSpan(23, 30, 0),
                    OpenTime = new TimeSpan(10, 0, 0)
                }
                );
            modelBuilder.Entity<Employees>().HasData(
                new Employees {
                    EmployeeId = 1,
                    Fullname = "Nguyễn Thanh Tâm",
                    Email = "tam@gmail.com",
                    UserName = "tam@gmail.com",
                    Password = "thanhtam1",
                    Phone = "0909092324",
                    restaurantId = 1,
                    roleId = 1,
                    addressId = 2
                },
                new Employees {
                    EmployeeId = 2,
                    Fullname = "Nguyễn Thanh Thiên",
                    Email = "thien@gmail.com",
                    UserName = "thien@gmail.com",
                    Password = "thanhtam1",
                    Phone = "0909092325",
                    restaurantId = 1,
                    roleId = 2,
                    addressId = 3
                },
                new Employees {
                    EmployeeId = 3,
                    Fullname = "Nguyễn Hoàng Quí",
                    Email = "qui@gmail.com",
                    UserName = "qui@gmail.com",
                    Password = "thanhtam1",
                    Phone = "0909092326",
                    restaurantId = 1,
                    roleId = 3,
                    addressId = 4
                },
                new Employees {
                    EmployeeId = 4,
                    Fullname = "Nguyễn Hoàng Phúc",
                    Email = "phuc@gmail.com",
                    UserName = "phuc@gmail.com",
                    Password = "thanhtam1",
                    Phone = "0909092327",
                    restaurantId = 1,
                    roleId = 3,
                    addressId = 5
                }
                );

            modelBuilder.Entity<Categorys>().HasData(
                new Categorys { CategoryId = 1, CategoryName = "Món Khai Vị" },
                new Categorys { CategoryId = 2, CategoryName = "Món Chính" },
                new Categorys { CategoryId = 3, CategoryName = "Món Lẩu" },
                new Categorys { CategoryId = 4, CategoryName = "Món Nướng" },
                new Categorys { CategoryId = 5, CategoryName = "Món Tráng Miệng" },
                new Categorys { CategoryId = 5, CategoryName = "Nước Uống" }
                );
            modelBuilder.Entity<PaymentMethod>().HasData(
                    new PaymentMethod { PaymentMethodId = 1, PaymentMethodName = "VNPay" },
                    new PaymentMethod { PaymentMethodId = 2, PaymentMethodName = "MoMo" },
                    new PaymentMethod { PaymentMethodId = 3, PaymentMethodName = "Thahh Toán Khi Nhận Hàng" }
                );

            modelBuilder.Entity<Customers>().HasData(
                new Customers {
                    CustomerId = 1,
                    FullName = "Nguyễn Văn A",
                    Email = "a@gmail.com",
                    Phone = "0909092321",
                    Password = "thanhtam1",
                    roleId = 4,
                    
                },
                new Customers {
                    CustomerId = 1,
                    FullName = "Nguyễn Văn B",
                    Email = "b@gmail.com",
                    Phone = "0909092389",
                    Password = "thanhtam1",
                    roleId = 4
                }
            );

            modelBuilder.Entity<Suppliers>().HasData(
                new Suppliers {
                    SupplierID = 1,
                    SupplierName = "Công Ty Thực Phẩm Sạch ABC",
                    Email = "ctyabc@gmail.com",
                    Phone = "0239092399",
                    addressID = 7
                },
                new Suppliers {
                    SupplierID = 2,
                    SupplierName = "Công Ty Hải Sản Cà Mau",
                    Email = "haisan23@gmail.com",
                    Phone = "0239092459",
                    addressID = 8
                }
            );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient {
                    IngredientId = 1,
                    IngredientName = "Thịt Bò",
                    Quantity = 10.0,
                    MinQuantity = 1.0,
                    Price = 200000.0,
                },
                new Ingredient {
                    IngredientId =2,
                    IngredientName = "Bánh Phở",
                    Quantity = 4,
                    MinQuantity = 1.0,
                    Price = 30000.0,
                },
                new Ingredient {
                    IngredientId = 3,
                    IngredientName = "Nước Phở",
                    Quantity = 10,
                    MinQuantity = 1.0,
                    Price = 10000,
                },
                new Ingredient {
                    IngredientId = 4,
                    IngredientName = "Nước Bún Bò",
                    Quantity = 10,
                    MinQuantity = 1.0,
                    Price = 10000,
                },
                new Ingredient {
                    IngredientId = 5,
                    IngredientName = "Giò Heo ",
                    Quantity = 3,
                    MinQuantity = 1.0,
                    Price = 120000,
                },
                new Ingredient {
                    IngredientId =6,
                    IngredientName = "Huyết Heo",
                    Quantity = 2,
                    MinQuantity = 1.0,
                    Price = 100000,
                },
                new Ingredient {
                    IngredientId = 7,
                    IngredientName = "Bún",
                    Quantity = 2,
                    MinQuantity = 1.0,
                    Price = 15000,
                },
                new Ingredient {
                    IngredientId = 8,
                    IngredientName = "Chả Lụa",
                    Quantity = 2,
                    MinQuantity = 1.0,
                    Price = 100000,
                },
                new Ingredient {
                    IngredientId = 9,
                    IngredientName = "Thịt Heo",
                    Quantity = 5,
                    MinQuantity = 1.0,
                    Price = 200000,
                },
                new Ingredient {
                    IngredientId = 10,
                    IngredientName = "Mọc",
                    Quantity = 2,
                    MinQuantity = 1.0,
                    Price = 150000,
                },
                new Ingredient {
                    IngredientId = 11,
                    IngredientName = "Mực",
                    Quantity = 2,
                    MinQuantity = 1.0,
                    Price = 250000,
                },
                new Ingredient {
                    IngredientId = 12,
                    IngredientName = "Tôm sú",
                    Quantity = 4,
                    MinQuantity = 1.0,
                    Price = 250000,
                },
                new Ingredient {
                    IngredientId = 13,
                    IngredientName = "Tôm Hùm",
                    Quantity = 3,
                    MinQuantity = 1.0,
                    Price = 450000,
                },
                new Ingredient {
                    IngredientId = 14,
                    IngredientName = "Cua",
                    Quantity = 3,
                    MinQuantity = 1.0,
                    Price = 350000,
                },
                new Ingredient {
                    IngredientId = 15,
                    IngredientName = "Ghẹ",
                    Quantity = 3,
                    MinQuantity = 1.0,
                    Price = 300000,
                },
                new Ingredient {
                    IngredientId = 16,
                    IngredientName = "Bơ",
                    Quantity = 3,
                    MinQuantity = 1.0,
                    Price = 100000,
                },
                new Ingredient {
                    IngredientId = 17,
                    IngredientName = "Phô mai",
                    Quantity = 3,
                    MinQuantity = 1.0,
                    Price = 100000,
                },
                new Ingredient {
                    IngredientId = 18,
                    IngredientName = "Cá Đối",
                    Quantity = 3,
                    MinQuantity = 1.0,
                    Price = 100000,
                },
                new Ingredient {
                    IngredientId = 19,
                    IngredientName = "Mang Chua",
                    Quantity = 3,
                    MinQuantity = 1.0,
                    Price = 100000,
                }
            );
            modelBuilder.Entity<Products>().HasData(
                    new Products {
                        ProductId = 1,
                        ProductName = "Phở Bò",
                        Description = "",
                        Price = 50000.0,
                        PriceSale = 45000.0,
                        Quantity = 40,
                        SoldCount = 2000,
                        categoryId = 2
                    },
                    new Products {
                        ProductId =2,
                        ProductName = "Bún Bò",
                        Description = "",
                        Price = 55000.0,
                        PriceSale = 50000.0,
                        Quantity = 40,
                        SoldCount = 100,
                        categoryId = 2
                    },
                    new Products {
                        ProductId = 3,
                        ProductName = "Bún Mọc",
                        Description = "",
                        Price = 55000.0,
                        PriceSale = 50000.0,
                        Quantity = 30,
                        SoldCount = 100,
                        categoryId = 2
                    },
                    new Products {
                        ProductId = 4,
                        ProductName = "Bún Hải Sản",
                        Description = "",
                        Price = 80000.0,
                        PriceSale = 75000.0,
                        Quantity = 30,
                        SoldCount = 100,
                        categoryId = 2
                    },
                    new Products {
                        ProductId = 5,
                        ProductName = "Cua Sốt Bơ Tỏi",
                        Description = "",
                        Price = 250000.0,
                        PriceSale = 250000.0,
                        Quantity = 30,
                        SoldCount = 100,
                        categoryId = 2
                    },
                    new Products {
                        ProductId = 6,
                        ProductName = "Cua Sốt Phô Mai",
                        Description = "",
                        Price = 250000.0,
                        PriceSale = 250000.0,
                        Quantity = 30,
                        SoldCount = 100,
                        categoryId = 2
                    },
                    new Products {
                        ProductId = 7,
                        ProductName = "Tôm Hùm Sốt Bơ Tỏi",
                        Description = "",
                        Price = 250000.0,
                        PriceSale = 250000.0,
                        Quantity = 30,
                        SoldCount = 100,
                        categoryId = 2
                    },
                    new Products {
                        ProductId = 8,
                        ProductName = "Tôm Hùm Sốt Phô Mai",
                        Description = "",
                        Price = 250000.0,
                        PriceSale = 250000.0,
                        Quantity = 30,
                        SoldCount = 100,
                        categoryId = 2
                    },
                    new Products {
                        ProductId = 9,
                        ProductName = "Lẩu Hải Sản",
                        Description = "",
                        Price = 300000.0,
                        PriceSale = 250000.0,
                        Quantity = 30,
                        SoldCount = 100,
                        categoryId = 2
                    },
                    new Products {
                        ProductId = 10,
                        ProductName = "Lẩu Cá Đối",
                        Description = "",
                        Price = 200000.0,
                        PriceSale = 200000.0,
                        Quantity = 30,
                        SoldCount = 100,
                        categoryId = 2
                    },
                    new Products {
                        ProductId = 11,
                        ProductName = "Mực Hấp",
                        Description = "",
                        Price = 200000.0,
                        PriceSale = 200000.0,
                        Quantity = 30,
                        SoldCount = 100,
                        categoryId = 2
                    },
                    new Products {
                        ProductId = 12,
                        ProductName = "Bò Nướng Ngói",
                        Description = "",
                        Price = 100000.0,
                        PriceSale = 90000.0,
                        Quantity = 30,
                        SoldCount = 100,
                        categoryId = 2
                    }
                );

            modelBuilder.Entity<Recipes>().HasData(
                // cong thuc mon pho 
                    new Recipes { RecipeId = 1, Quantity = 100, Unit = "g", ingredientId = 1, productId = 1},
                    new Recipes { RecipeId = 2, Quantity = 200, Unit = "g", ingredientId = 2, productId = 1},
                    new Recipes { RecipeId = 3, Quantity = 300, Unit = "ml", ingredientId = 3, productId = 1},
                    // cong thuc mon bun bo
                    new Recipes { RecipeId = 4, Quantity = 100, Unit = "g", ingredientId = 1, productId = 2 },
                    new Recipes { RecipeId = 5, Quantity = 300, Unit = "ml", ingredientId = 4, productId = 2 },
                    new Recipes { RecipeId = 6, Quantity = 50, Unit = "g", ingredientId = 5, productId = 2 },
                    new Recipes { RecipeId = 7, Quantity = 50, Unit = "g", ingredientId = 6, productId = 2 },
                    new Recipes { RecipeId = 8, Quantity = 200, Unit = "g", ingredientId =7, productId = 2 },
                    // cong thuc mon bun moc
                    new Recipes { RecipeId = 9, Quantity = 100, Unit = "g", ingredientId = 9, productId = 3 },
                    new Recipes { RecipeId = 10, Quantity = 50, Unit = "g", ingredientId = 8, productId = 3 },
                    new Recipes { RecipeId = 11, Quantity = 100, Unit = "g", ingredientId = 7, productId = 3 },
                    new Recipes { RecipeId = 12, Quantity = 50, Unit = "g", ingredientId = 10, productId = 3 },
                    // cong thuc mon bun hai san
                    new Recipes { RecipeId = 13, Quantity = 50, Unit = "g", ingredientId = 11, productId = 4 },
                    new Recipes { RecipeId = 14, Quantity = 50, Unit = "g", ingredientId = 12, productId = 4 },
                    new Recipes { RecipeId = 15, Quantity = 50, Unit = "g", ingredientId = 14, productId = 4 },
                    new Recipes { RecipeId = 16, Quantity = 50, Unit = "g", ingredientId = 15, productId = 4 },
                    new Recipes { RecipeId = 16, Quantity = 150, Unit = "g", ingredientId = 7, productId = 4 },
                    // cong thuc mon cua sot bo toi
                    new Recipes { RecipeId = 17, Quantity = 2, Unit = "con", ingredientId = 14, productId = 5 },
                    new Recipes { RecipeId = 17, Quantity = 100, Unit = "g", ingredientId = 16, productId = 5 },
                    // cong thuc mon cua sot pho mai
                    new Recipes { RecipeId = 18, Quantity = 2, Unit = "con", ingredientId = 14, productId = 6 },
                    new Recipes { RecipeId = 19, Quantity = 100, Unit = "g", ingredientId = 17, productId = 6 },
                    // cong thuc mon tom hum sot bo toi
                    new Recipes { RecipeId = 20, Quantity = 1, Unit = "con", ingredientId = 13, productId = 7 },
                    new Recipes { RecipeId = 21, Quantity = 100, Unit = "g", ingredientId = 16, productId = 7 },
                    // cong thuc mon tom hum sot pho mai
                    new Recipes { RecipeId = 22, Quantity = 1, Unit = "con", ingredientId = 13, productId = 8 },
                    new Recipes { RecipeId = 23, Quantity = 100, Unit = "g", ingredientId = 17, productId = 8 },
                    // cong thuc mon lau hai san
                    new Recipes { RecipeId = 24, Quantity = 200, Unit = "g", ingredientId = 11, productId = 9 },
                    new Recipes { RecipeId = 25, Quantity = 200, Unit = "g", ingredientId = 12, productId = 9 },
                    new Recipes { RecipeId = 26, Quantity = 200, Unit = "g", ingredientId = 14, productId = 9 },
                    new Recipes { RecipeId = 27, Quantity = 200, Unit = "g", ingredientId = 1, productId = 9 },
                    new Recipes { RecipeId = 28, Quantity = 200, Unit = "g", ingredientId = 7, productId = 9 },
                    // cong thuc mon lau ca doi
                    new Recipes { RecipeId = 29, Quantity = 500, Unit = "g", ingredientId = 18, productId = 10 },
                    new Recipes { RecipeId = 30, Quantity = 200, Unit = "g", ingredientId = 19, productId = 10 },
                    // cong thuc mon muc hap
                    new Recipes { RecipeId = 31, Quantity = 300, Unit = "g", ingredientId = 11, productId = 11 },
                    // cong thuc mon bo nuong ngoi
                    new Recipes { RecipeId = 32, Quantity = 200, Unit = "g", ingredientId = 1, productId = 12 }

                );
        }
    }
}
