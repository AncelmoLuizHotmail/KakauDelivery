using KakauDelivery.Domain.Entities;

namespace KakauDelivery.Application.Services.Interfaces
{
    public interface IPedidoService
    {
        Task Create(Pedido entity);
        Task Update(Pedido entity);
        Task Delete(Pedido entity);
        Task DeleteLogical(Pedido entity);
    }
}
