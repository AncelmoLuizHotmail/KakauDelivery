using KakauDelivery.Application.Interop.Produto;

namespace KakauDelivery.Application.Interop.ItemPedido
{
    public class ItemPedidoInputModel
    {
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }

        public ProdutoInputModel Produto { get; set; }
    }
}
