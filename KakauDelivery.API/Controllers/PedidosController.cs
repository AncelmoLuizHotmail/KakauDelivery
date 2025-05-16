using KakauDelivery.Application.Applications.Interfaces;
using KakauDelivery.Application.Interop.Pedido;
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

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _pedidoApp.GetById(id);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet("idPedido/{idPedido}/idCliente/{idCliente}")]
        public async Task<IActionResult> GetPedidoByCliente(int idPedido, int idCliente)
        {
            var result = await _pedidoApp.GetPedidoByCliente(idPedido, idCliente);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PedidoInputModel inputModel)
        {
            var result = await _pedidoApp.Create(inputModel);
            
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetById), new { id = result.Data?.NumeroPedido }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PedidoInputModel cliente)
        {
            var result = await _pedidoApp.Update(id, cliente);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _pedidoApp.Delete(id);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}
