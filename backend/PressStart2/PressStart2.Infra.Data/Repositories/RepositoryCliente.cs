using PressStart2.Domain.Interfaces.Repositories;
using PressStart2.Domain.Entities;
using PressStart2.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using PressStart2.Domain.Commands.ListarCliente;

namespace PressStart2.Infra.Data.Repositories
{
    public class RepositoryCliente : RepositoryBase<Cliente>, IRepositoryCliente
    {
        public RepositoryCliente(PressStart2Context context) : base (context)
        {

        }


        public bool VerificaDuplicidade(string cpf)
        {
            return _context.ClienteDbSet.Any(p => p.Cpf==cpf);

        }
    }
}
