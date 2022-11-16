using MediatR;
using PressStart2.Domain.DTOs;
using PressStart2.Domain.Entities;
using PressStart2.Domain.Interfaces.Repositories;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.AdicionarClente
{
    public class AdicionarClienteHandler : Notifiable, IRequestHandler<AdicionarClienteRequest, CommandResponse>
    {
        private readonly IRepositoryCliente _repositoryCliente;
        // propriedade somente leitura de um repositorio de cliente

        public AdicionarClienteHandler(IRepositoryCliente repositoryCliente)
        {
            _repositoryCliente = repositoryCliente;
        }
        public Task<CommandResponse> Handle(AdicionarClienteRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddNotification("Adicionar Cliente", "Request invalido");
                return Task.FromResult(new CommandResponse(this));
            }

            var cliente = new Cliente(request.Nome, request.Email, request.Cpf, request.Telefone);
            AddNotifications(cliente);

            if(IsInvalid()) return Task.FromResult(new CommandResponse(this));

            _repositoryCliente.Adicionar(cliente);
            _repositoryCliente.Commit();

            return Task.FromResult(new CommandResponse(
                new AdicionarClienteResponse(cliente.Id, "Cliente registrado com sucesso."), this));
        }
    }
}
