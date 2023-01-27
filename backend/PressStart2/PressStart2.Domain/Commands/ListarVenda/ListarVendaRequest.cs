using AspNetCore.IQueryable.Extensions.Pagination;
using AspNetCore.IQueryable.Extensions.Sort;
using AspNetCore.IQueryable.Extensions;
using MediatR;
using PressStart2.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;

namespace PressStart2.Domain.Commands.ListarVenda
{
    public class ListarVendaRequest : IRequest<CommandResponse>, ICustomQueryable, IQuerySort, IQueryPaging
    {
        public DateTime? DataVenda { get; set; }
        public DateTime? DataFaturamento { get; set; }
        public decimal? ValorTotal { get; set; }
        public int? QuantidadeItens { get; set; }
        public Guid? ClienteId { get; set; }
        public string? ClienteNome { get; set; } = string.Empty;
        public string? Sort { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
    }
}
