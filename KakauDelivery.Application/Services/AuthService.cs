using KakauDelivery.Application.Applications.Interfaces;
using KakauDelivery.Application.Services.Interfaces;
using KakauDelivery.Domain.Entities;
using KakauDelivey.Infra.KakauDeliveryContext;
using KakauDelivey.Infra.Services;
using Microsoft.EntityFrameworkCore;

namespace KakauDelivery.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly KakauDeliveryDbContext _context;
        private readonly JwtService _jwtService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(KakauDeliveryDbContext context,
            JwtService jwtService, IPasswordHasher passwordHasher)
        {
            _context = context;
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Authenticate(string email, string senha)
        {
            var usuario = await _context.Usuarios
             .FirstOrDefaultAsync(u => u.Email == email);

            var usuarioValidado = _passwordHasher.VerifyPassword(usuario.SenhaHash, senha);

            if (usuario == null || !usuarioValidado)
                return null;

            return _jwtService.GenerateToken(usuario);
        }

        public async Task<Usuario> GetById(int idUsuario)
        {
            return await _context.Usuarios.FindAsync(idUsuario);
        }
    }
}
