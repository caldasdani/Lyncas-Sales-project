using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PressStart2.Domain.DTOs;

namespace PressStart2.Domain.Commands.ObterVenda
{
    public class ObterVendaRequest : IRequest<CommandResponse>
    {
        public Guid Id { get; set; }

        public ObterVendaRequest(Guid id) 
        {
            Id = id;
        }
    }
}
