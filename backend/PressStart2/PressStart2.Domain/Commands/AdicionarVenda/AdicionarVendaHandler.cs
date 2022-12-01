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

namespace PressStart2.Domain.Commands.AdicionarVenda
{
    public class AdicionarVendaHandler : Notifiable, IRequestHandler<AdicionarVendaRequest, CommandResponse>
    {
        private readonly IRepositoryCliente _repositoryCliente;
        private readonly IRepositoryVenda _repositoryVenda;

        public AdicionarVendaHandler(IRepositoryCliente repositoryCliente, IRepositoryVenda repositoryVenda)
        {
            _repositoryCliente = repositoryCliente;
            _repositoryVenda = repositoryVenda;
        }


        public Task<CommandResponse> Handle(AdicionarVendaRequest request, CancellationToken cancellationToken)
        {
            var cliente = _repositoryCliente.Obter(request.ClienteId);

            if (cliente == null)
                AddNotification("AdicionarVendaHandler", "Cliente não localizado");


            var venda = new Venda(request.ClienteId, request.Itens.Count, request.DataFaturamento, request.Itens.Sum(p => p.ValorTotal) );

            request.Itens.ForEach(vendaItem =>
            {
                var vi = new VendaItem(
                    vendaItem.DescricaoItem,
                    vendaItem.ValorUnitario,
                    vendaItem.Quantidade,
                    vendaItem.ValorTotal);

                venda.AdicionarItem(vi);
            });

            AddNotifications(venda);

            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            _repositoryVenda.Adicionar(venda);
            _repositoryVenda.Commit();

            var adicionarVendaResponse = new AdicionarVendaResponse(venda.Id, "Venda registrada com sucesso.");

            return Task.FromResult(new CommandResponse(adicionarVendaResponse, this));

        }
    }
}
