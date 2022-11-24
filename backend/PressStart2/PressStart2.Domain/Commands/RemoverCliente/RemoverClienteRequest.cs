using MediatR;
using PressStart2.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.RemoverCliente
{
    public class RemoverClienteRequest : IRequest<CommandResponse>
    {
        public Guid Id { get; }

        public RemoverClienteRequest(Guid id) 
        {
            Id = id;
        }
    }
}
