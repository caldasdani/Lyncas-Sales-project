﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.ListarVenda
{
    public class ListarVendaResponse
    {
        public Guid Id { get; }
        public Guid ClienteId { get; }
        public int QuantidadeItens { get; }
        public DateTime DataVenda { get; }
        public DateTime DataFaturamento { get; }
        public decimal ValorTotal { get; }

        public ListarVendaResponse(Guid id, Guid clienteId, int quantidadeItens, DateTime dataVenda, DateTime dataFaturamento, decimal valorTotal)
        {
            Id = id;
            ClienteId = clienteId;
            QuantidadeItens = quantidadeItens;
            DataVenda = dataVenda;
            DataFaturamento = dataFaturamento;
            ValorTotal = valorTotal;
        }
    }
}
