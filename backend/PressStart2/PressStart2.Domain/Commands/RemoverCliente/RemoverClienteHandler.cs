using MediatR;
using PressStart2.Domain.Commands.AtualizarCliente;
using PressStart2.Domain.DTOs;
using PressStart2.Domain.Interfaces.Repositories;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.RemoverCliente
{
    public class RemoverClienteHandler : Notifiable, IRequestHandler<AtualizarClienteRequest, CommandResponse>
    {
        private readonly IRepositoryCliente _repositoryCliente;

        public RemoverClienteHandler(IRepositoryCliente repositoryCliente) 
        {
            _repositoryCliente = repositoryCliente;
        }

        public Task<CommandResponse> Handle(AtualizarClienteRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddNotification("RemoverClienteHandler", "Request invalido");
                return Task.FromResult(new CommandResponse(this));
            }

            var cliente = _repositoryCliente.Obter(request.Id);

            if (cliente is null)
            {
                AddNotification("RemoverClienteHandler", "Cliente não localizado");
                return Task.FromResult(new CommandResponse(this));
            }

            _repositoryCliente.Remover(cliente);
            _repositoryCliente.Commit();

            return Task.FromResult(new CommandResponse(
                new RemoverClienteResponse("cliente removido com sucesso"), this));
        }
    }
}
