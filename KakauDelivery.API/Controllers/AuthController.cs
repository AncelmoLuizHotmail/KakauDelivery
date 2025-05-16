using KakauDelivery.Application.Interop.Auth;
using KakauDelivery.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KakauDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var token = await _authService.Authenticate(request.Email, request.Senha);

            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }
    }
}
