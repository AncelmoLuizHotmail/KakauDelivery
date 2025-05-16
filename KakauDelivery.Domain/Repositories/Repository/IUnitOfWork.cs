namespace KakauDelivery.Domain.Repositories.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IClienteRepository Clientes { get; }
        IPedidoRepository Pedidos { get; }
        IUsuarioRepository Usuarios { get; }

        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task<int> SaveChangesAsync();
    }
}
