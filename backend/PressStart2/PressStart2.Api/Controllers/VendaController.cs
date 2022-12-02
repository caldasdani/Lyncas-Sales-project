using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PressStart2.Domain.Commands.AdicionarCliente;
using PressStart2.Domain.Commands.AdicionarVenda;
using PressStart2.Domain.Commands.ListarCliente;
using PressStart2.Domain.Commands.ListarVenda;

namespace PressStart2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VendaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> Adicionar(AdicionarVendaRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.Sucesso)
                return Created("Venda Adicionada", response);

            return BadRequest(response);
        }


        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var listaVendas = await _mediator.Send(new ListarVendaRequest());
            return Ok(listaVendas);
        }
    }
}