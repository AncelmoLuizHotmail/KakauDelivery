using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Repositories.RepositoryReadOnly;
using KakauDelivey.Infra.KakauDeliveryContext;

namespace KakauDelivey.Infra.RepositoriesReadOnly
{
    public class PedidoRepositoryReadOnly : RepositoryReadOnly<Pedido>, IPedidoRepositoryReadOnly
    {
        public PedidoRepositoryReadOnly(KakauDeliveryDbContext context) : base(context)
        {
        }
    }
}
