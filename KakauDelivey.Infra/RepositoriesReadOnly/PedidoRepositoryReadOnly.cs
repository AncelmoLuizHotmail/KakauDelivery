﻿using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Enums;
using KakauDelivery.Domain.Repositories.RepositoryReadOnly;
using KakauDelivey.Infra.KakauDeliveryContext;
using Microsoft.EntityFrameworkCore;

namespace KakauDelivey.Infra.RepositoriesReadOnly
{
    public class PedidoRepositoryReadOnly : RepositoryReadOnly<Pedido>, IPedidoRepositoryReadOnly
    {
        public PedidoRepositoryReadOnly(KakauDeliveryDbContext context) : base(context)
        {
        }

        public override async Task<Pedido?> GetById(int id)
        {
            return await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Itens)
                    .ThenInclude(ip => ip.Produto)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Pedido?> GetPedidoByCliente(int idPedido, int idCliente)
        {
            return await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Itens)
                    .ThenInclude(ip => ip.Produto)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.IdCliente == idCliente && p.Id == idPedido && !p.IsDeleted);
        }

        public async Task<IEnumerable<Pedido>?> GetPedidoByDataOrStatus(DateTime data, StatusPedidoEnum status)
        {
            var pedidos = await _context.Pedidos
                .AsNoTracking()
                .Include(p => p.Cliente)
                .Include(p => p.Itens)
                    .ThenInclude(ip => ip.Produto)
                .Where(x => x.DataCreate.Date == data.Date && x.Status == status && !x.IsDeleted)
                .ToListAsync();

            return pedidos;
        }
    }
}
