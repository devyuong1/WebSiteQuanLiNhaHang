using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace UngDungQuanLiNhaHang.Security {
    public class JWT {
        private readonly IConfiguration configuration;
        public JWT(IConfiguration configuration) {
            this.configuration = configuration;
        }

        public string GenerateJWT(string userName, int khachHangID, string role) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? "ashsjabhdsjksdfjkdsfjsdjkfbsdjk123");
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserID", khachHangID.ToString()),
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, role),

                }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(configuration["Jwt:Expires"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"]
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

        public string GenerateRefreshToken(string userName ,int employeeId) {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? "ashsjabhdsjksdfjkdsfjsdjkfbsdjk123");
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("employeeId", employeeId.ToString()),
                    new Claim(ClaimTypes.Name, userName),
                    

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"]
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token) {
            var tokenValidationParameters = new TokenValidationParameters {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                // quan trọng: bỏ qua validate lifetime để lấy được principal ngay cả khi token hết hạn
                ValidateLifetime = false,

                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? "ashsjabhdsjksdfjkdsfjsdjkfbsdjk123"))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            try {
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

                // Kiểm tra lại loại token
                if ( securityToken is not JwtSecurityToken jwtSecurityToken ||
                    !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase) ) {
                    throw new SecurityTokenException("Invalid token");
                }

                return principal;
            }
            catch {
                return null;
            }
        }

    }
}
