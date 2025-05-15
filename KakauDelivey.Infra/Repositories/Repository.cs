using KakauDelivery.Domain.Repositories.Repository;
using KakauDelivey.Infra.KakauDeliveryContext;

namespace KakauDelivey.Infra.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly KakauDeliveryDbContext _context;

        protected Repository(KakauDeliveryDbContext context)
        {
            _context = context;
        }

        public virtual async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveChanges();
        }

        public virtual async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(T entity)
        {
            _context.Set<T>().Update(entity);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
