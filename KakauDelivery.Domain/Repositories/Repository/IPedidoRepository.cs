using KakauDelivery.Domain.Entities;

namespace KakauDelivery.Domain.Repositories.Repository
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task DeletePhysical(Pedido entity);
    }
}
