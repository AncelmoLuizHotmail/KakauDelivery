using KakauDelivery.Application.Services.Interfaces;
using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Repositories.Repository;

namespace KakauDelivery.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUsuarioRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Create(Usuario entity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _repository.Create(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
           
        }
    }
}
