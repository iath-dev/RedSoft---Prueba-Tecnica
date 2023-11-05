using RESTApi.Dtos;

namespace RESTApi.Interface.Service
{
    public interface IAuthService
    {
        public string GenerateJSONWebToken(AuthDto data);
    }
}
