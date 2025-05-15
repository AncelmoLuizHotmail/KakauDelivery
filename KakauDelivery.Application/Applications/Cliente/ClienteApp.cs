using KakauDelivery.Application.Applications.Interfaces;
using KakauDelivery.Application.Interop.Cliente;
using KakauDelivery.Application.Interop.Cliente.Mapper;
using KakauDelivery.Application.Services.Interfaces;
using KakauDelivery.Domain.Repositories.RepositoryReadOnly;

namespace KakauDelivery.Application.Applications.Cliente
{
    public class ClienteApp : IClienteApp
    {
        private readonly IClienteService _clienteService;
        private readonly IClienteRepositoryReadOnly _clienteRepositoryReadOnly;

        public ClienteApp(IClienteService clienteService,
            IClienteRepositoryReadOnly clienteRepositoryReadOnly)
        {
            _clienteService = clienteService;
            _clienteRepositoryReadOnly = clienteRepositoryReadOnly;
        }

        public async Task<ClienteViewModel> Create(ClienteInputModel inputModel)
        {
            var cliente = inputModel.InputModelForEntity();
            await _clienteService.Create(cliente);

            return cliente.EntityForViewModel();
        }

        public async Task<IEnumerable<ClienteViewModel>> GetAll()
        {
            var clientes = await _clienteRepositoryReadOnly.GetAll();

            return clientes.EntityForViewModelList();
        }

        public async Task<ClienteViewModel> GetById(int id)
        {
            var cliente = await _clienteRepositoryReadOnly.GetById(id);
            if (cliente is null)
                return null;

            return cliente.EntityForViewModel();
        }
    }
}
