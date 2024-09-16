using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PetAdoption.Api.Data.Entities;

public class TokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration) =>
        new()
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            IssuerSigningKey = GetSecurityKey(configuration)
        };

    public string GenerateJWT(IEnumerable<Claim> additionalClaims = null)
    {
        // Lấy security key từ cấu hình
        var securityKey = GetSecurityKey(_configuration);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var expireInMinutes = Convert.ToInt32(_configuration["Jwt:ExpireInMinutes"] ?? "60");

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // Nếu có thêm các claims tùy chỉnh thì thêm vào danh sách claims
        if (additionalClaims?.Any() == true)
        {
            claims.AddRange(additionalClaims);
        }

        // Tạo JwtSecurityToken với các thông tin cần thiết
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: "*", // Chỉ định audience (* nghĩa là cho tất cả)
            claims: claims,
            expires: DateTime.Now.AddMinutes(expireInMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateJwt(User user, IEnumerable<Claim>? additionalClaims = null)
    {
        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Name)
    };

        if (additionalClaims?.Any() == true)
            claims.AddRange(additionalClaims);

        // Gọi phương thức GenerateJWT (với các claims) để sinh token
        return GenerateJWT(claims);  
    }


    private static SymmetricSecurityKey GetSecurityKey(IConfiguration configuration) =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key is missing")));
}
