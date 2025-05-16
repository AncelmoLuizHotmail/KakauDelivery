using KakauDelivery.Application.Services.Interfaces;
using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakauDelivery.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task Create(Pedido entity)
        {
            await _pedidoRepository.Create(entity);
        }

        public Task Delete(Pedido entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Pedido entity)
        {
            throw new NotImplementedException();
        }
    }
}
