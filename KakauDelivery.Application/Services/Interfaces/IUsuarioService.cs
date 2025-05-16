using KakauDelivery.Domain.Entities;

namespace KakauDelivery.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task Create(Usuario entity);
    }
}
