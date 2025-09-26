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
            modelBuilder.Entity<Invoices>()
                .HasOne(i => i.productReviews)
                .WithOne(pr => pr.invoices)
                .HasForeignKey<ProductReviews>(pr => pr.invoiceId);
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
                new Categorys { CategoryId = 1, CategoryName = "Món Xào" },
                new Categorys { CategoryId = 2, CategoryName = "Món Hấp" },
                new Categorys { CategoryId = 3, CategoryName = "Món Lẩu" },
                new Categorys { CategoryId = 4, CategoryName = "Món Nướng" },
                new Categorys { CategoryId = 5, CategoryName = "Món Bún/Phở" },
                new Categorys { CategoryId = 6, CategoryName = "Nước Uống" }
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
                    CustomerId = 2,
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
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId =2,
                    IngredientName = "Bánh Phở",
                    Quantity = 4,
                    MinQuantity = 1.0,
                    Price = 30000.0,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId = 3,
                    IngredientName = "Nước Phở",
                    Quantity = 10,
                    MinQuantity = 1.0,
                    Price = 10000,
                    Unit = "lít"
                },
                new Ingredient {
                    IngredientId = 4,
                    IngredientName = "Nước Bún Bò",
                    Quantity = 10,
                    MinQuantity = 1.0,
                    Price = 10000,
                    Unit = "lít"
                },
                new Ingredient {
                    IngredientId = 5,
                    IngredientName = "Giò Heo ",
                    Quantity = 3,
                    MinQuantity = 1.0,
                    Price = 120000,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId =6,
                    IngredientName = "Huyết Heo",
                    Quantity = 2,
                    MinQuantity = 1.0,
                    Price = 100000,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId = 7,
                    IngredientName = "Bún",
                    Quantity = 2,
                    MinQuantity = 1.0,
                    Price = 15000,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId = 8,
                    IngredientName = "Chả Lụa",
                    Quantity = 2,
                    MinQuantity = 1.0,
                    Price = 100000,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId = 9,
                    IngredientName = "Thịt Heo",
                    Quantity = 5,
                    MinQuantity = 1.0,
                    Price = 200000,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId = 10,
                    IngredientName = "Mọc",
                    Quantity = 2,
                    MinQuantity = 1.0,
                    Price = 150000,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId = 11,
                    IngredientName = "Mực",
                    Quantity = 2,
                    MinQuantity = 1.0,
                    Price = 250000,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId = 12,
                    IngredientName = "Tôm sú",
                    Quantity = 4,
                    MinQuantity = 1.0,
                    Price = 250000,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId = 13,
                    IngredientName = "Tôm Hùm",
                    Quantity = 3,
                    MinQuantity = 1.0,
                    Price = 450000,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId = 14,
                    IngredientName = "Cua",
                    Quantity = 3,
                    MinQuantity = 1.0,
                    Price = 350000,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId = 15,
                    IngredientName = "Ghẹ",
                    Quantity = 3,
                    MinQuantity = 1.0,
                    Price = 300000,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId = 16,
                    IngredientName = "Bơ",
                    Quantity = 3,
                    MinQuantity = 1.0,
                    Price = 100000,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId = 17,
                    IngredientName = "Phô mai",
                    Quantity = 3,
                    MinQuantity = 1.0,
                    Price = 100000,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId = 18,
                    IngredientName = "Cá Đuối",
                    Quantity = 3,
                    MinQuantity = 1.0,
                    Price = 100000,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId = 19,
                    IngredientName = "Măng Chua",
                    Quantity = 3,
                    MinQuantity = 1.0,
                    Price = 100000,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId = 20,
                    IngredientName = "Hàu",
                    Quantity = 20,
                    MinQuantity = 5,
                    Price = 800000,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId = 21,
                    IngredientName = "Óc móng tay",
                    Quantity = 20,
                    MinQuantity = 5,
                    Price = 100000,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId = 22,
                    IngredientName = "Miến",
                    Quantity = 20,
                    MinQuantity = 5,
                    Price = 50000,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId = 23,
                    IngredientName = "Trứng Muối",
                    Quantity = 20,
                    MinQuantity = 2,
                    Price = 100000,
                    Unit = "trứng"
                },
                new Ingredient {
                    IngredientId = 24,
                    IngredientName = "Ốc Hương",
                    Quantity = 20,
                    MinQuantity = 2,
                    Price = 200000,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId = 25,
                    IngredientName = "Gạo",
                    Quantity = 20,
                    MinQuantity = 2,
                    Price = 20000,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId = 26,
                    IngredientName = "Mì",
                    Quantity = 200,
                    MinQuantity = 20,
                    Price = 5000,
                    Unit = "gói"
                },
                new Ingredient {
                    IngredientId = 27,
                    IngredientName = "Sò Huyết",
                    Quantity = 20,
                    MinQuantity = 2,
                    Price = 200000,
                    Unit = "kg"
                },
                new Ingredient {
                    IngredientId = 28,
                    IngredientName = "Cá Mú",
                    Quantity = 20,
                    MinQuantity = 2,
                    Price = 250000,
                    Unit = "kg"
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
                        categoryId = 5
                    },
                    new Products {
                        ProductId =2,
                        ProductName = "Bún Bò",
                        Description = "",
                        Price = 55000.0,
                        PriceSale = 50000.0,
                        Quantity = 40,
                        SoldCount = 100,
                        categoryId = 5
                    },
                    new Products {
                        ProductId = 3,
                        ProductName = "Bún Mọc",
                        Description = "",
                        Price = 55000.0,
                        PriceSale = 50000.0,
                        Quantity = 30,
                        SoldCount = 100,
                        categoryId = 5
                    },
                    new Products {
                        ProductId = 4,
                        ProductName = "Bún Hải Sản",
                        Description = "",
                        Price = 80000.0,
                        PriceSale = 75000.0,
                        Quantity = 30,
                        SoldCount = 100,
                        categoryId = 5
                    },
                    new Products {
                        ProductId = 5,
                        ProductName = "Cua Sốt Bơ Tỏi",
                        Description = "",
                        Price = 250000.0,
                        PriceSale = 250000.0,
                        Quantity = 30,
                        SoldCount = 100,
                        categoryId = 1
                    },
                    new Products {
                        ProductId = 6,
                        ProductName = "Cua Sốt Phô Mai",
                        Description = "",
                        Price = 250000.0,
                        PriceSale = 250000.0,
                        Quantity = 30,
                        SoldCount = 100,
                        categoryId =1
                    },
                    new Products {
                        ProductId = 7,
                        ProductName = "Tôm Hùm Sốt Bơ Tỏi",
                        Description = "",
                        Price = 250000.0,
                        PriceSale = 250000.0,
                        Quantity = 30,
                        SoldCount = 100,
                        categoryId = 1
                    },
                    new Products {
                        ProductId = 8,
                        ProductName = "Tôm Hùm Sốt Phô Mai",
                        Description = "",
                        Price = 250000.0,
                        PriceSale = 250000.0,
                        Quantity = 30,
                        SoldCount = 100,
                        categoryId = 1
                    },
                    new Products {
                        ProductId = 9,
                        ProductName = "Lẩu Hải Sản",
                        Description = "",
                        Price = 300000.0,
                        PriceSale = 250000.0,
                        Quantity = 30,
                        SoldCount = 100,
                        categoryId = 3
                    },
                    new Products {
                        ProductId = 10,
                        ProductName = "Lẩu Cá Đuối",
                        Description = "",
                        Price = 200000.0,
                        PriceSale = 200000.0,
                        Quantity = 30,
                        SoldCount = 100,
                        categoryId = 3
                    },
                    new Products {
                        ProductId = 11,
                        ProductName = "Mực Hấp ",
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
                        categoryId = 4
                    },
                    new Products {
                        ProductId = 13,
                        ProductName = "Hàu Nướng Mỡ Hành",
                        Description = "",
                        Price = 80000.0,
                        PriceSale = 70000.0,
                        Quantity = 30,
                        SoldCount = 200,
                        categoryId = 4
                    },
                    new Products {
                        ProductId = 14,
                        ProductName = "Hàu Nướng Phô Mai",
                        Description = "",
                        Price = 80000.0,
                        PriceSale = 70000.0,
                        Quantity = 30,
                        SoldCount = 200,
                        categoryId = 4
                    },
                    new Products {
                        ProductId = 15,
                        ProductName = "Ốc Móng Tay Cháy Tỏi",
                        Description = "",
                        Price = 80000.0,
                        PriceSale = 70000.0,
                        Quantity = 30,
                        SoldCount = 200,
                        categoryId = 1
                    },
                    new Products {
                        ProductId = 16,
                        ProductName = "Miến Xào Thịt Cua",
                        Description = "",
                        Price = 80000.0,
                        PriceSale = 70000.0,
                        Quantity = 30,
                        SoldCount = 200,
                        categoryId = 1
                    },
                    new Products {
                        ProductId = 17,
                        ProductName = "Ốc Hương Sốt Trứng Muối",
                        Description = "",
                        Price = 150000.0,
                        PriceSale = 140000.0,
                        Quantity = 50,
                        SoldCount = 200,
                        categoryId = 1
                    },
                    new Products {
                        ProductId = 18,
                        ProductName = "Cơm Chiên Hải Sản",
                        Description = "",
                        Price = 150000.0,
                        PriceSale = 140000.0,
                        Quantity = 50,
                        SoldCount = 200,
                        categoryId = 1
                    },
                    new Products {
                        ProductId = 19,
                        ProductName = "Mì Xào Bò",
                        Description = "",
                        Price = 150000.0,
                        PriceSale = 140000.0,
                        Quantity = 50,
                        SoldCount = 200,
                        categoryId = 1
                    },
                    new Products {
                        ProductId = 20,
                        ProductName = "Sò Huyết Cháy Tỏi",
                        Description = "",
                        Price = 120000.0,
                        PriceSale = 100000.0,
                        Quantity = 50,
                        SoldCount = 200,
                        categoryId = 1
                    },
                    new Products {
                        ProductId = 21,
                        ProductName = "Sò Huyết Sốt Thái",
                        Description = "",
                        Price = 120000.0,
                        PriceSale = 100000.0,
                        Quantity = 50,
                        SoldCount = 200,
                        categoryId = 1
                    },
                    new Products {
                        ProductId = 22,
                        ProductName = "Mực Hấp Hành",
                        Description = "1 phần gồm 300g mực tươi hấp với hành và các gia vị.",
                        Price = 120000.0,
                        PriceSale = 100000.0,
                        Quantity = 50,
                        SoldCount = 200,
                        categoryId = 2
                    },
                    new Products {
                        ProductId = 23,
                        ProductName = "Cá Mú Hấp",
                        Description = "1 phần gồm 1 con cá mú hấp vớ  các gia vị.",
                        Price = 200000.0,
                        PriceSale = 100000.0,
                        Quantity = 50,
                        SoldCount = 200,
                        categoryId = 2
                    },
                    new Products {
                        ProductId = 24,
                        ProductName = "Nghêu Hấp",
                        Description = "1 phần gồm 500g Nghêu",
                        Price = 200000.0,
                        PriceSale = 100000.0,
                        Quantity = 50,
                        SoldCount = 200,
                        categoryId = 2
                    },
                    new Products {
                        ProductId = 25,
                        ProductName = "Coca Cola Lon",
                        Description = "",
                        Price = 20000.0,
                        PriceSale = 18000.0,
                        Quantity = 50,
                        SoldCount = 200,
                        categoryId = 5
                    },
                    new Products {
                        ProductId = 26,
                        ProductName = "Pepsi Lon",
                        Description = "",
                        Price = 20000.0,
                        PriceSale = 18000.0,
                        Quantity = 50,
                        SoldCount = 200,
                        categoryId = 5
                    },
                    new Products {
                        ProductId = 27,
                        ProductName = "Bia Tiger Lon",
                        Description = "",
                        Price = 25000.0,
                        PriceSale = 22000.0,
                        Quantity = 50,
                        SoldCount = 200,
                        categoryId = 5
                    },
                    new Products {
                        ProductId = 28,
                        ProductName = "Bia Heniken Lon",
                        Description = "",
                        Price = 30000.0,
                        PriceSale = 25000.0,
                        Quantity = 50,
                        SoldCount = 200,
                        categoryId = 5
                    }

                );
            modelBuilder.Entity<Images>().HasData(
                    new Images { ImagesId = 1, ImagesUrl = "/ImageProducts/product1.png", productId = 1 },
                    new Images { ImagesId = 2, ImagesUrl = "/ImageProducts/product2.png", productId = 2 },
                    new Images { ImagesId = 3, ImagesUrl = "/ImageProducts/product3.png", productId = 3 },
                    new Images { ImagesId = 4, ImagesUrl = "/ImageProducts/product4.png", productId = 4 },
                    new Images { ImagesId = 5, ImagesUrl = "/ImageProducts/product5.png", productId = 5 },
                    new Images { ImagesId = 6, ImagesUrl = "/ImageProducts/product6.png", productId = 6 },
                    new Images { ImagesId = 7, ImagesUrl = "/ImageProducts/product7.png", productId = 7 },
                    new Images { ImagesId = 8, ImagesUrl = "/ImageProducts/product8.png", productId = 8 },
                    new Images { ImagesId = 9, ImagesUrl = "/ImageProducts/product9.png", productId = 9 },
                    new Images { ImagesId = 10, ImagesUrl = "/ImageProducts/product10.png", productId = 10 },
                    new Images { ImagesId = 11, ImagesUrl = "/ImageProducts/product11.png", productId = 11 },
                    new Images { ImagesId = 12, ImagesUrl = "/ImageProducts/product12.png", productId = 12 },
                    new Images { ImagesId = 13, ImagesUrl = "/ImageProducts/product13.png", productId = 13 },
                    new Images { ImagesId = 14, ImagesUrl = "/ImageProducts/product14.png", productId = 14 },
                    new Images { ImagesId = 15, ImagesUrl = "/ImageProducts/product15.png", productId = 15 },
                    new Images { ImagesId = 16, ImagesUrl = "/ImageProducts/product16.png", productId = 16 },
                    new Images { ImagesId = 17, ImagesUrl = "/ImageProducts/product17.png", productId = 17 },
                    new Images { ImagesId = 18, ImagesUrl = "/ImageProducts/product18.png", productId = 18 },
                    new Images { ImagesId = 19, ImagesUrl = "/ImageProducts/product19.png", productId = 19 },
                    new Images { ImagesId = 20, ImagesUrl = "/ImageProducts/product20.png", productId = 20 },
                    new Images { ImagesId = 21, ImagesUrl = "/ImageProducts/product21.png", productId = 21 },
                    new Images { ImagesId = 22, ImagesUrl = "/ImageProducts/product22.png", productId = 22 },
                    new Images { ImagesId = 23, ImagesUrl = "/ImageProducts/product23.png", productId = 23 },
                    new Images { ImagesId = 24, ImagesUrl = "/ImageProducts/product24.png", productId = 24 },
                    new Images { ImagesId = 25, ImagesUrl = "/ImageProducts/product25.png", productId = 25 },
                    new Images { ImagesId = 26, ImagesUrl = "/ImageProducts/product26.png", productId = 26 },
                    new Images { ImagesId = 27, ImagesUrl = "/ImageProducts/product27.png", productId = 27 },
                    new Images { ImagesId = 28, ImagesUrl = "/ImageProducts/product28.png", productId = 28 }
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
                    new Recipes { RecipeId = 17, Quantity = 150, Unit = "g", ingredientId = 7, productId = 4 },
                    // cong thuc mon cua sot bo toi
                    new Recipes { RecipeId = 18, Quantity = 2, Unit = "con", ingredientId = 14, productId = 5 },
                    new Recipes { RecipeId = 19, Quantity = 100, Unit = "g", ingredientId = 16, productId = 5 },
                    // cong thuc mon cua sot pho mai
                    new Recipes { RecipeId = 20, Quantity = 2, Unit = "con", ingredientId = 14, productId = 6 },
                    new Recipes { RecipeId = 21, Quantity = 100, Unit = "g", ingredientId = 17, productId = 6 },
                    // cong thuc mon tom hum sot bo toi
                    new Recipes { RecipeId = 22, Quantity = 1, Unit = "con", ingredientId = 13, productId = 7 },
                    new Recipes { RecipeId = 23, Quantity = 100, Unit = "g", ingredientId = 16, productId = 7 },
                    // cong thuc mon tom hum sot pho mai
                    new Recipes { RecipeId = 24, Quantity = 1, Unit = "con", ingredientId = 13, productId = 8 },
                    new Recipes { RecipeId = 25, Quantity = 100, Unit = "g", ingredientId = 17, productId = 8 },
                    // cong thuc mon lau hai san
                    new Recipes { RecipeId = 26, Quantity = 200, Unit = "g", ingredientId = 11, productId = 9 },
                    new Recipes { RecipeId = 27, Quantity = 200, Unit = "g", ingredientId = 12, productId = 9 },
                    new Recipes { RecipeId = 28, Quantity = 200, Unit = "g", ingredientId = 14, productId = 9 },
                    new Recipes { RecipeId = 29, Quantity = 200, Unit = "g", ingredientId = 1, productId = 9 },
                    new Recipes { RecipeId = 30, Quantity = 200, Unit = "g", ingredientId = 7, productId = 9 },
                    // cong thuc mon lau ca doi
                    new Recipes { RecipeId = 31, Quantity = 500, Unit = "g", ingredientId = 18, productId = 10 },
                    new Recipes { RecipeId = 32, Quantity = 200, Unit = "g", ingredientId = 19, productId = 10 },
                    // cong thuc mon muc hap
                    new Recipes { RecipeId = 33, Quantity = 300, Unit = "g", ingredientId = 11, productId = 11 },
                    // cong thuc mon bo nuong ngoi
                    new Recipes { RecipeId = 34, Quantity = 200, Unit = "g", ingredientId = 1, productId = 12 }
                    // cong thuc mon hau nuong mo hanh  
                    , new Recipes { RecipeId = 35, Quantity = 1, Unit = "kg", ingredientId = 20, productId = 13 }
                    // cong thuc mon hau nuong pho mai
                    , new Recipes { RecipeId = 36, Quantity = 1, Unit = "kg", ingredientId = 20, productId = 14 }
                    // cong thuc mon oc mong tay chay toi
                    , new Recipes { RecipeId = 37, Quantity = 300, Unit = "g", ingredientId = 21, productId = 15 }
                    // cong thuc mon mien xao thit cua
                    , new Recipes { RecipeId = 38, Quantity = 200, Unit = "g", ingredientId = 22, productId = 16 }
                    , new Recipes { RecipeId = 39, Quantity = 200, Unit = "g", ingredientId = 14, productId = 16 }
                    // cong thuc mon oc huong sot trung muoi
                    , new Recipes { RecipeId = 40, Quantity = 300, Unit = "g", ingredientId = 24, productId = 17 }
                    , new Recipes { RecipeId = 41, Quantity = 100, Unit = "g", ingredientId = 23, productId = 17 }
                    // cong thuc mon com chien hai san
                    , new Recipes { RecipeId = 42, Quantity = 200, Unit = "g", ingredientId = 12, productId = 18 }
                    , new Recipes { RecipeId = 43, Quantity = 200, Unit = "g", ingredientId = 11, productId = 18 }
                    , new Recipes { RecipeId = 44, Quantity = 200, Unit = "g", ingredientId = 25, productId = 18 }
                    // cong thuc mon mi xao bo
                    , new Recipes { RecipeId = 45, Quantity = 300, Unit = "g", ingredientId = 26, productId = 19 }
                    , new Recipes { RecipeId = 46, Quantity = 200, Unit = "g", ingredientId = 1, productId = 19 }
                    // cong thuc mon so huyet chay toi
                    , new Recipes { RecipeId = 47, Quantity = 300, Unit = "g", ingredientId = 27, productId = 20 }
                    // cong thuc mon so huyet sot thai
                    , new Recipes { RecipeId = 48, Quantity = 300, Unit = "g", ingredientId = 27, productId = 21 }
                    // cong thuc mon muc hap hanh
                    , new Recipes { RecipeId = 49, Quantity = 300, Unit = "g", ingredientId = 11, productId = 22 }
                    // cong thuc mon ca mu hap
                    , new Recipes { RecipeId = 50, Quantity = 500, Unit = "g", ingredientId = 28, productId = 23 }
                );
            modelBuilder.Entity<InvoiceStatus>().HasData(
                new InvoiceStatus { InvoiceStatusId = 1,InvoiceStatusName = "Pending", Description = "Chờ Xác Nhận" },
                new InvoiceStatus { InvoiceStatusId = 2, InvoiceStatusName = "Confirmed", Description = "Đã Xác Nhận" },
                new InvoiceStatus { InvoiceStatusId = 3, InvoiceStatusName = "Shipping", Description = "Đang Giao Hàng" },
                new InvoiceStatus { InvoiceStatusId = 4, InvoiceStatusName = "Delivered", Description = "Đã Giao" },
                new InvoiceStatus { InvoiceStatusId = 5, InvoiceStatusName = "Cancelled", Description = "Đã Hủy" },
                new InvoiceStatus { InvoiceStatusId = 6, InvoiceStatusName = "Returned", Description = "Trả hàng" }
            );
            modelBuilder.Entity<Invoices>().HasData(
                new Invoices {
                    InvoiceId = 1,
                    TotalQuantity = 3,
                    TotalAmount = 400000.0,
                    Create_At = DateTime.UtcNow,
                    IsPayment = true,
                    InvoiceType = false,
                    customerId = 1,
                    invoiceStatusId = 4,
                    paymentMethodId = 1,
                    addressId = 1
                },
                new Invoices {
                    InvoiceId = 2,
                    TotalQuantity = 2,
                    TotalAmount = 270000.0,
                    Create_At = DateTime.UtcNow,
                    IsPayment = false,
                    InvoiceType = false,
                    customerId = 1,
                    invoiceStatusId = 4,
                    paymentMethodId = 3,
                    addressId = 1
                }
            );
            modelBuilder.Entity<InvoiceItems>().HasData(
                new InvoiceItems { InvoiceItemId = 1, Quantity = 2, Price = 75000.0, productId = 4, invoiceId = 1 },
                new InvoiceItems { InvoiceItemId = 2, Quantity = 1, Price = 250000.0, productId = 8, invoiceId = 1 },
                new InvoiceItems { InvoiceItemId = 3, Quantity = 1, Price = 120000.0, productId = 22, invoiceId = 2 },
                new InvoiceItems { InvoiceItemId = 4, Quantity = 1, Price = 150000.0, productId = 19, invoiceId = 2 }
            );
        }
    }
}
