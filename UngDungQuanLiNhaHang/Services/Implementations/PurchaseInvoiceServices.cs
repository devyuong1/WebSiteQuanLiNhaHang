using System.Diagnostics;
using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.Repository;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;

namespace UngDungQuanLiNhaHang.Services.Implementations {
    public class PurchaseInvoiceServices(
        PurchaseInvoiceRepo purchaseInvoiceRepo,
        TransactionRepo transactionRepo,
        IngredientRepo ingredientRepo) : IPurchaseInvoiceServices {
        public async Task<ApiResponse<bool>> AddPurchaseInvoice(PurchaseInvoiceDTO purchaseInvoiceDTO) {
            if ( purchaseInvoiceDTO == null )
                return ApiResponse<bool>.FailResponse("Dữ liệu hóa đơn nhập hàng không được để trống");
            if ( purchaseInvoiceDTO.supplierId <= 0 )
                return ApiResponse<bool>.FailResponse("Mã nhà cung cấp không hợp lệ");
            if ( purchaseInvoiceDTO.employeeId <= 0 )
                return ApiResponse<bool>.FailResponse("Mã nhân viên không hợp lệ");
            if ( purchaseInvoiceDTO.items == null || !purchaseInvoiceDTO.items.Any() || purchaseInvoiceDTO.items.Any(item => item == null) )
                return ApiResponse<bool>.FailResponse("Danh sách mặt hàng không được để trống");
            var validIngredients = new Dictionary<int, Ingredient>();
            foreach ( var item in purchaseInvoiceDTO.items ) {
                var ingredient = await ingredientRepo.GetIngredientById(item.ingredientId);
                if ( ingredient == null )
                    return ApiResponse<bool>.FailResponse($"Nguyên liệu với mã {item.ingredientId} không tồn tại");
                validIngredients[ingredient.IngredientId] = ingredient;
            }
            try {
                PurchaseInvoice purchaseInvoice = new PurchaseInvoice {
                    SupplierId = purchaseInvoiceDTO.supplierId,
                    EmployeeId = purchaseInvoiceDTO.employeeId,
                    Create_At = purchaseInvoiceDTO.create_At,
                    Totalamount = purchaseInvoiceDTO.totalamount,
                    IsPayment = purchaseInvoiceDTO.isPayment,
                    purchaseInvoiceItems = purchaseInvoiceDTO.items.Select(item => new PurchaseInvoiceItem {
                        IngredientId = item.ingredientId,
                        Quantity = item.quantity,
                        Price = item.price,
                        Unit = item.unit
                    }).ToList()

                };
                await transactionRepo.BeginTransactionAsync();
                foreach ( var item in purchaseInvoice.purchaseInvoiceItems ) {

                    validIngredients[item.IngredientId].Quantity += item.Quantity;
                    ingredientRepo.UpdateIngredient(validIngredients[item.IngredientId]);

                }
                await transactionRepo.CompleteAsync();
                await purchaseInvoiceRepo.AddPurcgaseInvoice(purchaseInvoice);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Thêm hóa đơn nhập hàng thành công");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse($"Thêm hóa đơn nhập hàng thất bại. Lỗi: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PageResponse<PurchaseInvoiceResponse>>> GetAllPurchaseInvoices(int page = 1) {
            int pageSize = 12;
            var result = await purchaseInvoiceRepo.GetAllPurchaseInvoices();
            if ( result == null || !result.Any() ) {
                return ApiResponse<PageResponse<PurchaseInvoiceResponse>>.FailResponse("Không có hóa đơn nhập hàng nào");
            }
            if ( result.Any(a => a.Employees == null || a.Suppliers == null) ) {
                return ApiResponse<PageResponse<PurchaseInvoiceResponse>>.FailResponse("Dữ liệu hóa đơn nhập hàng không đầy đủ");
            }
            var purchaseInvoiceDTOs = result.Select(pi => new PurchaseInvoiceResponse {
                purchaseInvoiceId = pi.PurchaseInvoiceId,
                totalamount = pi.Totalamount,
                create_At = pi.Create_At.AddHours(7),
                isPayment = pi.IsPayment,
                supplierName = pi.Suppliers?.SupplierName,
                employeeName = pi.Employees?.Fullname,

            }).ToList();
            var pagedPurchaseInvoiceDTOs = purchaseInvoiceDTOs
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            var totalItems = purchaseInvoiceDTOs.Count;
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            var pageResponse = new PageResponse<PurchaseInvoiceResponse> {
                totalItems = totalItems,
                totalPages = totalPages,
                pageSize = pageSize,
                page = page,
                list = pagedPurchaseInvoiceDTOs
            };
            return ApiResponse<PageResponse<PurchaseInvoiceResponse>>.SuccessResponse(pageResponse, "Lấy danh sách hóa đơn nhập hàng thành công");
        }

        public async Task<ApiResponse<PurchaseInvoiceResponse>> GetPurchaseInvoiceById(int purchaseInvoiceId) {
            var result = await purchaseInvoiceRepo.GetPurchaseInvoiceById(purchaseInvoiceId);
            if ( result == null || result.purchaseInvoiceItems == null ) {
                return ApiResponse<PurchaseInvoiceResponse>.FailResponse("Không tìm thấy hóa đơn nhập hàng");
            }
            if ( result.Employees == null || result.Suppliers == null ) {
                return ApiResponse<PurchaseInvoiceResponse>.FailResponse("Dữ liệu hóa đơn nhập hàng không đầy đủ");
            }
            var purchaseInvoiceDTO = new PurchaseInvoiceResponse {
                purchaseInvoiceId = result.PurchaseInvoiceId,
                totalamount = result.Totalamount,
                create_At = result.Create_At,
                isPayment = result.IsPayment,
                supplierName = result.Suppliers?.SupplierName,
                employeeName = result.Employees?.Fullname,
                supplierId = result.SupplierId,
                purchaseInvoiceItems = result.purchaseInvoiceItems.Select(item => new PurchaseInvoiceItemResponse {
                    purchaseInvoiceItemId = item.PurchaseInvoiceId,
                    ingredientName = item.Ingredient?.IngredientName,
                    quantity = item.Quantity,
                    price = item.Price,
                    unit = item.Unit,
                    ingredientId = item.IngredientId
                }).ToList() ?? new List<PurchaseInvoiceItemResponse>()
            };
            return ApiResponse<PurchaseInvoiceResponse>.SuccessResponse(purchaseInvoiceDTO, "Lấy thông tin hóa đơn nhập hàng thành công");
        }

        public async Task<ApiResponse<purchaseInvoiceDashboard>> GetPurchaseInvoiceDashboard() {
            var result = await purchaseInvoiceRepo.GetAllByDay(DateTime.Now);
            
            var res = new purchaseInvoiceDashboard() {
                totalPurchaseInvoices = result.Count(),
                totalAmountSpent = result.Where(item => item.IsPayment == true).Sum(item => item.Totalamount),
                totalDebtAmount = result.Where(item => item.IsPayment == false).Sum(item => item.Totalamount)
            };
            return ApiResponse<purchaseInvoiceDashboard>.SuccessResponse(res);
        }

        public async Task<ApiResponse<bool>> PaymentPurchaseInvoice(int purchaseInvoiceId) {

            var purchaseInvoice = await purchaseInvoiceRepo.GetPurchaseInvoiceById(purchaseInvoiceId);
            if ( purchaseInvoice == null ) {
                return ApiResponse<bool>.FailResponse("Không tìm thấy hóa đơn nhập hàng");
            }
            if ( purchaseInvoice.IsPayment ) {
                return ApiResponse<bool>.FailResponse("Hóa đơn nhập hàng đã được thanh toán");
            }
            try {
                await transactionRepo.BeginTransactionAsync();
                purchaseInvoice.IsPayment = true;
                purchaseInvoiceRepo.UpdatePurchaseInvoice(purchaseInvoice);

                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Thanh toán hóa đơn nhập hàng thành công");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse($"Thanh toán hóa đơn nhập hàng thất bại. Lỗi: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> UpdatePurchaseInvoice(PurchaseInvoiceDTO purchaseInvoiceDTO) {
            var existingInvoice = await purchaseInvoiceRepo.GetPurchaseInvoiceById(purchaseInvoiceDTO.purchaseInvoiceId);
            if ( existingInvoice == null ) {
                return ApiResponse<bool>.FailResponse("Không tìm thấy hóa đơn nhập hàng");
            }
            if ( existingInvoice.IsPayment ) {
                return ApiResponse<bool>.FailResponse("Hóa đơn nhập hàng đã được thanh toán, không thể cập nhật");
            }
            if ( purchaseInvoiceDTO.items.Count == 0
                || purchaseInvoiceDTO.items.Any(
                    item => item == null
                    || item.quantity <= 0 
                    || item.price <= 0)  
                )
                return ApiResponse<bool>.FailResponse("Danh sách mặt hàng không được để trống");
            var validIngredients = new Dictionary<int, Ingredient>();
            foreach ( var item in purchaseInvoiceDTO.items ) {
                var ingredient = await ingredientRepo.GetIngredientById(item.ingredientId);
                if ( ingredient == null )
                    return ApiResponse<bool>.FailResponse($"Nguyên liệu với mã {item.ingredientId} không tồn tại");
                validIngredients[ingredient.IngredientId] = ingredient;
            }


           
            

            try {
                await transactionRepo.BeginTransactionAsync();
                // Revert the ingredient quantities based on the existing invoice items
                foreach ( var item in existingInvoice.purchaseInvoiceItems ) {
                    var ingredient = await ingredientRepo.GetIngredientById(item.IngredientId);
                    if ( ingredient != null ) {
                        ingredient.Quantity -= item.Quantity;
                        ingredientRepo.UpdateIngredient(ingredient);
                    }
                }
                await transactionRepo.CompleteAsync();
                existingInvoice.purchaseInvoiceItems.Clear();
                // Update the invoice details
                existingInvoice.Totalamount = purchaseInvoiceDTO.totalamount;
                existingInvoice.IsPayment = purchaseInvoiceDTO.isPayment;
                existingInvoice.Create_At = purchaseInvoiceDTO.create_At;
                existingInvoice.purchaseInvoiceItems = purchaseInvoiceDTO.items.Select(item => new PurchaseInvoiceItem {
                    IngredientId = item.ingredientId,
                    Quantity = item.quantity,
                    Price = item.price,
                    Unit = item.unit
                }).ToList();
                purchaseInvoiceRepo.UpdatePurchaseInvoice(existingInvoice);
                
                // Update the ingredient quantities based on the new invoice items
                foreach ( var item in existingInvoice.purchaseInvoiceItems ) {
                    validIngredients[item.IngredientId].Quantity += item.Quantity;
                    ingredientRepo.UpdateIngredient(validIngredients[item.IngredientId]);
                }
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Cập nhật hóa đơn nhập hàng thành công");
            }
            catch ( Exception ex ) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse($"Cập nhật hóa đơn nhập hàng thất bại. Lỗi: {ex.Message}");
            }
        }
    }
}
