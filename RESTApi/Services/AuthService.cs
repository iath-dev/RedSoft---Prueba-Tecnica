using Microsoft.IdentityModel.Tokens;
using RESTApi.Dtos;
using RESTApi.Interface.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace RESTApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;

        public AuthService(IConfiguration config) {
            _config = config;
        }

        public string GenerateJSONWebToken(AuthDto data)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["JwtSettings:Issuer"], _config["JwtSettings:Issuer"], null, expires: DateTime.Now.AddHours(2), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
