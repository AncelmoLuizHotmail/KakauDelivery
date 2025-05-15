using System.Linq.Expressions;

namespace KakauDelivery.Domain.Repositories.RepositoryReadOnly
{
    public interface IRepositoryReadOnly<T> where T : class
    {
        Task<T?> GetById(int id);
        Task<List<T>> GetAll();
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);
    }
}
