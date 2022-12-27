using MediatR;
using PressStart2.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.AdicionarUsuario
{
    public class AdicionarUsuarioRequest : IRequest<CommandResponse>
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set;}
        public string Nome { get; set; }
    }
}
