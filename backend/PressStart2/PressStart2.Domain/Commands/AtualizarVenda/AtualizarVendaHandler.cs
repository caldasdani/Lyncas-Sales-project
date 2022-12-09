using MediatR;
using PressStart2.Domain.DTOs;
using PressStart2.Domain.Interfaces.Repositories;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.AtualizarVenda
{
    public class AtualizarVendaHandler : Notifiable, IRequestHandler<AtualizarVendaRequest, CommandResponse>
    {
        private readonly IRepositoryVenda _repositoryVenda;
        private readonly IRepositoryCliente _repositoryCliente;

        public AtualizarVendaHandler(IRepositoryVenda repositoryVenda, IRepositoryCliente repositoryCliente)
        {
            _repositoryVenda = repositoryVenda;
            _repositoryCliente = repositoryCliente;
        }

        public Task<CommandResponse> Handle(AtualizarVendaRequest request, CancellationToken cancellationToken)
        {
            var venda = _repositoryVenda.Obter(request.Id);
            if (venda == null)
            {
                AddNotification("AtulizarVendaHandler", "Venda não encontrada");
                return Task.FromResult(new CommandResponse(this));
            }

            var cliente = _repositoryCliente.Obter(request.ClienteId);
            if (cliente == null)
            {
                AddNotification("AtualizarClienteHandler", "Cliente não encontrado");
            }

            venda.Atualizar(request.ClienteId, request.Itens.Count, request.DataFaturamento, request.Itens.Sum(p => p.ValorTotal));

            venda.Itens.ToList().ForEach(p => venda.RemoverItem(p));

            request.Itens.ForEach(p => {venda.AdicionarItem(new VendaItem(
                    p.DescricaoItem, 
                    p.ValorUnitario, 
                    p.Quantidade, 
                    p.ValorTotal));
                });

            AddNotifications(venda);
            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            _repositoryVenda.Atualizar(venda);
            _repositoryVenda.Commit();

            return Task.FromResult(new CommandResponse(new AtualizarVendaResponse("Venda atualizada com sucesso."), this));
        }
    }
}