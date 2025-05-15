using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Repositories.RepositoryReadOnly;
using KakauDelivey.Infra.KakauDeliveryContext;
using Microsoft.EntityFrameworkCore;

namespace KakauDelivey.Infra.RepositoriesReadOnly
{
    public class ClienteRepositoryReadOnly : RepositoryReadOnly<Cliente>, IClienteRepositoryReadOnly
    {
        public ClienteRepositoryReadOnly(KakauDeliveryDbContext context) : base(context)
        {
        }

        public override async Task<Cliente?> GetById(int id)
        {
            return await _context.Clientes
                .Include(c => c.Pedidos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<Cliente>> GetAll()
        {
            return await _context.Clientes
                .AsNoTracking()
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }
    }
}
