using KakauDelivery.Domain.Repositories.RepositoryReadOnly;
using KakauDelivey.Infra.KakauDeliveryContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KakauDelivey.Infra.RepositoriesReadOnly
{
    public abstract class RepositoryReadOnly<T> : IRepositoryReadOnly<T> where T : class
    {
        protected readonly KakauDeliveryDbContext _context;

        protected RepositoryReadOnly(KakauDeliveryDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>()
                .ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync();
        }
    }
}
