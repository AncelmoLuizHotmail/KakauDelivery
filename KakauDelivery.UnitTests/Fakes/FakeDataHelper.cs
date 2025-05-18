using Bogus;
using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Enums;

namespace KakauDelivery.UnitTests.Fakes
{
    public class FakeDataHelper
    {
        private static readonly Faker _fake = new Faker("pt_BR");

        private static readonly Faker<Cliente> _clienteFaker = new Faker<Cliente>()
            .CustomInstantiator(c => new Cliente(
                c.Random.Int(1, 100),
                c.Name.FullName(),
                c.Internet.Email(),
                c.Phone.PhoneNumber("(##) #####-####")
            ));

        private static readonly Faker<Produto> _produtoFaker = new Faker<Produto>()
            .CustomInstantiator(p => new Produto(
                p.Commerce.ProductName(),
                p.Random.Decimal(1, 100),
                (TipoProdutoEnum)p.Random.Int(1, 2)
            ));

        private static readonly Faker<Pedido> _pedidoFaker = new Faker<Pedido>()
           .CustomInstantiator(p => new Pedido(
               p.Random.Int(1, 100),
               p.Date.Past(1),
                CreateFakeItensPedido()
           ));

        private static readonly Faker<ItemPedido> _itemPedidoFaker = new Faker<ItemPedido>()
            .CustomInstantiator(i => new ItemPedido(
                i.Random.Int(1, 100),
                i.Random.Int(1, 10),
                CreateFakeProduto()
            ));

        public static Cliente CreateFakeCliente() => _clienteFaker.Generate();
        public static Produto CreateFakeProduto() => _produtoFaker.Generate();
        public static Pedido CreateFakePedido() => _pedidoFaker.Generate();
        public static List<ItemPedido> CreateFakeItensPedido() => _itemPedidoFaker.Generate(3);
    }
}
