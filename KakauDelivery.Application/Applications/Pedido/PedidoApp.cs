using KakauDelivery.Application.Applications.Interfaces;
using KakauDelivery.Application.Interop;
using KakauDelivery.Application.Interop.ItemPedido.Mapper;
using KakauDelivery.Application.Interop.Pedido;
using KakauDelivery.Application.Interop.Pedido.Mapper;
using KakauDelivery.Application.Services.Interfaces;
using KakauDelivery.Domain.Repositories.RepositoryReadOnly;

namespace KakauDelivery.Application.Applications.Pedido
{
    public class PedidoApp : IPedidoApp
    {
        private readonly IPedidoService _pedidoService;
        private readonly IPedidoRepositoryReadOnly _pedidoRepositoryReadOnly;

        public PedidoApp(IPedidoService pedidoService,
            IPedidoRepositoryReadOnly pedidoRepositoryReadOnly)
        {
            _pedidoService = pedidoService;
            _pedidoRepositoryReadOnly = pedidoRepositoryReadOnly;
        }

        public async Task<ResultViewModel<PedidoViewModel>> Create(PedidoInputModel inputModel)
        {
            if (inputModel.Itens.Count() == 0)
                return ResultViewModel<PedidoViewModel>.Error("Pedito sem itens.");

            var pedido = inputModel.InputModelForEntity();
            
            pedido.AguardandoPagamento();

            await _pedidoService.Create(pedido);

            return ResultViewModel<PedidoViewModel>.Success(pedido.EntityForViewModel());
        }

        public async Task<ResultViewModel> Delete(int id)
        {
            var pedido = await _pedidoRepositoryReadOnly.GetById(id);

            if (pedido is null)
                return ResultViewModel.Error("Pedido não encontrado.");

            if (pedido.PedidoPago())
                return ResultViewModel.Error("O Pedido já está Pago. Não pode ser excluído");

            pedido.SetAsDeleted();
            pedido.SetAsDateUpdate();

            await _pedidoService.Delete(pedido);

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel<PedidoViewModel>> GetById(int id)
        {
            var pedido = await _pedidoRepositoryReadOnly.GetById(id);

            if (pedido is null)
                return ResultViewModel<PedidoViewModel>.Error("Pedido não encontrado.");

            return ResultViewModel<PedidoViewModel>.Success(pedido.EntityForViewModel());
        }

        public async Task<ResultViewModel<PedidoViewModel>> GetPedidoByCliente(int idPedido, int idCliente)
        {
            var pedido = await _pedidoRepositoryReadOnly.GetPedidoByCliente(idPedido, idCliente);

            if (pedido is null)
                return ResultViewModel<PedidoViewModel>.Error("Pedido não encontrado.");

            return ResultViewModel<PedidoViewModel>.Success(pedido.EntityForViewModel());
        }

        public async Task<ResultViewModel> Update(int id, PedidoInputModel inputModel)
        {
            if (inputModel.Itens.Count() == 0)
                return ResultViewModel<PedidoViewModel>.Error("Pedito sem itens.");

            var pedido = await _pedidoRepositoryReadOnly.GetById(id);

            if (pedido is null)
                return ResultViewModel.Error("Pedido não encontrado.");

            var itens = inputModel.Itens.Select(x => x.InputModelForEntity()).ToList();

            pedido.Update(inputModel.IdCliente, inputModel.DataPedido, itens);
            pedido.SetAsDateUpdate();

            await _pedidoService.Update(pedido);

            return ResultViewModel<PedidoViewModel>.Success();
        }
    }
}
