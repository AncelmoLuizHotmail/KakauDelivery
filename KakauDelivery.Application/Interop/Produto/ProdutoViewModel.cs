using KakauDelivery.Domain.Enums;

namespace KakauDelivery.Application.Interop.Produto
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public TipoProdutoEnum TipoProduto { get; set; }
    }
}
