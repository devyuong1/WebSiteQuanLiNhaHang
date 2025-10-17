namespace UngDungQuanLiNhaHang.ResponseDTO {
    public class PageResponse<T> {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int totalItems { get; set; }
        public int totalPages { get; set; }

        public List<T> list { get; set; } = [];


        public PageResponse() {

        }

        public PageResponse(int page, int pageSize, int totalItems, int totalPages, List<T> item) {
            this.page = page;
            this.pageSize = pageSize;
            this.totalItems = totalItems;
            this.totalPages = totalPages;
            this.list = item;


        }
    }
}
