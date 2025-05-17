using KakauDelivery.Domain.Entities;

namespace KakauDelivery.Application.Services.Interfaces
{
    public interface IPedidoService
    {
        Task Create(Pedido entity);
        Task Update(Pedido entity);
        Task DeletePhysical(Pedido entity);
        Task DeleteLogical(Pedido entity);
    }
}
