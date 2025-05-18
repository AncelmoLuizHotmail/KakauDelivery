using KakauDelivery.Application.Applications.Pedido;
using KakauDelivery.Application.Interop.Pedido.Mapper;
using KakauDelivery.Application.Services.Interfaces;
using KakauDelivery.Domain.Entities;
using KakauDelivery.Domain.Repositories.RepositoryReadOnly;
using KakauDelivery.UnitTests.Fakes;
using Moq;

namespace KakauDelivery.UnitTests.Application
{
    public class PedidoAppTests
    {
        [Fact]
        public async Task Pedido_Create_Success()
        {
            // Arrange
            var inputModel = FakeInputModelHelper.CreateFakePedidoInputModel();

            var pedidoCriado = FakeDataHelper.CreateFakePedido();
            var pedidoViewModel = pedidoCriado.EntityForViewModel();

            var pedidoServiceMock = new Mock<IPedidoService>();
            pedidoServiceMock.Setup(s => s.Create(It.IsAny<Pedido>()))
                             .Returns(Task.CompletedTask)
                             .Verifiable();

            var pedidoRepositoryMock = new Mock<IPedidoRepositoryReadOnly>();
            pedidoRepositoryMock.Setup(r => r.GetById(It.IsAny<int>()))
                                .ReturnsAsync(pedidoCriado)
                                .Verifiable();

            var pedidoApp = new PedidoApp(
                pedidoServiceMock.Object,
                pedidoRepositoryMock.Object);

            // Act
            var result = await pedidoApp.Create(inputModel);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Data);
            Assert.Equal(pedidoViewModel.DataPedido, result.Data.DataPedido);
            Assert.Equal(pedidoViewModel.NumeroPedido, result.Data.NumeroPedido);
            Assert.Equal(pedidoViewModel.Status, result.Data.Status);
            Assert.Equal(pedidoViewModel.Total, result.Data.Total);
            Assert.Equal(pedidoViewModel.Itens.Count, result.Data.Itens.Count);
            for (int i = 0; i < pedidoViewModel.Itens.Count; i++)
            {
                Assert.Equal(pedidoViewModel.Itens[i].IdProduto, result.Data.Itens[i].IdProduto);
                Assert.Equal(pedidoViewModel.Itens[i].Quantidade, result.Data.Itens[i].Quantidade);
            }

            pedidoServiceMock.Verify();
            pedidoRepositoryMock.Verify();
        }

        [Fact]
        public async Task Pedido_Create_Error_Sem_Itens()
        {
            // Arrange
            var inputModel = FakeInputModelHelper.CreateFakePedidoInputSemItensModel();

            var pedidoServiceMock = new Mock<IPedidoService>();
            var pedidoRepositoryMock = new Mock<IPedidoRepositoryReadOnly>();

            var pedidoApp = new PedidoApp(
                pedidoServiceMock.Object,
                pedidoRepositoryMock.Object);

            // Act
            var result = await pedidoApp.Create(inputModel);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Pedito sem itens.", result.Message);
            Assert.Null(result.Data);
        }

        [Fact]
        public async Task DeleteLogical_Return_Success_Pedido_AguardandoPagamento()
        {
            // Arrange
            var pedidoId = 1;
            var pedidoNaoPago = FakeDataHelper.CreateFakePedido();
            pedidoNaoPago.AguardandoPagamento();

            var pedidoRepositoryMock = new Mock<IPedidoRepositoryReadOnly>();
            pedidoRepositoryMock.Setup(r => r.GetById(pedidoId))
                               .ReturnsAsync(pedidoNaoPago);

            var pedidoServiceMock = new Mock<IPedidoService>();
            pedidoServiceMock.Setup(s => s.DeleteLogical(It.IsAny<Pedido>()))
                             .Returns(Task.CompletedTask);

            var pedidoApp = new PedidoApp(pedidoServiceMock.Object, pedidoRepositoryMock.Object);

            // Act
            var result = await pedidoApp.DeleteLogical(pedidoId);

            // Assert
            Assert.True(result.IsSuccess);
            pedidoRepositoryMock.Verify(r => r.GetById(pedidoId), Times.Once);
            pedidoServiceMock.Verify(s => s.DeleteLogical(It.Is<Pedido>(p =>
                p.IsDeleted && p.Itens.All(i => i.IsDeleted))), Times.Once);
        }

        [Fact]
        public async Task DeleteLogical_Return_Error_PedidoPago()
        {
            // Arrange
            var pedidoId = 2;
            var pedidoPago = FakeDataHelper.CreateFakePedido();
            pedidoPago.Pago();

            var pedidoRepositoryMock = new Mock<IPedidoRepositoryReadOnly>();
            pedidoRepositoryMock.Setup(r => r.GetById(pedidoId))
                               .ReturnsAsync(pedidoPago);

            var pedidoServiceMock = new Mock<IPedidoService>();

            var pedidoApp = new PedidoApp(pedidoServiceMock.Object, pedidoRepositoryMock.Object);

            // Act
            var result = await pedidoApp.DeleteLogical(pedidoId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("O Pedido já está Pago. Não pode ser excluído", result.Message);
            pedidoRepositoryMock.Verify(r => r.GetById(pedidoId), Times.Once);
            pedidoServiceMock.Verify(s => s.DeleteLogical(It.IsAny<Pedido>()), Times.Never);
        }

        [Fact]
        public async Task Update_Return_Success()
        {
            // Arrange
            var pedidoId = 1;
            var inputModel = FakeInputModelHelper.CreateFakePedidoInputModel();
            var pedidoExistente = FakeDataHelper.CreateFakePedido();

            var pedidoRepositoryMock = new Mock<IPedidoRepositoryReadOnly>();
            pedidoRepositoryMock.Setup(r => r.GetById(pedidoId))
                               .ReturnsAsync(pedidoExistente);

            var pedidoServiceMock = new Mock<IPedidoService>();
            pedidoServiceMock.Setup(s => s.Update(It.IsAny<Pedido>()))
                             .Returns(Task.CompletedTask);

            var pedidoApp = new PedidoApp(pedidoServiceMock.Object, pedidoRepositoryMock.Object);

            // Act
            var result = await pedidoApp.Update(pedidoId, inputModel);

            // Assert
            Assert.True(result.IsSuccess);

        }

        [Fact]
        public async Task Update_Return_Error_Sem_Itens()
        {
            // Arrange
            var pedidoId = 1;
            var inputModel = FakeInputModelHelper.CreateFakePedidoInputSemItensModel();

            var pedidoRepositoryMock = new Mock<IPedidoRepositoryReadOnly>();
            var pedidoServiceMock = new Mock<IPedidoService>();

            var pedidoApp = new PedidoApp(
                pedidoServiceMock.Object,
                pedidoRepositoryMock.Object);

            // Act
            var result = await pedidoApp.Update(pedidoId, inputModel);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Pedito sem itens.", result.Message);
            pedidoRepositoryMock.Verify(r => r.GetById(It.IsAny<int>()), Times.Never);
            pedidoServiceMock.Verify(s => s.Update(It.IsAny<Pedido>()), Times.Never);
        }

    }
}
