using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UngDungQuanLiNhaHang.Models {
    public class Images {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImagesId { get; set; }
        public required string ImagesUrl { get; set; }
       
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [JsonIgnore]
        public Products? Products { get; set; }
    }
}
