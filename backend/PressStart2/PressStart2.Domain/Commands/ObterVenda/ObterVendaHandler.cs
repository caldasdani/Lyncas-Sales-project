using MediatR;
using PressStart2.Domain.Commands.ObterCliente;
using PressStart2.Domain.DTOs;
using PressStart2.Domain.Interfaces.Repositories;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.ObterVenda
{
    public class ObterVendaHandler : Notifiable, IRequestHandler<ObterVendaRequest, CommandResponse>
    {
        private readonly IRepositoryVenda _repositoryVenda;

        public ObterVendaHandler(IRepositoryVenda repositoryVenda)
        {
            _repositoryVenda = repositoryVenda;
        }

        public Task<CommandResponse> Handle(ObterVendaRequest request, CancellationToken cancellationToken)
        {
            var venda = _repositoryVenda.Obter(request.Id);

            if (venda == null)
            {
                AddNotification("ObterVendaHandler", "Venda não localizada");
                return Task.FromResult(new CommandResponse(this));
            }

            var obterTudo = new ObterVendaResponse();
            {
                obterTudo.Id = venda.Id;
                obterTudo.ClienteId = venda.ClienteId;
                obterTudo.DataFaturamento = venda.DataFaturamento;
            }

            var dto = venda.Itens.Select(vendaItem => new VendaItemObterDto
            {
                Id = vendaItem.Id,
                DescricaoItem = vendaItem.DescricaoItem,
                ValorUnitario = vendaItem.ValorUnitario,
                Quantidade = vendaItem.Quantidade,
                ValorTotal = vendaItem.ValorTotal
            });

            obterTudo.Itens = dto;
            return Task.FromResult(new CommandResponse(obterTudo, this));
        }
    }
}
