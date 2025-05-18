using Bogus;
using KakauDelivery.Application.Interop.Cliente;
using KakauDelivery.Application.Interop.ItemPedido;
using KakauDelivery.Application.Interop.Pedido;
using KakauDelivery.Application.Interop.Produto;
using KakauDelivery.Domain.Enums;

namespace KakauDelivery.UnitTests.Fakes
{
    public class FakeInputModelHelper
    {
        private static readonly Faker<ClienteInputModel> _clienteInputModelFaker = new Faker<ClienteInputModel>()
            .CustomInstantiator(c => new ClienteInputModel
            {
               IdUsuario = c.Random.Int(1, 100),
               Email = c.Internet.Email(),
               Nome = c.Name.FullName(),
               Telefone = c.Phone.PhoneNumber("(##) #####-####")
            });

        private static readonly Faker<ProdutoViewModel> _produtoInputModelFaker = new Faker<ProdutoViewModel>()
            .CustomInstantiator(p => new ProdutoViewModel
            {
                Id = p.Random.Int(1, 100),
                Descricao = p.Commerce.ProductName(),
                Preco = p.Random.Decimal(1, 100),
                TipoProduto = (TipoProdutoEnum)p.Random.Int(1, 2)
            });

        private static readonly Faker<PedidoInputModel> _pedidoInputModelFaker = new Faker<PedidoInputModel>()
           .CustomInstantiator(p => new PedidoInputModel
           {
               IdCliente = p.Random.Int(1, 100),
               DataPedido = p.Date.Past(1),
               Itens = CreateFakeItensPedidoInputModel()
           });

        private static readonly Faker<PedidoInputModel> _pedidoInputModelSemItensFaker = new Faker<PedidoInputModel>()
           .CustomInstantiator(p => new PedidoInputModel
           {
               IdCliente = p.Random.Int(1, 100),
               DataPedido = p.Date.Past(1),
               Itens = []
           });

        private static readonly Faker<ItemPedidoInputModel> _itemPedidoInputModelFaker = new Faker<ItemPedidoInputModel>()
            .CustomInstantiator(i => new ItemPedidoInputModel
            {
                IdProduto = i.Random.Int(1, 100),
                Quantidade = i.Random.Int(1, 10),
                Produto = CreateFakeProdutoViewModel()
            });

        public static ClienteInputModel CreateFakeClienteInpuModel() => _clienteInputModelFaker.Generate();
        public static ProdutoViewModel CreateFakeProdutoViewModel() => _produtoInputModelFaker.Generate();
        public static PedidoInputModel CreateFakePedidoInputModel() => _pedidoInputModelFaker.Generate();
        public static PedidoInputModel CreateFakePedidoInputSemItensModel() => _pedidoInputModelSemItensFaker.Generate();
        public static List<ItemPedidoInputModel> CreateFakeItensPedidoInputModel() => _itemPedidoInputModelFaker.Generate(3);
    }
}
