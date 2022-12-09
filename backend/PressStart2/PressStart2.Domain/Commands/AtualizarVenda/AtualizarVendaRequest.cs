using MediatR;
using PressStart2.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.AtualizarVenda
{
    public class AtualizarVendaRequest : IRequest<CommandResponse>
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime DataFaturamento { get; set; }
        public List<VendaItemAdicionarDto> Itens { get; set; }
    }
}
