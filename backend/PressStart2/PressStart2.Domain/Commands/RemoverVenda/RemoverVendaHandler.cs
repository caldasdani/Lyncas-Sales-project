using MediatR;
using PressStart2.Domain.Commands.RemoverCliente;
using PressStart2.Domain.DTOs;
using PressStart2.Domain.Interfaces.Repositories;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.RemoverVenda
{
    public class RemoverVendaHandler : Notifiable, IRequestHandler<RemoverVendaRequest, CommandResponse>
    {
        private readonly IRepositoryVenda _repositoryVenda;

        public RemoverVendaHandler(IRepositoryVenda repositoryVenda)
        {
            _repositoryVenda = repositoryVenda;
        }

        public Task<CommandResponse> Handle(RemoverVendaRequest request, CancellationToken cancellationToken)
        {
            var venda = _repositoryVenda.ObterComDependencia(request.Id);

            if (venda == null)
            {
                AddNotification("RemoverVendaHandler", "Venda não localizada");
                return Task.FromResult(new CommandResponse(this));
            }

            venda.Itens.ToList().ForEach(vendaItem => venda.RemoverItem(vendaItem));

            _repositoryVenda.Remover(venda);
            _repositoryVenda.Commit();

            return Task.FromResult(new CommandResponse(new RemoverVendaResponse("Venda excluída"), this));

        }
    }
}
