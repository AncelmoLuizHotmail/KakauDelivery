using KakauDelivery.Domain.Entities;

namespace KakauDelivery.Domain.Repositories.RepositoryReadOnly
{
    public interface IPedidoRepositoryReadOnly : IRepositoryReadOnly<Pedido>
    {
        Task<Pedido?> GetPedidoByCliente(int idPedido, int idCliente);
    }
}
