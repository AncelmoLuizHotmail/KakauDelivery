using KakauDelivery.Application.Services.Interfaces;
using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Repositories.Repository;

namespace KakauDelivery.Application.Services
{
    public class ClienteService : Service<Cliente>, IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
