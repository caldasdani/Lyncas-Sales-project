using PressStart2.Domain.Entities;
using PressStart2.Domain.Entities.Contracts;
using System;

namespace PressStart2.Domain.Entities
{
    public class Venda : EntidadeBase // a classe venda está herdando oq contem na Entidade Base.
    {
        private List<VendaItem> _itens;
             //lista   tipo    nome da lista

        public Guid ClienteId { get; private set; }
        public int QuantidadeItens { get; private set; }
        public DateTime DataVenda { get; private set; }
        public DateTime DataFaturamento { get; private set; }
        public decimal ValorTotal { get; private set; }
        public virtual IEnumerable <VendaItem> Itens => _itens;
              //funçao de listagem mas sem tantas funcionalidades quanto a lista

        
        //propriedade de navegabilidade '
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

            this.AdicionarVendaContract(); 
        }

        public void Atualizar(Guid clienteId, int quantidadeItens, DateTime dataFaturamento, decimal valorTotal)
        {
            ClienteId = clienteId;
            QuantidadeItens = quantidadeItens;
            DataFaturamento = dataFaturamento;
            ValorTotal = valorTotal;
            DataVenda = DateTime.Now;
            _itens = new();

            this.AtualizarVendaContract();
        }
        public void AdicionarItem(VendaItem vendaItem)
        {
            AddNotifications(vendaItem);
            _itens.Add(vendaItem);
        }
        public void AtualizarItem(VendaItem vendaItem)
        {
            var vi = _itens.FirstOrDefault(p => p.Id == vendaItem.Id);
            vi?.Atualizar(vendaItem.DescricaoItem, vendaItem.ValorUnitario, vendaItem.Quantidade, vendaItem.ValorTotal);

            AddNotifications(vi);
        }
        public void RemoverItem(VendaItem vendaItem)
        {
            _itens.Remove(vendaItem);
        }
    }
}
