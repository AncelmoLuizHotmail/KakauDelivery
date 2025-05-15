using KakauDelivery.Application.Applications.Interfaces;
using KakauDelivery.Application.Interop;
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

        public async Task<ResultViewModel<ClienteViewModel>> Create(ClienteInputModel inputModel)
        {
            var cliente = inputModel.InputModelForEntity();

            await _clienteService.Create(cliente);

            return ResultViewModel<ClienteViewModel>.Success(cliente.EntityForViewModel());
        }
        public async Task<ResultViewModel> Update(int id, ClienteInputModel inputModel)
        {
            var cliente = await _clienteRepositoryReadOnly.GetById(id);
            
            if (cliente is null)
                return ResultViewModel.Error("Cliente não encontrado.");

            throw new NotImplementedException();
        }

        public async Task<ResultViewModel<IEnumerable<ClienteViewModel>>> GetAll()
        {
            var clientes = await _clienteRepositoryReadOnly.GetAll();

            return ResultViewModel<IEnumerable<ClienteViewModel>>.Success(clientes.EntityForViewModelList());
        }

        public async Task<ResultViewModel<ClienteViewModel>> GetById(int id)
        {
            var cliente = await _clienteRepositoryReadOnly.GetById(id);
            
            if (cliente is null)
                return ResultViewModel<ClienteViewModel>.Error("Cliente não encontrado.");

            return ResultViewModel<ClienteViewModel>.Success(cliente.EntityForViewModel());
        }

       
    }
}
