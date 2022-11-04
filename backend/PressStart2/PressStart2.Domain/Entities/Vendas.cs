using PressStart2.Domain.Entities;
using System;

namespace PressStart2.Domain.Entities
{
    public class Venda : EntidadeBase // a classe venda está herdando oq contem na Entidade Base.
    {
        private List<VendaItem> _itens;

        public Guid ClienteId { get; private set; }
        public int QuantidadeItens { get; private set; }
        public DateTime DataVenda { get; private set; }
        public DateTime DataFaturamento { get; private set; }
        public decimal ValorTotal { get; private set; }
        public virtual IEnumerable <VendaItem> Itens => _itens;


        public virtual Cliente Cliente { get; private set; }

        protected Venda() { }

        public Venda(Guid clienteId, int quantidadeItens, DateTime dataFaturamento, decimal valorTotal)
            //construtor com parametro para instanciar venda
        {
            ClienteId = clienteId;
            QuantidadeItens = quantidadeItens;
            DataFaturamento = dataFaturamento;
            ValorTotal = valorTotal;
            DataVenda = DateTime.Now;
            _itens = new();
        }

        public void Atualizar(Guid clienteId, int quantidadeItens, DateTime dataFaturamento, decimal valorTotal)
        {
            ClienteId = clienteId;
            QuantidadeItens = quantidadeItens;
            DataFaturamento = dataFaturamento;
            ValorTotal = valorTotal;
            DataVenda = DateTime.Now;
            _itens = new();
        }
        public void AdicionarItem(VendaItem vendaItem)
        {
            AddNotifications(vendaItem);
            _itens.Add(vendaItem);
        }
        public void AtualizarItem(VendaItem vendaItem)
        {
            var vi = _itens.FirstOrDefault(p => p.Id == vendaItem.Id);
            vi?.Atualizar(Guid clienteId, int quantidadeItens, DateTime dataFaturamento, decimal valorTotal);

            AddNotification(vi);
        }
        public void RemoverItem(VendaItem vendaItem)
        {
            _itens.Remove(vendaItem);
        }
    }
}
