using KakauDelivery.Domain.Enums;

namespace KakauDelivery.Application.Interop.Produto
{
    public class ProdutoInputModel
    {
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public TipoProdutoEnum TipoProduto { get; set; }
    }
}
