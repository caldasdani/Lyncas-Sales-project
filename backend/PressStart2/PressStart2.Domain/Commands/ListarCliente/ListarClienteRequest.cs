using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Pagination;
using AspNetCore.IQueryable.Extensions.Sort;
using MediatR;
using PressStart2.Domain.DTOs;

namespace PressStart2.Domain.Commands.ListarCliente
{
    public class ListarClienteRequest : IRequest<CommandResponse>, ICustomQueryable, IQuerySort, IQueryPaging
    {
        [QueryOperator (Operator = WhereOperator.Contains, CaseSensitive = false)]
        public string? Nome { get; set; }

        [QueryOperator(Operator = WhereOperator.StartsWith)]
        public string? Email { get; set; }

        [QueryOperator(Operator = WhereOperator.Contains)]
        public string? Telefone { get; set; }

        [QueryOperator(Operator = WhereOperator.Contains)]
        public string? Cpf { get; set; }

        public bool? FlagAtivo { get; set; }

        public string? Sort { get; set; }
        public int? Limit { get; set; }
        public int? PageSize { get; set;}
        public int? Offset { get; set; }
    }
}
