using KakauDelivery.Application.Interop.Cliente;

namespace KakauDelivery.Application.Applications.Interfaces
{
    public interface IClienteApp
    {
        Task<ClienteViewModel> Create(ClienteInputModel inputModel);
        Task<ClienteViewModel> GetById(int id);
        Task<IEnumerable<ClienteViewModel>> GetAll();

    }
}
