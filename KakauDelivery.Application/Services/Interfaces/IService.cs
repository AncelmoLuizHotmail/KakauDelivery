namespace KakauDelivery.Application.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
