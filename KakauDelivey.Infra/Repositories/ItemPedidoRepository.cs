using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Repositories.Repository;
using KakauDelivey.Infra.KakauDeliveryContext;

namespace KakauDelivey.Infra.Repositories
{
    public class ItemPedidoRepository : Repository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(KakauDeliveryDbContext context) : base(context)
        {
        }
    }
}
