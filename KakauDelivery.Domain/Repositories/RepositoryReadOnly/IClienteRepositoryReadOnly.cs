using KakauDelivery.Domain.Entities;

namespace KakauDelivery.Domain.Repositories.RepositoryReadOnly
{
    public interface IClienteRepositoryReadOnly : IRepositoryReadOnly<Cliente>
    {
        Task<Cliente> GetById(int id);
    }
}
