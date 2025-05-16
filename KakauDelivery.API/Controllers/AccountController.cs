using KakauDelivery.Application.Applications.Interfaces;
using KakauDelivery.Application.Interop.Usuario;
using KakauDelivery.Application.Services;
using KakauDelivery.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KakauDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IUsuarioApp _usuarioApp;
        private readonly IAuthService _authService;

        public AccountController(IUsuarioApp usuarioApp, IAuthService authService)
        {
            _usuarioApp = usuarioApp;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UsuarioInputModel inputModel)
        {
            try
            {
                var usuario = await _usuarioApp.RegistrarUsuario(inputModel);
                var token = await _authService.Authenticate(inputModel.Email, inputModel.Senha);

                return Ok(new
                {
                    Token = token,
                    Usuario = new
                    {
                        usuario.Data.Id,
                        usuario.Data.Email,
                        usuario.Data.Perfil,
                        usuario.Data.IdCliente
                    }
                });
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
