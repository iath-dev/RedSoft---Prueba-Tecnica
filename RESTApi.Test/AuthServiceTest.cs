using Microsoft.Extensions.Configuration;
using RESTApi.Dtos;
using RESTApi.Interface.Service;
using RESTApi.Services;

namespace RESTApi.Test
{
    public class AuthServiceTest
    {
        public IAuthService _authService;

        public AuthServiceTest()
        {
            var configCollection = new Dictionary<string, string>
            {
                {"JwtSettings:Key", "IeEh7KPK?W1yiXN5DoiVX5HwCD"},
                {"JwtSettings:Issuer", "redsoft.test.com"}
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configCollection)
                .Build();

            _authService = new AuthService(configuration);
        }

        [Fact]
        public void CheckJWT()
        {
            var data = new AuthDto()
            {
                Email = "test@mail.com",
                Password = "123456"
            };

            var token = _authService.GenerateJSONWebToken(data);

            Assert.NotNull(token);
        }
    }
}