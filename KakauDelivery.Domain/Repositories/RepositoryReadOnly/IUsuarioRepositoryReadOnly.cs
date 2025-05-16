using KakauDelivery.Domain.Entities;

namespace KakauDelivery.Domain.Repositories.RepositoryReadOnly
{
    public interface IUsuarioRepositoryReadOnly : IRepositoryReadOnly<Usuario>
    {
        Task<IEnumerable<Usuario>> GetUsuarioByEmail(string email);
    }
}
