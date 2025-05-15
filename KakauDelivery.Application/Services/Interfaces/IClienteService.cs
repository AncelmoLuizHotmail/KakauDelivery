using KakauDelivery.Domain.Entities;

namespace KakauDelivery.Application.Services.Interfaces
{
    public interface IClienteService 
    {
        Task Create(Cliente entity);
        Task Update(Cliente entity);
        Task Delete(Cliente entity);
    }
}
