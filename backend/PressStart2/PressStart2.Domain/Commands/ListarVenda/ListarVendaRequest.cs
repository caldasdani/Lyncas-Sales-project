using MediatR;
using PressStart2.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.ListarVenda
{
    public class ListarVendaRequest : IRequest<CommandResponse>
    {
    }
}
