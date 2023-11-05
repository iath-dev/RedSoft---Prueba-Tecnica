using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RESTApi.Dtos;
using RESTApi.Interface.Service;
using RESTApi.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace RESTApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IConfiguration _config;
        public IAuthService _authService;

        public AuthController(IConfiguration config)
        {
            _config = config;
            _authService = new AuthService(config);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult login([FromBody] AuthDto auth)
        {
            IActionResult  response = Unauthorized();

            if(auth != null)
            {
                var token = _authService.GenerateJSONWebToken(auth);
                response = Ok(new { token });
            }

            return response;
        }
    }
}
