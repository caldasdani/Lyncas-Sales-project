using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Pagination;
using AspNetCore.IQueryable.Extensions.Sort;
using MediatR;
using PressStart2.Domain.DTOs;
using PressStart2.Domain.Interfaces.Repositories;
using prmToolkit.NotificationPattern;

namespace PressStart2.Domain.Commands.ListarCliente
{
    public class ListarClienteHandler : Notifiable, IRequestHandler<ListarClienteRequest, CommandResponse>
    {
        private readonly IRepositoryCliente _repositoryCliente;
        // propriedade somente leitura de um repositorio de cliente

        public ListarClienteHandler(IRepositoryCliente repositoryCliente)
        {
            _repositoryCliente = repositoryCliente;
        }

        public Task<CommandResponse> Handle(ListarClienteRequest request, CancellationToken cancellationToken)
        {
            var ListaClientes = _repositoryCliente.Query().Filter(request).Sort(request).Paginate(request);

            var ListaClientesResponse = ListaClientes.Select(cliente => new ListarClienteResponse(
                cliente.Id,
                cliente.Nome,
                cliente.Email,
                cliente.Telefone,
                cliente.Cpf,
                cliente.FlagAtivo));

            return Task.FromResult(new CommandResponse(ListaClientesResponse, this));
        }
    }
}
