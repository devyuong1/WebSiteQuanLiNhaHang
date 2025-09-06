using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class Images {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImagesId { get; set; }
        public required string ImagesUrl { get; set; }

        public int productId { get; set; }
        public Products? products { get; set; }
    }
}
