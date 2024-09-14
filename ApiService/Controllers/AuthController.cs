using ApiService.Requests.Auth;
using ApiService.Responces.Auth.Register;
using ApiService.Services.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {


            try
            {

                RegisterResponceBase responce=await _authService.Register(request);

                return StatusCode(responce.status, responce);

            }catch (Exception ex)
            {

                return StatusCode(500, new
                {


                    status = 500,

                    body = new
                    {

                        message = ex.Message,
                    },

                    type = ex.GetType().ToString()
                });
            }
        }
    }
}
