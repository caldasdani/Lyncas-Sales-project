using MediatR;
using PressStart2.Domain.Commands.ListarCliente;
using PressStart2.Domain.DTOs;
using PressStart2.Domain.Interfaces.Repositories;
using prmToolkit.NotificationPattern;


namespace PressStart2.Domain.Commands.ListarVenda
{
    public class ListarVendaHandler : Notifiable, IRequestHandler<ListarVendaRequest, CommandResponse>
    {
        private readonly IRepositoryVenda _repositoryVenda;
        // propriedade somente leitura de um repositorio de cliente

        public ListarVendaHandler(IRepositoryVenda repositoryVenda)
        {
            _repositoryVenda = repositoryVenda;
        }

        public Task<CommandResponse> Handle(ListarVendaRequest request, CancellationToken cancellationToken)
        {
            var ListaVendas = _repositoryVenda.ListarComDependencia();

            var ListaVendasResponse = ListaVendas.Select(venda => new ListarVendaResponse(
                venda.Id,
                venda.Cliente.Id,
                venda.Cliente.Nome,
                venda.QuantidadeItens,
                venda.DataVenda,
                venda.DataFaturamento,
                venda.ValorTotal));

            return Task.FromResult(new CommandResponse(ListaVendasResponse, this));
        }
    }   
}

