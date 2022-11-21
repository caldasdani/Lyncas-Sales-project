using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.AdicionarCliente
{
    public class AdicionarClienteResponse
    {
        public Guid Id { get; }
        public string Mensagem { get; }
        public AdicionarClienteResponse (Guid id, string mensagem)
        {
            Id = id;
            Mensagem = mensagem;
        }
    }
}
