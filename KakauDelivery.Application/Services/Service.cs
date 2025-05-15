using KakauDelivery.Application.Services.Interfaces;
using KakauDelivery.Domain.Repositories.Repository;

namespace KakauDelivery.Application.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task Create(T entity)
        {
            await _repository.Create(entity);
        }

        public virtual async Task Update(T entity)
        {
            await _repository.Update(entity);
        }
        public async Task Delete(T entity)
        {
            await _repository.Delete(entity);
        }

    }
}
