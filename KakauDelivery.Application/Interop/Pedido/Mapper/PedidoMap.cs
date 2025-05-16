using KakauDelivery.Application.Interop.Cliente;
using KakauDelivery.Application.Interop.ItemPedido;
using KakauDelivery.Application.Interop.ItemPedido.Mapper;
using KakauDelivery.Application.Interop.Produto.Mapper;

namespace KakauDelivery.Application.Interop.Pedido.Mapper
{
    public static class PedidoMap
    {
        public static Domain.Entities.Pedido InputModelForEntity(this PedidoInputModel inputModel)
        {
            var itens = inputModel.Itens
                .Select(i => new Domain.Entities.ItemPedido(i.Produto.ViewModelForEntity(), i.Quantidade))
                .ToList();

            return new Domain.Entities.Pedido(inputModel.IdCliente, inputModel.DataPedido, itens);
        }

        public static PedidoViewModel EntityForViewModel(this Domain.Entities.Pedido entity)
        {
            return new PedidoViewModel()
            {
                NumeroPedido = entity.Id,
                DataPedido = entity.DataPedido,
                Total = entity.Total,
                Itens = entity.Itens.EntityForViewModelList()
            };
        }

        public static IEnumerable<PedidoViewModel> EntityForViewModelList(this IEnumerable<Domain.Entities.Pedido> entityList)
        {
            return (from entity in entityList
                    select new PedidoViewModel
                    {
                        NumeroPedido = entity.Id,
                        DataPedido = entity.DataPedido,
                        Total = entity.Total,
                        Status = entity.Status,
                        Itens = entity.Itens.EntityForViewModelList()
                    }).ToList();
        }
    }
}
