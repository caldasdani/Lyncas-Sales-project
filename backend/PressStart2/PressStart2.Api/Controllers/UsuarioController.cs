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
        [HttpPost("autenticar")]
        public async Task<IActionResult> Autenticar(LoginUsuarioRequest request)
        {
            var commandResponse = await _mediator.Send(request);

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

            var dadosAutenticados = new
            {
               Sucesso = true,
               Dados = new
               {
                    NomeUsuario = usuario.Nome,
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
               }
            };
            return Ok(dadosAutenticados);
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
