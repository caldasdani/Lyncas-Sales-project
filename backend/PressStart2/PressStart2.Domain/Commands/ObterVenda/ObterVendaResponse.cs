using PressStart2.Domain.DTOs;

namespace PressStart2.Domain.Commands.ObterVenda
{
    public class ObterVendaResponse
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime DataFaturamento { get; set; }
        public IEnumerable<VendaItemObterDto> Itens { get; set; }

    }
}
