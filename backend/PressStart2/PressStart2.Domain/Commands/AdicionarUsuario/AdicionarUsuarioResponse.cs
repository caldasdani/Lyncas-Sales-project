using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.AdicionarUsuario
{
    public class AdicionarUsuarioResponse
    {
        public Guid Id { get; set; }
        public string Mensagem { get; set; }

        public AdicionarUsuarioResponse(Guid id, string mensagem)
        {
            Id = id;
            Mensagem = mensagem;
        }

    }
}
