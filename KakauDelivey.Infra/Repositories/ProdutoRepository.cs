using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Repositories.Repository;
using KakauDelivey.Infra.KakauDeliveryContext;

namespace KakauDelivey.Infra.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(KakauDeliveryDbContext context) : base(context)
        {
        }
    }
}
