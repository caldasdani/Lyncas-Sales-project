using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.RemoverVenda
{
    public class RemoverVendaResponse
    {
        public string Mensagem { get; }

        public RemoverVendaResponse(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}
