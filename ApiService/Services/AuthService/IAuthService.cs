using ApiService.Requests.Auth;
using ApiService.Responces.Auth.Register;

namespace ApiService.Services.AuthService
{
    public interface IAuthService
    {

        public Task<RegisterResponceBase> Register(RegisterRequest request);
    }
}
