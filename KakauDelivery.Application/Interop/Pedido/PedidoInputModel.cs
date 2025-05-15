using KakauDelivery.Domain.Enums;

namespace KakauDelivery.Application.Interop.Pedido
{
    public class PedidoInputModel
    {
        public int IdCliente { get; set; }
        public DateTime DataPedido { get; set; }
        public StatusPedidoEnum Status { get; set; }
    }
}
