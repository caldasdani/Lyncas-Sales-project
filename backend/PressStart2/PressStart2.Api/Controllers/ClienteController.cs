using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using PressStart2.Domain.Commands;
using PressStart2.Domain.Commands.ListarCliente;
using PressStart2.Domain.Commands.AdicionarCliente;
using PressStart2.Domain.Commands.ObterCliente;

namespace PressStart2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Listar")]

        public async Task<IActionResult> Listar()
        {
            var listaClientes = await _mediator.Send(new ListarClienteRequest());
                return Ok(listaClientes);
        }

        [HttpGet("Obter/{id}")]
        public async Task<IActionResult> Obter(Guid id)
        {
            var cliente = await _mediator.Send(new ObterClienteRequest(id));
            return Ok(cliente);
        }

        [HttpPost("Adicionar}")]
        public async Task<IActionResult> Adicionar(AdicionarClienteRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.Sucesso)
                return Created("Cliente Adicionado", response);

            return BadRequest(response);
        }

    }
}
