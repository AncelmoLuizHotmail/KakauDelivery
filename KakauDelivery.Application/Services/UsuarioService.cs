using KakauDelivery.Application.Services.Interfaces;
using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Repositories.Repository;

namespace KakauDelivery.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(Usuario entity)
        {
            await _repository.Create(entity);
        }
    }
}
