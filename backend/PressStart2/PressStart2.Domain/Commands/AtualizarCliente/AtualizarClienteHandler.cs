using MediatR;
using PressStart2.Domain.Commands.ListarCliente;
using PressStart2.Domain.DTOs;
using PressStart2.Domain.Interfaces.Repositories;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.AtualizarCliente
{
    public class AtualizarClienteHandler : Notifiable, IRequestHandler <AtualizarClienteRequest, CommandResponse>
    {
        private readonly IRepositoryCliente _repositoryCliente;

        public AtualizarClienteHandler(IRepositoryCliente repositoryCliente)
        {
            _repositoryCliente = repositoryCliente;
        }

        public Task<CommandResponse> Handle(AtualizarClienteRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddNotification("AtualizarClienteHandler", "Request invalido");
                return Task.FromResult(new CommandResponse (this));
            }

            var cliente = _repositoryCliente.Obter(request.Id);

            if (cliente == null)
            {
                AddNotification("AtualizarClienteHandler", "Cliente não localizado");
                return Task.FromResult(new CommandResponse(this));
            }
            cliente.Atualizar(request.Nome, request.Email, request.Cpf, request.Telefone);

            _repositoryCliente.Atualizar(cliente);
            _repositoryCliente.Commit();

            return Task.FromResult(new CommandResponse (
                new AtualizarClienteResponse("cliente atualizado com sucesso"),this));
        }
    }


}
