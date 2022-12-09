using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.AtualizarVenda
{
    public class AtualizarVendaResponse
    {
        public string Mensagem { get; }

        public AtualizarVendaResponse(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}
