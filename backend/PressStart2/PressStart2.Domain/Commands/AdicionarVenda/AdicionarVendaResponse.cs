using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.AdicionarVenda
{
    public class AdicionarVendaResponse
    {
        public Guid Id { get; }    
        public string Mensagem { get; }

        public AdicionarVendaResponse(Guid id, string mensagem) 
        {
            Id = id;
            Mensagem = mensagem;
        }
    }
}
