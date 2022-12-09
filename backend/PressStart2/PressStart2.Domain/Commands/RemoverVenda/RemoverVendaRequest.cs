using MediatR;
using PressStart2.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.RemoverVenda
{
    public class RemoverVendaRequest : IRequest<CommandResponse>
    {
        public Guid Id { get; }

        public RemoverVendaRequest(Guid id)
        {
            Id = id;
        }
    }   
 }

