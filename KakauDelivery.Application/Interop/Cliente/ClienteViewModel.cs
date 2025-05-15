using KakauDelivery.Application.Interop.Pedido;

namespace KakauDelivery.Application.Interop.Cliente
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public List<PedidoViewModel> Pedidos { get; set; }
    }
}
