using KakauDelivery.Application.Interop;
using KakauDelivery.Application.Interop.Pedido;

namespace KakauDelivery.Application.Applications.Interfaces
{
    public interface IPedidoApp
    {
        Task<ResultViewModel<PedidoViewModel>> GetPedidoByCliente(int idPedido, int idCliente);
        Task<ResultViewModel<PedidoViewModel>> GetById(int id);
        Task<ResultViewModel<PedidoViewModel>> Create(PedidoInputModel inputModel);
        Task<ResultViewModel> Update(int id, PedidoInputModel inputModel);
        Task<ResultViewModel> Delete(int id);
    }
}
