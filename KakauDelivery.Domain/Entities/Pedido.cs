using KakauDelivery.Domain.Enums;

namespace KakauDelivery.Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public Pedido() { }

        public Pedido(int idCliente, DateTime dataPedido, StatusPedidoEnum status)
        {
            IdCliente = idCliente;
            DataPedido = dataPedido;
            Total = CalcularTotal();
            Status = status;
            Itens = [];
        }

        public int IdCliente { get; private set; }
        public DateTime DataPedido { get; private set; }
        public decimal Total { get; private set; }
        public StatusPedidoEnum Status { get; private set; }

        public Cliente Cliente { get; private set; }
        public List<ItemPedido> Itens { get; private set; }

        private decimal CalcularTotal()
        {
            return Itens.Sum(i => i.Quantidade * i.Produto.Preco);
        }
    }
}
