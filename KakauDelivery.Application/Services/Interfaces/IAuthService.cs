using KakauDelivery.Domain.Entities;

namespace KakauDelivery.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Authenticate(string email, string senha);
        Task<Usuario> GetById(int idUsuario);
    }
}
