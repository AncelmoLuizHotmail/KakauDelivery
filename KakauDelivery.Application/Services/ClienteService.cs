using KakauDelivery.Application.Services.Interfaces;
using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Repositories.Repository;

namespace KakauDelivery.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(Cliente entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(Cliente entity)
        {
            await _repository.Delete(entity);
        }

        public async Task Update(Cliente entity)
        {
            await _repository.Update(entity);
        }
    }
}
