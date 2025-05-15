using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Repositories.RepositoryReadOnly;
using KakauDelivey.Infra.KakauDeliveryContext;

namespace KakauDelivey.Infra.RepositoriesReadOnly
{
    public class ProdutoRepositoryReadOnly : RepositoryReadOnly<Produto>, IProdutoRepositoryReadOnly
    {
        public ProdutoRepositoryReadOnly(KakauDeliveryDbContext context) : base(context)
        {
        }
    }
}
