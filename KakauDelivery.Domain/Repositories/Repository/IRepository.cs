namespace KakauDelivery.Domain.Repositories.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task SaveChanges();
    }
}
