using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Repositories.RepositoryReadOnly;
using KakauDelivey.Infra.KakauDeliveryContext;

namespace KakauDelivey.Infra.RepositoriesReadOnly
{
    public class ClienteRepositoryReadOnly : RepositoryReadOnly<Cliente>, IClienteRepositoryReadOnly
    {
        public ClienteRepositoryReadOnly(KakauDeliveryDbContext context) : base(context)
        {
        }
    }
}
