using KakauDelivery.Domain.Repositories.Repository;
using KakauDelivey.Infra.KakauDeliveryContext;
using Microsoft.EntityFrameworkCore.Storage;

namespace KakauDelivey.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KakauDeliveryDbContext _context;
        private IDbContextTransaction? _transaction;

        public IClienteRepository Clientes { get; }
        public IPedidoRepository Pedidos { get; }
        public IUsuarioRepository Usuarios { get; }


        public UnitOfWork(KakauDeliveryDbContext context,
                          IClienteRepository clienteRepository,
                          IPedidoRepository pedidoRepository)
        {
            _context = context;
            Clientes = clienteRepository;
            Pedidos = pedidoRepository;
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
                _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();

            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}
