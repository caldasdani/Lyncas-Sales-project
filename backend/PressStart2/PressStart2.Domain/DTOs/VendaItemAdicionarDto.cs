using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.DTOs
{
    public class VendaItemAdicionarDto
    {
        public string DescricaoItem { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }

    }
}
