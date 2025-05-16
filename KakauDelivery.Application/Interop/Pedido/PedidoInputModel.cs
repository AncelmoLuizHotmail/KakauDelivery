using KakauDelivery.Application.Interop.ItemPedido;

namespace KakauDelivery.Application.Interop.Pedido
{
    public class PedidoInputModel
    {
        public int IdCliente { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.Now;

        public List<ItemPedidoInputModel> Itens { get; set; }
    }
}
