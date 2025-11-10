using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Definition;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using UngDungQuanLiNhaHang.Helpers;
using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.Repository;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;

namespace UngDungQuanLiNhaHang.Services.Implementations {
    public class ProductServices(
        ProductRepo productRepo,
        TransactionRepo transactionRepo,
        IngredientRepo ingredientRepo,
        HandlerFiles handlerFiles,
        Logger<ProductServices> logger
        ) : IProductService {
        public async Task<ApiResponse<int>> AddProduct(ProductDTO productDTO) {
            if ( productDTO == null ) {
                return ApiResponse<int>.FailResponse("Product data is null");
            }

            var isExists = await productRepo.IsProductExistsByName(productDTO.productName);
            if ( isExists ) {
                return ApiResponse<int>.FailResponse("Product already exists");
            }

            if ( productDTO.productOptionsDTO != null ) {
                foreach ( var ingredient in productDTO.productOptionsDTO ) {
                    var ingredientExists = await ingredientRepo.GetIngredientById(ingredient.ingredientId);
                    if ( ingredientExists == null ) {
                        return ApiResponse<int>.FailResponse($"Ingredient {ingredient.optionName} does not exist");
                    }
                }
            }
            if ( productDTO.recipeDTO != null ) {
                foreach ( var ingredient in productDTO.recipeDTO ) {
                    var ingredientExists = await ingredientRepo.GetIngredientById(ingredient.ingredientId);
                    if ( ingredientExists == null ) {
                        return ApiResponse<int>.FailResponse($"Ingredient {ingredient.ingredientId} does not exist");
                    }
                }
            }

            Products products = new() {
                ProductName = productDTO.productName,
                Description = productDTO.description,
                Price = productDTO.price,
                PriceSale = productDTO.priceSale,
                Quantity = productDTO.quantity,
                SoldCount = 0,
                IsActive = true,
                Create_At = DateTime.UtcNow,
                Update_At = DateTime.UtcNow,
                AverageRating = 0,
                TotalReviews = 0,
                CategoryId = productDTO.categoryId,
                images = [],
                productOptions = [],
                recipes = []
            };


            try {
                await transactionRepo.BeginTransactionAsync();
                await productRepo.AddProduct(products);
                if ( productDTO.productOptionsDTO != null ) {
                    logger.LogInformation("ProductOptionsDTO: {Data}",
                         JsonSerializer.Serialize(productDTO.productOptionsDTO, new JsonSerializerOptions {
                             WriteIndented = true
                         }));
                    foreach ( var ingredient in productDTO.productOptionsDTO ) {
                        var ingredientExists = await ingredientRepo.GetIngredientById(ingredient.ingredientId);
                        if ( ingredientExists == null ) {
                            return ApiResponse<int>.FailResponse($"Ingredient {ingredient.optionName} does not exist");
                        }
                        ProductOptions productOptions = new ProductOptions() {
                            OptionName = ingredient.optionName,
                            Ingredient = ingredientExists,
                            OptionValue = ingredient.quantity,
                            Unit = ingredient.unit,
                            Price = ingredient.price,
                            ProductId = products.ProductId
                        };
                        await productRepo.ProductAddOption(productOptions);
                    }
                }


                if ( productDTO.recipeDTO != null ) {
                    foreach ( var ingredient in productDTO.recipeDTO ) {
                        var ingredientExists = await ingredientRepo.GetIngredientById(ingredient.ingredientId);
                        if ( ingredientExists == null ) {
                            return ApiResponse<int>.FailResponse($"Ingredient {ingredient.ingredientId} does not exist");
                        }
                        Recipes recipes = new Recipes() {
                            Ingredient = ingredientExists,
                            Quantity = ingredient.quantity,
                            Unit = ingredient.unit,
                            ProductId = products.ProductId
                        };
                        await productRepo.ProductAddRecipe(recipes);
                    }
                }

                

                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<int>.SuccessResponse(products.ProductId, "Product added successfully");


            }
            catch ( Exception ex ) {

                await transactionRepo.RollbackAsync();

                return ApiResponse<int>.FailResponse($"Error adding product: {ex.Message}");

            }
        }

        public async Task<ApiResponse<bool>> ActiveProduct(int productId) {
            var product = await productRepo.GetProductById(productId);
            if ( product == null ) {
                return ApiResponse<bool>.FailResponse("Product does not exist");
            }
            try {
                await transactionRepo.BeginTransactionAsync();
                product.IsActive = !product.IsActive;
                product.Update_At = DateTime.UtcNow;
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Product status updated successfully");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse($"Error updating product status: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PageResponse<ProductResponse>>> GetAllProducts(ProductPageDTO productPageDTO) {
            int pageSize = 12;
            var products = await productRepo.GetAllProducts();
            var totalItems = products.Count;
            var totalPages = ( int )Math.Ceiling(totalItems / ( double )pageSize);

            if ( productPageDTO.page < 1 ) productPageDTO.page = 1;
            if ( productPageDTO.categoryId > 0 ) {
                products = products.Where(p => p.CategoryId == productPageDTO.categoryId.Value).ToList();
            }
            if ( !string.IsNullOrEmpty(productPageDTO.name) ) {
                products = products.Where(p => p.ProductName.Contains(productPageDTO.name, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            var pagedProducts = products

                .Skip(( productPageDTO.page - 1 ) * pageSize)
                .Take(pageSize)
                .ToList();
            if ( productPageDTO.orderBy == 1 ) {
                // Sắp xếp Tăng dần và GÁN KẾT QUẢ ĐÃ SẮP XẾP trở lại
                pagedProducts = pagedProducts.OrderBy(item => item.Price).ToList();
            }
            if ( productPageDTO.orderBy == 2 ) {
                // Sắp xếp Giảm dần và GÁN KẾT QUẢ ĐÃ SẮP XẾP trở lại
                pagedProducts = pagedProducts.OrderByDescending(item => item.Price).ToList();
            }
            var productResponses = pagedProducts.Select(p => new ProductResponse {
                productId = p.ProductId,
                productName = p.ProductName,
                price = p.Price,
                priceSale = p.PriceSale,
                quantity = p.Quantity,
                sold = p.SoldCount,
                averageRating = p.AverageRating,
                image = p.images?.FirstOrDefault()?.ImagesUrl?.ToString() ?? "/no-image.png"
            }).ToList();
            var pageResponse = new PageResponse<ProductResponse> {
                page = productPageDTO.page,
                pageSize = pageSize,
                totalItems = totalItems,
                totalPages = totalPages,
                list = productResponses
            };
            return ApiResponse<PageResponse<ProductResponse>>.SuccessResponse(pageResponse, "Products retrieved successfully");
        }


        public async Task<ApiResponse<ProductDetailResponse>> GetProductById(int id) {
            var product = await productRepo.GetProductById2(id);
            if ( product == null ) {
                return ApiResponse<ProductDetailResponse>.FailResponse("Product does not exist");
            }
            ProductDetailResponse productResponse = new ProductDetailResponse() {
                productId = product.ProductId,
                productName = product.ProductName,
                description = product.Description,
                price = product.Price,
                priceSale = product.PriceSale,
                quantity = product.Quantity,
                sold = product.SoldCount,
                averageRating = product.AverageRating,
                TotalReviews = product.TotalReviews,

                images = product.images.Select(i => i.ImagesUrl).ToList(),
                recipes = product.recipes != null ? string.Join(", ", product.recipes.Select(r => $" {r.Quantity}{r.Unit} - {r.Ingredient?.IngredientName}")) : null,
                productOptions = new List<ProductOptionResponse>(),
                productReviews = new List<ProductReviewResponse>(),
                products = new List<ProductResponse>()
            };
            foreach ( var item in product.productOptions ) {
                if ( item != null ) {
                    productResponse.productOptions.Add(new ProductOptionResponse {
                        productOptionId = item.ProductOptionId,
                        optionName = item.OptionName,
                        price = item.Price
                    });
                }
            }
            foreach ( var item2 in product.productReviews ) {
                if ( item2 != null ) {
                    productResponse.productReviews.Add(new ProductReviewResponse {
                        productReviewId = item2.ProductReviewId,
                        userName = item2.Customers?.FullName ?? "Unknown",
                        rating = item2.Rating,
                        comment = item2.Comment,
                        create_At = item2.Create_At
                    });
                }

            }
            // goi y san pham cung loai
            var productByCategoryId = await productRepo.GetProductByCategoryIdAndProductId(product.CategoryId,product.ProductId);
            if (productByCategoryId.Count > 0) {
                productResponse.products = productByCategoryId.Select(p => new ProductResponse {
                    productId = p.ProductId,
                    productName = p.ProductName,
                    price = p.Price,
                    priceSale = p.PriceSale,
                    sold = p.SoldCount,
                    averageRating = p.AverageRating,
                    image = p.images.FirstOrDefault()?.ImagesUrl ?? "/no-image.png"
                }).ToList();
            }
            return ApiResponse<ProductDetailResponse>.SuccessResponse(productResponse, "Product retrieved successfully");
        }

        public async Task<ApiResponse<int>> UpdateProduct(UpdateProductDTO productDTO) {
            // kiem tra productDTO
            var isExists = await productRepo.IsProductExists(productDTO.productId);
            if ( !isExists ) {
                return ApiResponse<int>.FailResponse("Product does not exist");
            }
            var isExists2 = await productRepo.IsProductExistsByNameAndId(productDTO.productName, productDTO.productId);
            if ( isExists2 != null ) {
                return ApiResponse<int>.FailResponse("Product name already exists");
            }
            var product = await productRepo.GetProductById2(productDTO.productId);
            if ( product == null ) {
                return ApiResponse<int>.FailResponse("Product does not exist");
            }
            product.ProductName = productDTO.productName;
            product.Description = productDTO.description;
            product.Price = productDTO.price;
            product.PriceSale = productDTO.priceSale;
            product.Quantity = productDTO.quantity;
            product.Update_At = DateTime.UtcNow;

            try {
                await transactionRepo.BeginTransactionAsync();
                logger.LogInformation("ProductOptionsDTO: {Data}",
                         JsonSerializer.Serialize(productDTO, new JsonSerializerOptions {
                             WriteIndented = true
                         }));
                if ( productDTO.productOptionsDTO != null && productDTO.productOptionsDTO.Count > 0 ) {
                    // delete soft nhung option khong co trong DTO
                    var existingOptions = product.productOptions.ToList();
                    foreach ( var existing in existingOptions ) {
                        var updatedOption = productDTO.productOptionsDTO.FirstOrDefault(o => o.id == existing.ProductOptionId);
                        if ( updatedOption != null ) {
                            // ✅ Cập nhật lại option có sẵn
                            existing.OptionName = updatedOption.optionName;
                            existing.OptionValue = updatedOption.quantity;
                            existing.isDelete = false;
                            existing.Price = updatedOption.price;
                            existing.Unit = updatedOption.unit;
                        }
                        else {
                            // ⚠️ Soft delete option không còn trong danh sách FE
                            existing.isDelete = true;
                        }

                    }
                    foreach ( var item in productDTO.productOptionsDTO ) {
                        // them option moi
                       if (item.id == 0) {
                            var ingredientExists = await ingredientRepo.GetIngredientById(item.ingredientId);
                            if ( ingredientExists == null ) {
                                return ApiResponse<int>.FailResponse($"Ingredient {item.optionName} does not exist");
                            }
                            ProductOptions productOptions = new ProductOptions() {
                                OptionName = item.optionName,
                                IngredientId = item.ingredientId,
                                OptionValue = item.quantity,
                                Unit = item.unit,
                                Price = item.price,
                                ProductId = product.ProductId
                            };
                            product.productOptions.Add(productOptions);
                        }
                    }
                }
                
                if ( productDTO.recipeDTO != null && productDTO.recipeDTO.Count > 0 ) {
                    var existingRecipes = product.recipes.ToList();
                    foreach ( var existing in existingRecipes ) {
                        var updatedRecipe = productDTO.recipeDTO.FirstOrDefault(o => o.recipeId == existing.RecipeId);
                        if ( updatedRecipe != null ) {
                            // ✅ Cập nhật lại recipe có sẵn
                            existing.Quantity = updatedRecipe.quantity;
                            existing.isDelete = false;
                            existing.Unit = updatedRecipe.unit;
                        }
                        else {
                            // ⚠️ Soft delete recipe không còn trong danh sách FE
                            existing.isDelete = true;
                        }

                    }
                    foreach ( var ingredient in productDTO.recipeDTO ) {
                        // them recipe moi
                        if ( ingredient.recipeId == 0 ) {
                            var ingredientExists = await ingredientRepo.GetIngredientById(ingredient.ingredientId);
                            if ( ingredientExists == null ) {
                                return ApiResponse<int>.FailResponse($"Ingredient {ingredient.ingredientId} does not exist");
                            }
                            Recipes recipes = new Recipes() {
                                IngredientId = ingredient.ingredientId,
                                Quantity = ingredient.quantity,
                                Unit = ingredient.unit,
                                ProductId = product.ProductId
                            };
                            product.recipes.Add(recipes);
                        }
                    }
                }
                productRepo.UpdateProduct(product);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<int>.SuccessResponse(product.ProductId, "Product updated successfully");
            }
            catch ( Exception ex ) {

                await transactionRepo.RollbackAsync();
               
                return ApiResponse<int>.FailResponse($"Error updating product: {ex.Message}");
            }
        }



        public async Task<ApiResponse<bool>> AddImgProduct(int productid,IFormFile file) {
            if ( file == null  ) {
                return ApiResponse<bool>.FailResponse("Thêm sản phẩm thành công nhưng chưa có hình ảnh.");
            }
            var product = await productRepo.GetProductById(productid);
            if ( product == null ) {
                return ApiResponse<bool>.FailResponse("Product does not exist");
            }
            var savedFiles = new List<string>();
            try {
                await transactionRepo.BeginTransactionAsync();
               
                    if ( file != null && file.Length > 0 ) {
                        string imageURL = await handlerFiles.SaveFile(file, "products");
                        Images image = new Images() {
                            ImagesUrl = imageURL,
                            
                        };
                        savedFiles.Add(imageURL);
                        product.images.Add(image);
                    }
                
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Thêm sản phẩm và hình ảnh thành công.");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                try {
                    foreach ( var filePath in savedFiles ) {
                        handlerFiles.DeleteFile(filePath);
                    }
                }
                catch ( Exception fileEx ) {
                    // Log the file deletion error
                    Console.WriteLine($"Error deleting files: {fileEx.Message}");
                }
                return ApiResponse<bool>.FailResponse($"Thêm sản phẩm thành công nhưng lỗi khi thêm hình ảnh: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> UpdateImgProduct(int productId, IFormFile file) {
            var savedFiles = new List<string>();
            List<Images> imagesToRemove = new List<Images>();
            logger.LogInformation("ProductOptionsDTOssss: {Data}",
                         JsonSerializer.Serialize(productId, new JsonSerializerOptions {
                             WriteIndented = true
                         }));
            var product = await productRepo.GetProductById(productId);
            if ( product == null ) {
                return ApiResponse<bool>.FailResponse("Product not Found");
            }
            try {
                //if ( productDTO != null && productDTO.Count > 0 ) {
                //    // xoa nhung img khong co trong nhung img moi
                //    var imagesToRemove2 = product.images
                //    .Where(img => !productDTO.Any(f => f.imgId != 0 && f.imgId == img.ImagesId))
                //    .ToList();

                //    foreach ( var img in imagesToRemove2 ) {
                //        imagesToRemove.Add(img);
                //        product.images.Remove(img);
                //    }
                //    // them nhung img moi
                //    foreach ( var file in productDTO ) {
                //        if ( file.imgId == 0 && file != null && file.file != null && file.file.Length > 0 ) {
                //            string imageURL = await handlerFiles.SaveFile(file.file, "products");
                //            Images image = new Images() {
                //                ImagesUrl = imageURL,
                //                ProductId = product.ProductId
                //            };
                //            savedFiles.Add(imageURL);
                //            product.images.Add(image);
                //        }
                //    }

                //}
               
                product.images.Clear();
                
                if ( file != null && file.Length > 0 ) {
                    string imageURL = await handlerFiles.SaveFile(file, "products");
                   
                    savedFiles.Add(imageURL);
                    product.images.Add(new Images() {
                        ImagesUrl = imageURL,

                    });
                }


                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                logger.LogInformation("ProductOptionsDTO: {Data}",
                         JsonSerializer.Serialize(product, new JsonSerializerOptions {
                             WriteIndented = true
                         }));
                // xoa file img khoi server 
                foreach ( var img in imagesToRemove ) {
                    try {
                        foreach ( var item in product.images ) {
                            if ( item != null ) {
                                handlerFiles.DeleteFile(item.ImagesUrl);
                            }
                        }
                    }
                    catch ( Exception ex ) {
                        logger.LogWarning($"Error deleting image: {img.ImagesUrl}, error: {ex.Message}");
                    }
                }
                return ApiResponse<bool>.SuccessResponse(true, "Cập nhật sản phẩm thành công.");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                try {
                    foreach ( var filePath in savedFiles ) {
                        handlerFiles.DeleteFile(filePath);
                    }
                }
                catch ( Exception fileEx ) {
                    logger.LogError(fileEx, "Error updating product images");
                    // Log the file deletion error
                    Console.WriteLine($"Error deleting files: {fileEx.Message}");
                }
                Console.WriteLine("=== ERROR DETAIL ===");
                Console.WriteLine(ex.ToString());
                Console.WriteLine("====================");
                logger.LogError(ex, "Error updating product images");
                return ApiResponse<bool>.FailResponse($"Sản phẩm đã cập nhật nhưng lỗi khi cập nhật ảnh.: {ex.Message}");
            }
        }

        public async Task<ApiResponse<List<ProductResponse>>> GetListProductTopSelling() {
            var products = await productRepo.GetListProductTopSelling();
            if (products.Count == 0) {
                return ApiResponse<List<ProductResponse>>.FailResponse("Không có dữ liệu ");
            }
            List<ProductResponse> productResponses = products.Select(p => new ProductResponse {
                productId = p.ProductId,
                productName = p.ProductName,
                price = p.Price,
                priceSale = p.PriceSale,
                sold = p.SoldCount,
                averageRating = p.AverageRating,
                image = p.images.FirstOrDefault()?.ImagesUrl ?? "/no-image.png"
            }).ToList();
            return ApiResponse<List<ProductResponse>>.SuccessResponse(productResponses, "Lấy thông tin thành công.");
        }

        public async  Task<ApiResponse<List<ProductResponse>>> GetListProductNews() {
            var products = await productRepo.GetListProductNews();
            if (products.Count == 0) {
                return ApiResponse<List<ProductResponse>>.FailResponse("Không có dữ liệu ");
            }
            List<ProductResponse> productResponses = products.Select(p => new ProductResponse {
                productId = p.ProductId,
                productName = p.ProductName,
                price = p.Price,
                priceSale = p.PriceSale,
                sold = p.SoldCount,
                averageRating = p.AverageRating,
                image = p.images.FirstOrDefault()?.ImagesUrl ?? "/no-image.png"
            }).ToList();
            return ApiResponse<List<ProductResponse>>.SuccessResponse(productResponses, "Lấy thông tin thành công.");
        }

        public async Task<ApiResponse<List<ProductResponse>>> GetProductByCategoryid(int categoryId) {
            var products = await productRepo.GetProductByCategoryId(categoryId);
            if ( products.Count == 0 ) {
                return ApiResponse<List<ProductResponse>>.FailResponse("Không có dữ liệu ");
            }
            List<ProductResponse> productResponses = products.Select(p => new ProductResponse {
                productId = p.ProductId,
                productName = p.ProductName,
                price = p.Price,
                priceSale = p.PriceSale,
                sold = p.SoldCount,
                averageRating = p.AverageRating,
                image = p.images.FirstOrDefault()?.ImagesUrl ?? "/no-image.png"
            }).ToList();
            return ApiResponse<List<ProductResponse>>.SuccessResponse(productResponses, "Lấy thông tin thành công.");
        }

        public async Task<ApiResponse<PutProductResponse>> GetProductId(int productId) {
            var product = await productRepo.GetProductById2(productId);
            if ( product == null ) {
                return ApiResponse<PutProductResponse>.FailResponse("Not found");
            }
            var res = new PutProductResponse() {
                productId = productId,
                productName = product.ProductName,
                description = product.Description,
                price = product.Price,
                priceSale = product.PriceSale,
                quantity = product.Quantity,
                categoryId = product.CategoryId,
                image = product.images.First()?.ImagesUrl ?? "",
                productOptionsDTO = product.productOptions.Where(i => i.isDelete == false).Select(item => new ProductOptionsDTO() {
                    id = item.ProductOptionId,
                    ingredientId = item.IngredientId,
                    optionName = item.OptionName,
                    quantity = item.OptionValue,
                    price = item.Price,
                    unit = item.Unit,
                }).ToList(),
                recipeDTO = product.recipes.Where(i => i.isDelete == false).Select(item => new RecipeDTO() {
                    recipeId = item.RecipeId,
                    ingredientId = item.IngredientId,
                    unit = item.Unit,
                    quantity = item.Quantity,
                }).ToList()

            };
            return ApiResponse<PutProductResponse>.SuccessResponse(res);
        }

        public async Task<ApiResponse<PageResponse<ProductDetailResponse>>> GetPageProducts(ProductPageDTO productPageDTO) {

            int pageSize = 12;
            var products = await productRepo.GetAllProducts();
           

            if ( productPageDTO.page < 1 ) productPageDTO.page = 1;
            if ( productPageDTO.categoryId > 0 ) {
                products = products.Where(p => p.CategoryId == productPageDTO.categoryId.Value).ToList();
            }
            if ( !string.IsNullOrEmpty(productPageDTO.name) ) {
                products = products.Where(p => p.ProductName.Contains(productPageDTO.name, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            var pagedProducts = products
                .Skip(( productPageDTO.page - 1 ) * pageSize)
                .Take(pageSize)
                .ToList();

            var productResponses = pagedProducts.Select(product => new ProductDetailResponse() {
                productId = product.ProductId,
                productName = product.ProductName,
                description = product.Description,
                price = product.Price,
                priceSale = product.PriceSale,
                quantity = product.Quantity,
                sold = product.SoldCount,
                averageRating = product.AverageRating,
                TotalReviews = product.TotalReviews,
                images = product.images.Select(i => i.ImagesUrl).ToList(),
                productOptions = product.productOptions?.Select(item => new ProductOptionResponse {
                    productOptionId = item.ProductOptionId,
                    optionName = item.OptionName,
                    price = item.Price
                }).ToList() ?? [],
            }).ToList();
            var totalItems = products.Count;
            var totalPages = ( int )Math.Ceiling(totalItems / ( double )pageSize);
            var pageResponse = new PageResponse<ProductDetailResponse> {
                page = productPageDTO.page,
                pageSize = pageSize,
                totalItems = totalItems,
                totalPages = totalPages,
                list = productResponses
            };

            return ApiResponse<PageResponse<ProductDetailResponse>>.SuccessResponse(pageResponse, "Products retrieved successfully");

        }
    }
}
