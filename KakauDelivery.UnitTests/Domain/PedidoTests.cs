using KakauDelivery.Domain.Enums;
using KakauDelivery.UnitTests.Fakes;

namespace KakauDelivery.UnitTests.Domain
{
    public class PedidoTests
    {
        [Fact]
        public void Pedido_Pago()
        {
            // Arrange
            var pedido = FakeDataHelper.CreateFakePedido();

            // Act
            pedido.Pago();

            // Assert
            Assert.Equal(StatusPedidoEnum.Pago, pedido.Status);
        }

        [Fact]
        public void Pedido_Aguardando_Pagamento()
        {
            // Arrange
            var pedido = FakeDataHelper.CreateFakePedido();

            // Act
            pedido.AguardandoPagamento();

            // Assert
            Assert.Equal(StatusPedidoEnum.AguardandoPagamento, pedido.Status);
        }
    }
}
