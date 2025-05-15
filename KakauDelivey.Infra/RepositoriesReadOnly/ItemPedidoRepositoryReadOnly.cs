using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Repositories.RepositoryReadOnly;
using KakauDelivey.Infra.KakauDeliveryContext;

namespace KakauDelivey.Infra.RepositoriesReadOnly
{
    public class ItemPedidoRepositoryReadOnly : RepositoryReadOnly<ItemPedido>, IItemPedidoRepositoryReadOnly
    {
        public ItemPedidoRepositoryReadOnly(KakauDeliveryDbContext context) : base(context)
        {
        }
    }
}
