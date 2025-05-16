using KakauDelivery.Application.Interop.Produto;

namespace KakauDelivery.Application.Interop.ItemPedido
{
    public class ItemPedidoViewModel
    {
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public ProdutoViewModel Produto { get; set; }
    }
}
