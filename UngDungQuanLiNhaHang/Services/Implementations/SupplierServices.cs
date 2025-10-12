using UngDungQuanLiNhaHang.Models;
using UngDungQuanLiNhaHang.Repository;
using UngDungQuanLiNhaHang.RequestDTO;
using UngDungQuanLiNhaHang.ResponseDTO;
using UngDungQuanLiNhaHang.Services.Interfaces;

namespace UngDungQuanLiNhaHang.Services.Implementations {
    public class SupplierServices(SupplierRepo supplierRepo, TransactionRepo transactionRepo,AddressRepo addressRepo) : ISupplierServices {
        public async Task<ApiResponse<bool>> AddSupplier(SupplierDTO supplierDTO) {
            if (supplierDTO == null || supplierDTO.address == null) 
                return ApiResponse<bool>.FailResponse("Supplier data is null");
            var result = await supplierRepo.GetByName(supplierDTO.supplierName);
            if (result != null) 
                return ApiResponse<bool>.FailResponse("Supplier name already exists");
           
            try {
                await transactionRepo.BeginTransactionAsync();
                Address address = new Address {
                    Province = supplierDTO.address.province,
                    District = supplierDTO.address.district,
                    Street = supplierDTO.address.street,
                    Hamlet = supplierDTO.address.hamlet,
                    HouseNumber = supplierDTO.address.houseNumber,
                    IsDefault = true
                };
               
                await addressRepo.AddAddress(address);
                Suppliers suppliers = new Suppliers {
                    SupplierName = supplierDTO.supplierName,
                    Phone = supplierDTO.phone,
                    Email = supplierDTO.email,
                    Address = address,
                };
                await supplierRepo.AddSupplier(suppliers);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Thêm nhà cung cấp thành công.");
            }
            catch (Exception ex) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Lỗi khi thêm: "+ex.ToString());
            }
        }

       

        public async Task<ApiResponse<PageResponse<SupplierResponse>>> GetAllSuppliers(int page = 1) {
            int pageSize = 12;
            var suppliers = await supplierRepo.GetAllSuppliers();
            if (suppliers == null || !suppliers.Any() ) {
                return ApiResponse<PageResponse<SupplierResponse>>.FailResponse("No suppliers found.");
            }
            var response = suppliers.Select(s => new SupplierResponse { 
                supplierID = s.SupplierID,
                supplierName = s.SupplierName,
                phone = s.Phone,
                email = s.Email,
                address = s.Address == null ? null : new AddressResponse {
                    addressId = s.Address.AddressId,
                    province = s.Address.Province,
                    district = s.Address.District,
                    street = s.Address.Street,
                    hamlet = s.Address.Hamlet,
                    houseNumber = s.Address.HouseNumber,
                    isDefault = s.Address.IsDefault
                }
            }).ToList();
            var totalItems = response.Count;
            var pagedResponse = response
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            var pageResponse = new PageResponse<SupplierResponse> {
                page = page,
                pageSize = pageSize,
                totalItems = totalItems,
                totalPages = (int)Math.Ceiling((double)totalItems / pageSize),
                list = pagedResponse
            };
            return ApiResponse<PageResponse<SupplierResponse>>.SuccessResponse(pageResponse);
        }

        public async Task<ApiResponse<SupplierResponse>> GetSupplierById(int supplierId) {
            var result = await supplierRepo.GetSupplierById(supplierId);
            if ( result == null ) {
                return ApiResponse<SupplierResponse>.FailResponse("Supplier not found.");
            }
            var response = new SupplierResponse {
                supplierID = result.SupplierID,
                supplierName = result.SupplierName,
                phone = result.Phone,
                email = result.Email,
                address = result.Address == null ? null : new AddressResponse {
                    addressId = result.Address.AddressId,
                    province = result.Address.Province,
                    district = result.Address.District,
                    street = result.Address.Street,
                    hamlet = result.Address.Hamlet,
                    houseNumber = result.Address.HouseNumber,
                    isDefault = result.Address.IsDefault
                }
            };
            return ApiResponse<SupplierResponse>.SuccessResponse(response);
        }

        public async Task<ApiResponse<bool>> UpdateSupplier(SupplierDTO supplierDTO) {
            var result = await supplierRepo.GetSupplierById(supplierDTO.supplierID);
            if ( result == null ) {
                return ApiResponse<bool>.FailResponse("Supplier not found.");
            }
            try {
                await transactionRepo.BeginTransactionAsync();
                result.SupplierName = supplierDTO.supplierName;
                result.Phone = supplierDTO.phone;
                result.Email = supplierDTO.email;
                if (supplierDTO.address != null) {
                    if (result.Address == null) {
                        Address newAddress = new Address {
                            Province = supplierDTO.address.province,
                            District = supplierDTO.address.district,
                            Street = supplierDTO.address.street,
                            Hamlet = supplierDTO.address.hamlet,
                            HouseNumber = supplierDTO.address.houseNumber,
                            IsDefault = true
                        };
                        await addressRepo.AddAddress(newAddress);
                        result.Address = newAddress;
                    } else {
                        result.Address.Province = supplierDTO.address.province;
                        result.Address.District = supplierDTO.address.district;
                        result.Address.Street = supplierDTO.address.street;
                        result.Address.Hamlet = supplierDTO.address.hamlet;
                        result.Address.HouseNumber = supplierDTO.address.houseNumber;
                        
                    }
                }
                supplierRepo.UpdateSupplier(result);
                await transactionRepo.CompleteAsync();
                await transactionRepo.CommitAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Cập nhật nhà cung cấp thành công.");
            }
            catch (Exception ex) {
                await transactionRepo.RollbackAsync();
                return ApiResponse<bool>.FailResponse("Lỗi khi cập nhật: " + ex.ToString());
            }
        }
    }
}
