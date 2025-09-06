using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungQuanLiNhaHang.Models {
    public class RefreshTokens {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RefreshTokensId { get; set; }
        public required string Token {  get; set; }
        public required string JwtId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public string? ReplacedByToken { get; set; }

        public int? customerId { get; set; }
        public Customers? Customers { get; set; }
        public int? employeeId { get; set; }
        public Employees? Employees { get; set; }
    }
}
