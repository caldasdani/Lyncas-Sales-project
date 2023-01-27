using Microsoft.AspNetCore.Mvc;
using MediatR;
using PressStart2.Domain.Commands.ListarCliente;
using PressStart2.Domain.Commands.AdicionarCliente;
using PressStart2.Domain.Commands.ObterCliente;
using PressStart2.Domain.Commands.RemoverCliente;
using PressStart2.Domain.Commands.AtualizarCliente;
using Microsoft.AspNetCore.Authorization;
using prmToolkit.NotificationPattern;

namespace PressStart2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("adicionar")]
        public async Task<IActionResult> Adicionar(AdicionarClienteRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.Sucesso)
                return Created("Cliente Adicionado", response);

            return BadRequest(response);
        }


        [ProducesResponseType(typeof(ListarClienteResponse), 200)]
        [HttpGet("listar")]
        public async Task<IActionResult> Listar([FromQuery] ListarClienteRequest request)
        {
            var listaClientes = await _mediator.Send(request);
            return Ok(listaClientes);
        }

        [HttpGet("obter/{id}")]
        public async Task<IActionResult> Obter(Guid id)
        {
            var cliente = await _mediator.Send(new ObterClienteRequest(id));
            return Ok(cliente);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> Atualizar(AtualizarClienteRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.Sucesso)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }



        [HttpDelete("remover")]
        public async Task<IActionResult> Deletar(RemoverClienteRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.Sucesso)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }


    }
}
