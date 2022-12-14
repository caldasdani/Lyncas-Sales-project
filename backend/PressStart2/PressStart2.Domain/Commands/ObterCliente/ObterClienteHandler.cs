using MediatR;
using PressStart2.Domain.Interfaces.Repositories;
using prmToolkit.NotificationPattern;
using PressStart2.Domain.DTOs;


namespace PressStart2.Domain.Commands.ObterCliente
{
    public class ObterClienteHandler : Notifiable, IRequestHandler<ObterClienteRequest, CommandResponse>
    {
        private readonly IRepositoryCliente _repositoryCliente;
        public ObterClienteHandler(IRepositoryCliente repositoryCliente) 
        {
            _repositoryCliente = repositoryCliente;
        }
        public Task<CommandResponse> Handle(ObterClienteRequest request, CancellationToken cancellationToken)
        {
           if (request is null)
            {
                AddNotification("ObterClienteHandler", "Request invalido");
                return Task.FromResult(new CommandResponse(this));
            }

           var cliente = _repositoryCliente.Obter(request.Id);

           if (cliente is null)
           {
                AddNotification("ObterClienteHandler", "Cliente não localizado");
                return Task.FromResult(new CommandResponse(this));
            }

            var clienteCompleto = new ObterClienteResponse(
                cliente.Id, 
                cliente.Nome, 
                cliente.Email,        // criei um objeto contendo os dados do cliente para simplificar
                cliente.Telefone, 
                cliente.Cpf,
                cliente.FlagAtivo);

            return Task.FromResult(
                new CommandResponse(clienteCompleto, this));  //passei o objeto como parametro de dados
        }

    }
}
