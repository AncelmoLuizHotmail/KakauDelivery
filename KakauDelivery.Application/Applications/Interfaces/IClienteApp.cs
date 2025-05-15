using KakauDelivery.Application.Interop;
using KakauDelivery.Application.Interop.Cliente;

namespace KakauDelivery.Application.Applications.Interfaces
{
    public interface IClienteApp
    {
        Task<ResultViewModel<ClienteViewModel>> Create(ClienteInputModel inputModel);
        Task<ResultViewModel> Update(int id, ClienteInputModel inputModel);
        Task<ResultViewModel<ClienteViewModel>> GetById(int id);
        Task<ResultViewModel<IEnumerable<ClienteViewModel>>> GetAll();
        Task<ResultViewModel> Delete(int id);

    }
}
