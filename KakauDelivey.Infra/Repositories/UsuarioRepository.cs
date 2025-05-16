using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Repositories.Repository;
using KakauDelivey.Infra.KakauDeliveryContext;

namespace KakauDelivey.Infra.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(KakauDeliveryDbContext context) : base(context)
        {
        }
    }
}
