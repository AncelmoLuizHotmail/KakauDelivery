using KakauDelivery.Application.Interop.ItemPedido;
using KakauDelivery.Domain.Enums;

namespace KakauDelivery.Application.Interop.Pedido
{
    public class PedidoInputModel
    {
        public int IdCliente { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.Now;
        public StatusPedidoEnum Status { get; set; }

        public List<ItemPedidoInputModel> Itens { get; set; }
    }
}
