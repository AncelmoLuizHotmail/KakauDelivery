using KakauDelivery.Domain.Enums;

namespace KakauDelivery.Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public Pedido() { }

        public Pedido(int idCliente, DateTime dataPedido, List<ItemPedido> itens)
        {
            IdCliente = idCliente;
            DataPedido = dataPedido;
            Itens = itens;
            Total = CalcularTotal();
        }

        public int IdCliente { get; private set; }
        public DateTime DataPedido { get; private set; }
        public decimal Total { get; private set; }
        public StatusPedidoEnum Status { get; private set; }

        public Cliente Cliente { get; private set; }
        public List<ItemPedido> Itens { get; private set; }

        public void Update(int idCliente, DateTime dataPedido, List<ItemPedido> itens)
        {
            IdCliente = idCliente;
            DataPedido = dataPedido;
            Itens = itens;
        }
        private decimal CalcularTotal() => Itens.Sum(i => i.Quantidade * i.Produto.Preco);
        public void AguardandoPagamento() => Status = StatusPedidoEnum.AguardandoPagamento;
        public void Pago() => Status = StatusPedidoEnum.Pago;
        public bool PedidoPago() => Status == StatusPedidoEnum.Pago ? true : false;

    }
}
