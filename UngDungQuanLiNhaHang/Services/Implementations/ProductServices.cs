using UngDungQuanLiNhaHang.Repository;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;
using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.Helpers;
using Microsoft.AspNetCore.Mvc;

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
                    var ingredientExists = await ingredientRepo.GetIngredientById(ingredient.IngredientId);
                    if ( ingredientExists == null ) {
                        return ApiResponse<int>.FailResponse($"Ingredient {ingredient.optionName} does not exist");
                    }
                }
            }
            if ( productDTO.recipeDTO != null ) {
                foreach ( var ingredient in productDTO.recipeDTO ) {
                    var ingredientExists = await ingredientRepo.GetIngredientById(ingredient.IngredientId);
                    if ( ingredientExists == null ) {
                        return ApiResponse<int>.FailResponse($"Ingredient {ingredient.IngredientId} does not exist");
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
                CategoryId = productDTO.categoryId
            };


            try {
                await transactionRepo.BeginTransactionAsync();
                await productRepo.AddProduct(products);


                if ( productDTO.productOptionsDTO != null ) {
                    foreach ( var ingredient in productDTO.productOptionsDTO ) {
                        var ingredientExists = await ingredientRepo.GetIngredientById(ingredient.IngredientId);
                        if ( ingredientExists == null ) {
                            return ApiResponse<int>.FailResponse($"Ingredient {ingredient.optionName} does not exist");
                        }
                        ProductOptions productOptions = new ProductOptions() {
                            OptionName = ingredient.optionName,
                            IngredientId = ingredient.IngredientId,
                            OptionValue = ingredient.optionValue,
                            Unit = ingredient.unit,
                            Price = ingredient.price,
                            ProductId = products.ProductId
                        };
                        await productRepo.ProductAddOption(productOptions);
                    }
                }


                if ( productDTO.recipeDTO != null ) {
                    foreach ( var ingredient in productDTO.recipeDTO ) {
                        var ingredientExists = await ingredientRepo.GetIngredientById(ingredient.IngredientId);
                        if ( ingredientExists == null ) {
                            return ApiResponse<int>.FailResponse($"Ingredient {ingredient.IngredientId} does not exist");
                        }
                        Recipes recipes = new Recipes() {
                            IngredientId = ingredient.IngredientId,
                            Quantity = ingredient.Quantity,
                            Unit = ingredient.Unit,
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
            var products = await productRepo.GetAllProducts();
            var totalItems = products.Count;
            var totalPages = ( int )Math.Ceiling(totalItems / ( double )productPageDTO.pageSize);

            if ( productPageDTO.page < 1 ) productPageDTO.page = 1;
            if ( productPageDTO.CategoryId > 0 ) {
                products = products.Where(p => p.CategoryId == productPageDTO.CategoryId.Value).ToList();
            }
            if ( !string.IsNullOrEmpty(productPageDTO.Search) ) {
                products = products.Where(p => p.ProductName.Contains(productPageDTO.Search, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            var pagedProducts = products
                .Skip(( productPageDTO.page - 1 ) * productPageDTO.pageSize)
                .Take(productPageDTO.pageSize)
                .ToList();
            var productResponses = pagedProducts.Select(p => new ProductResponse {
                productId = p.ProductId,
                productName = p.ProductName,
                price = p.Price,
                priceSale = p.PriceSale,
                sold = p.SoldCount,
                averageRating = p.AverageRating,
                image = p.images?.FirstOrDefault()?.ImagesUrl?.ToString() ?? "/no-image.png"
            }).ToList();
            var pageResponse = new PageResponse<ProductResponse> {
                page = productPageDTO.page,
                pageSize = productPageDTO.pageSize,
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
            if ( isExists ) {
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
                if ( productDTO.productOptions != null && productDTO.productOptions.Count > 0 ) {
                    // xoa het option cu
                    product.productOptions.Clear();
                    foreach ( var ingredient in productDTO.productOptions ) {
                        // them option moi
                        var ingredientExists = await ingredientRepo.GetIngredientById(ingredient.IngredientId);
                        if ( ingredientExists == null ) {
                            return ApiResponse<int>.FailResponse($"Ingredient {ingredient.optionName} does not exist");
                        }
                        ProductOptions productOptions = new ProductOptions() {
                            OptionName = ingredient.optionName,
                            IngredientId = ingredient.IngredientId,
                            OptionValue = ingredient.optionValue,
                            Unit = ingredient.unit,
                            Price = ingredient.price,
                            ProductId = product.ProductId
                        };
                        product.productOptions.Add(productOptions);
                    }
                }
                if ( productDTO.recipes != null && productDTO.recipes.Count > 0 ) {
                    // xoa het recipe cu
                    product.recipes.Clear();
                    foreach ( var ingredient in productDTO.recipes ) {
                        // them recipe moi
                        var ingredientExists = await ingredientRepo.GetIngredientById(ingredient.IngredientId);
                        if ( ingredientExists == null ) {
                            return ApiResponse<int>.FailResponse($"Ingredient {ingredient.IngredientId} does not exist");
                        }
                        Recipes recipes = new Recipes() {
                            IngredientId = ingredient.IngredientId,
                            Quantity = ingredient.Quantity,
                            Unit = ingredient.Unit,
                            ProductId = product.ProductId
                        };
                        product.recipes.Add(recipes);
                    }
                }

                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<int>.SuccessResponse(product.ProductId, "Product updated successfully");
            }
            catch ( Exception ex ) {

                await transactionRepo.RollbackAsync();
               
                return ApiResponse<int>.FailResponse($"Error updating product: {ex.Message}");
            }
        }



        public async Task<ApiResponse<bool>> AddImgProduct(int productid,List<ImgProductDTO> imgProductDTO) {
            if ( imgProductDTO == null  || imgProductDTO.Count == 0 ) {
                return ApiResponse<bool>.FailResponse("Thêm sản phẩm thành công nhưng chưa có hình ảnh.");
            }
            var product = await productRepo.GetProductById(productid);
            if ( product == null ) {
                return ApiResponse<bool>.FailResponse("Product does not exist");
            }
            var savedFiles = new List<string>();
            try {
                await transactionRepo.BeginTransactionAsync();
                foreach ( var file in imgProductDTO ) {
                    if ( file.imgId == 0 && file != null && file.file != null && file.file.Length > 0 ) {
                        string imageURL = await handlerFiles.SaveFile(file.file, "products");
                        Images image = new Images() {
                            ImagesUrl = imageURL,
                            ProductId = product.ProductId
                        };
                        savedFiles.Add(imageURL);
                        product.images.Add(image);
                    }
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

        public async Task<ApiResponse<bool>> UpdateImgProduct(int productId, List<ImgProductDTO> productDTO) {
            var savedFiles = new List<string>();
            List<Images> imagesToRemove = new List<Images>();
            var product = await productRepo.GetProductById(productId);
            if ( product == null ) {
                return ApiResponse<bool>.FailResponse("Sản phẩm đã cập nhật nhưng lỗi khi cập nhật ảnh.");
            }
            try {
                if ( productDTO != null && productDTO.Count > 0 ) {
                    // xoa nhung img khong co trong nhung img moi
                    var imagesToRemove2 = product.images
                    .Where(img => !productDTO.Any(f => f.imgId != 0 && f.imgId == img.ImagesId))
                    .ToList();

                    foreach ( var img in imagesToRemove2 ) {
                        imagesToRemove.Add(img);
                        product.images.Remove(img);
                    }
                    // them nhung img moi
                    foreach ( var file in productDTO ) {
                        if ( file.imgId == 0 && file != null && file.file != null && file.file.Length > 0 ) {
                            string imageURL = await handlerFiles.SaveFile(file.file, "products");
                            Images image = new Images() {
                                ImagesUrl = imageURL,
                                ProductId = product.ProductId
                            };
                            savedFiles.Add(imageURL);
                            product.images.Add(image);
                        }
                    }

                }


                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();

                // xoa file img khoi server 
                foreach ( var img in imagesToRemove ) {
                    try {
                        handlerFiles.DeleteFile(img.ImagesUrl);
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
                    // Log the file deletion error
                    Console.WriteLine($"Error deleting files: {fileEx.Message}");
                }
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
    }
}
