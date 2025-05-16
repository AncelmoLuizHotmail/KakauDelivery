using KakauDelivery.Application.Interop.Produto.Mapper;

namespace KakauDelivery.Application.Interop.ItemPedido.Mapper
{
    public static class ItemPedidoMap
    {
        public static Domain.Entities.ItemPedido InputModelForEntity(this ItemPedidoInputModel inputModel)
        {
            return new Domain.Entities.ItemPedido(inputModel.IdPedido, inputModel.IdProduto, inputModel.Quantidade);
        }

        public static ItemPedidoViewModel EntityForViewModel(this Domain.Entities.ItemPedido entity)
        {
            return new ItemPedidoViewModel()
            {
                IdProduto = entity.IdProduto,
                Quantidade = entity.Quantidade,
                Produto = entity.Produto.EntityForViewModel()
            };
        }

        public static IEnumerable<ItemPedidoViewModel> EntityForViewModelList(this IEnumerable<Domain.Entities.ItemPedido> entityList)
        {
            return (from entity in entityList
                    select new ItemPedidoViewModel
                    {
                        IdProduto = entity.IdProduto,
                        Quantidade = entity.Quantidade,
                        Produto = entity.Produto.EntityForViewModel()
                    })
                    .ToList();
        }

        public static IEnumerable<Domain.Entities.ItemPedido> ViewModelForEntityList(this IEnumerable<ItemPedidoViewModel> viewModelList)
        {
            return (from viewModel in viewModelList
                    select new Domain.Entities.ItemPedido(viewModel.IdPedido, viewModel.IdProduto, viewModel.Quantidade)).ToList();
        }
    }
}
