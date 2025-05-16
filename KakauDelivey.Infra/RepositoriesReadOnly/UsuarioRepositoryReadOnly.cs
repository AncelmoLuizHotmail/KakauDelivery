using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Repositories.RepositoryReadOnly;
using KakauDelivey.Infra.KakauDeliveryContext;

namespace KakauDelivey.Infra.RepositoriesReadOnly
{
    public class UsuarioRepositoryReadOnly : RepositoryReadOnly<Usuario>, IUsuarioRepositoryReadOnly
    {
        public UsuarioRepositoryReadOnly(KakauDeliveryDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Usuario>> GetUsuarioByEmail(string email)
        {
            return await Get(x => x.Email == email);
        }
    }
}
