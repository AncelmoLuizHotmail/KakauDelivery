using KakauDelivery.Application.Applications.Interfaces;
using KakauDelivery.Application.Interop.Cliente;
using KakauDelivery.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace KakauDelivery.API.Controllers.V1
{
    [Route("api/v1/clientes")]
    public class ClientesController : MainController
    {
        private readonly IClienteApp _clienteApp;

        public ClientesController(INotifier notifier, IClienteApp clienteApp) : base(notifier)
        {
            _clienteApp = clienteApp;
        }


        [HttpGet("getById/{id}")]
        public async Task<ActionResult<ClienteViewModel>> GetById(int id)
        {
            return await _clienteApp.GetById(id);
        }

        [HttpGet("getAll")]
        public async Task<IEnumerable<ClienteViewModel>> GetAll()
        {
            return await _clienteApp.GetAll();
        }


        [HttpPost]
        public async Task<ActionResult<ClienteViewModel>> Post(ClienteInputModel inputModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            return CustomResponse(await _clienteApp.Create(inputModel));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ClienteInputModel cliente)
        {
            //chamada repository para atualizar cliente
            var crienteVM = new ClienteViewModel
            {
                Id = id,
                Email = cliente.Cep,
                Nome = cliente.Nome
            };

            return Ok(crienteVM);
        }

        //[HttpDelete("excluir/cliente/{id}")]
        //public IActionResult Delete(int id)
        //{
        //    //chamada repository para deletar cliente
        //    return NoContent();
        //}
    }
}
