using KakauDelivery.API.Helpers;
using KakauDelivery.Application.Applications.Interfaces;
using KakauDelivery.Application.Interop.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace KakauDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteApp _clienteApp;
        public ClientesController(IClienteApp clienteApp)
        {
            _clienteApp = clienteApp;
        }

        [HttpGet("getById/{id}")]
        [AuthorizeRoles("Comprador", "Vendedor")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _clienteApp.GetById(id);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet("getAll")]
        [AuthorizeRoles("Comprador", "Vendedor")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _clienteApp.GetAll();

            return Ok(result);
        }

        [HttpPost]
        [AuthorizeRoles("Comprador", "Vendedor")]
        public async Task<IActionResult> Post(ClienteInputModel inputModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _clienteApp.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = result.Data?.Id }, result);
        }

        [HttpPut("{id}")]
        [AuthorizeRoles("Comprador", "Vendedor")]
        public async Task<IActionResult> Put(int id, ClienteInputModel cliente)
        {
            var result = await _clienteApp.Update(id, cliente);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [AuthorizeRoles("Comprador", "Vendedor")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _clienteApp.Delete(id);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}
