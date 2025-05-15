using KakauDelivery.Domain.Enums;

namespace KakauDelivery.Domain.Entities
{
    public class Produto : BaseEntity
    {
        public Produto() { }
        public Produto(string descricao, decimal preco, TipoProdutoEnum tipoProduto)
        {
            Descricao = descricao;
            Preco = preco;
            TipoProduto = tipoProduto;
            ItensPedido = [];
        }

        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public TipoProdutoEnum TipoProduto { get; private set; }

        public List<ItemPedido> ItensPedido { get; private set; }
    }
}
