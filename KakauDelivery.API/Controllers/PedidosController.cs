using KakauDelivery.API.Helpers;
using KakauDelivery.Application.Applications.Interfaces;
using KakauDelivery.Application.Interop.Pedido;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KakauDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoApp _pedidoApp;
        public PedidosController(IPedidoApp pedidoApp)
        {
            _pedidoApp = pedidoApp;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Vendedor")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _pedidoApp.GetById(id);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("getAll")]
        [Authorize(Roles = "Vendedor")]
        public async Task<IActionResult> GetAll([FromBody]PedidoFilter filter)
        {
            var result = await _pedidoApp.GetAll(filter);

            return Ok(result);
        }

        [Authorize(Roles = "Comprador")]
        [HttpGet("idPedido/{idPedido}/idCliente/{idCliente}")]
        public async Task<IActionResult> GetPedidoByCliente(int idPedido, int idCliente)
        {
            var result = await _pedidoApp.GetPedidoByCliente(idPedido, idCliente);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost]
        [AuthorizeRoles("Comprador", "Vendedor")]
        public async Task<IActionResult> Post(PedidoInputModel inputModel)
        {
            var result = await _pedidoApp.Create(inputModel);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [AuthorizeRoles("Comprador", "Vendedor")]
        public async Task<IActionResult> Put(int id, PedidoInputModel cliente)
        {
            var result = await _pedidoApp.Update(id, cliente);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }


        [HttpDelete("logical/{id}")]
        [AuthorizeRoles("Comprador", "Vendedor")]
        public async Task<IActionResult> DeleteLogical(int id)
        {
            var result = await _pedidoApp.DeleteLogical(id);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [AuthorizeRoles("Comprador", "Vendedor")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _pedidoApp.Delete(id);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }

        [Authorize(Roles = "Vendedor")]
        [HttpPost("pagarPedido")]
        public async Task<IActionResult> PagarPedido(PedidoPagarInputModel inputModel)
        {
            var result = await _pedidoApp.PagarPedido(inputModel);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

    }
}
