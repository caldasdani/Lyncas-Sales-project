using MediatR;
using PressStart2.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.AtualizarCliente
{
    public class AtualizarClienteRequest : IRequest<CommandResponse>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set;}
        public string Telefone { get; set; } 
    }
}
