using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Repositories.Repository;
using KakauDelivey.Infra.KakauDeliveryContext;

namespace KakauDelivey.Infra.Repositories
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(KakauDeliveryDbContext context) : base(context)
        {
        }

        public async Task DeletePhysical(Pedido entity)
        {
            _context.Pedidos.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
