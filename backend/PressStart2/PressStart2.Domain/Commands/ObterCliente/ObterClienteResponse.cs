using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.ObterCliente
{
    public class ObterClienteResponse
    {
        public Guid Id { get; set; }

        public string Nome { get; }
        public string Email { get; }
        public string Telefone { get; }
        public string Cpf { get; }
        public bool FlagAtivo { get; }

        public ObterClienteResponse(Guid id, string nome, string email, string telefone, string cpf, bool flagAtivo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cpf = cpf;
            FlagAtivo = flagAtivo;
        }

        public ObterClienteResponse(Guid id, string? nome, string? email, string? telefone, bool flagAtivo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            FlagAtivo = flagAtivo;
        }
    }
}
