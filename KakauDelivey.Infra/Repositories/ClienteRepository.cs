using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Repositories.Repository;
using KakauDelivey.Infra.KakauDeliveryContext;

namespace KakauDelivey.Infra.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(KakauDeliveryDbContext context) : base(context)
        {
        }
    }
}
