namespace KakauDelivery.Domain.Entities
{
    public class ItemPedido : BaseEntity
    {
        public ItemPedido() { }

        public ItemPedido(int idPedido, int idProduto, int quantidade)
        {
            IdPedido = idPedido;
            IdProduto = idProduto;
            Quantidade = quantidade;
        }
        public int IdPedido { get; private set; }
        public int IdProduto { get; private set; }
        public int Quantidade { get; private set; }

        public Pedido Pedido { get; private set; }
        public Produto Produto { get; private set; }
    }
}
