using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Enums;

namespace KakauDelivery.Domain.Repositories.RepositoryReadOnly
{
    public interface IPedidoRepositoryReadOnly : IRepositoryReadOnly<Pedido>
    {
        Task<Pedido?> GetPedidoByCliente(int idPedido, int idCliente);
        Task<IEnumerable<Pedido>?> GetPedidoByDataOrStatus(DateTime data, StatusPedidoEnum status);
    }
}
