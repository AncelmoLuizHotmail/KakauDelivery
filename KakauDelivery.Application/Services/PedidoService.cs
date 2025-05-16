using KakauDelivery.Application.Services.Interfaces;
using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Repositories.Repository;

namespace KakauDelivery.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PedidoService(IPedidoRepository pedidoRepository, IUnitOfWork unitOfWork)
        {
            _pedidoRepository = pedidoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Create(Pedido entity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _pedidoRepository.Create(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task DeleteLogical(Pedido entity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _pedidoRepository.Delete(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
        public async Task Delete(Pedido entity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _pedidoRepository.Excluir(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task Update(Pedido entity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _pedidoRepository.Update(entity);
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
