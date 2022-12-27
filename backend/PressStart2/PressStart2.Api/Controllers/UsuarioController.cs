using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PressStart2.Domain.Commands.AdicionarUsuario;
using PressStart2.Domain.Commands.ListarCliente;
using PressStart2.Domain.Commands.LoginUsuario;
using PressStart2.Domain.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PressStart2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public UsuarioController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpGet("autenticar")]
        public async Task<IActionResult> Autenticar([FromQuery] string login, [FromQuery] string senha)
        {
            var commandResponse = await _mediator.Send(new LoginUsuarioRequest(login, senha));

            if (!commandResponse.Sucesso)
                return BadRequest(commandResponse);

            var usuario = (LoginUsuarioResponse)commandResponse.Dados;

            var claims = new[]
            {
                new Claim("usuarioId", usuario.Id.ToString()),
                new Claim("nomeUsuario", usuario.Nome)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "PressStart2",
                audience: "PressStart2",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            return Ok(new
            {
                NomeUsuario = usuario.Nome,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            });

        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> Adicionar(AdicionarUsuarioRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.Sucesso)
                return Created("Usuario Adicionado", response);

            return BadRequest(response);
        }
    }
}
