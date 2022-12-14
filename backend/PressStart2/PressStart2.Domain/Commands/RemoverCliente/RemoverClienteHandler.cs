using MediatR;
using PressStart2.Domain.Commands.AtualizarCliente;
using PressStart2.Domain.DTOs;
using PressStart2.Domain.Interfaces.Repositories;
using prmToolkit.NotificationPattern;


namespace PressStart2.Domain.Commands.RemoverCliente
{
    public class RemoverClienteHandler : Notifiable, IRequestHandler<RemoverClienteRequest, CommandResponse>
    {
        private readonly IRepositoryCliente _repositoryCliente;
        private readonly IRepositoryVenda _repositoryVenda;

        public RemoverClienteHandler(IRepositoryCliente repositoryCliente, IRepositoryVenda repositoryVenda) 
        {
            _repositoryCliente = repositoryCliente;
            _repositoryVenda = repositoryVenda;
        }

        public Task<CommandResponse> Handle(RemoverClienteRequest request, CancellationToken cancellationToken)
        {
          
            var cliente = _repositoryCliente.Obter(request.Id);

            if (cliente is null)
            {
                AddNotification("RemoverClienteHandler", "Cliente não localizado");
                return Task.FromResult(new CommandResponse(this));
            }

            if (_repositoryVenda.ClientePossuiVendas(cliente.Id))
            {
                cliente.Inativar();
                _repositoryCliente.Atualizar(cliente);
            }
            else
            {
                _repositoryCliente.Remover(cliente);
            }

            
            _repositoryCliente.Commit();

            return Task.FromResult(new CommandResponse(
                new RemoverClienteResponse("cliente removido com sucesso"), this));
        }
    }
}
