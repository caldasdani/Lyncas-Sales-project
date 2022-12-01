using MediatR;
using PressStart2.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.AdicionarVenda
{
    public class AdicionarVendaRequest : IRequest<CommandResponse>
    {
        public Guid ClienteId { get; set; }

        public DateTime DataFaturamento { get; set; }

        public List <VendaItemAdicionarDto> Itens { get; set; }
    }
}
