namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class ApiResponse<T> {
        public bool Success { get; set; }
        public string? Message { get; set; }

        public T? Access { get; set; }

        public static ApiResponse<T> SuccessResponse(T? Data, string? message = null)
            => new ApiResponse<T> { Success = true, Access = Data, Message = message };
        public static ApiResponse<T> FailResponse(string? message = null)
            => new ApiResponse<T> { Success = false, Message = message };
    }
}
