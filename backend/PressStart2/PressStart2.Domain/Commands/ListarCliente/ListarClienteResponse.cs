using PressStart2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.ListarCliente
{
    public class ListarClienteResponse
    {
        public Guid Id { get; }
        public string Nome { get; }
        public string Email { get; }
        public string Telefone { get; }
        public string Cpf { get; }
        public bool FlagAtivo { get; }
        
        
        public ListarClienteResponse(Guid id, string nome, string email, string telefone, string cpf, bool flagAtivo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cpf = cpf;
            FlagAtivo = flagAtivo;
        }
    }
}
