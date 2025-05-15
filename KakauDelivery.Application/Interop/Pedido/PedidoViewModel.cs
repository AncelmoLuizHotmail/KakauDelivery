using KakauDelivery.Application.Interop.ItemPedido;
using KakauDelivery.Domain.Enums;

namespace KakauDelivery.Application.Interop.Pedido
{
    public class PedidoViewModel
    {
        public int NumeroPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal Total { get; set; }
        public StatusPedidoEnum Status { get; set; }

        public List<ItemPedidoViewModel> Itens { get; set; }
    }
}
