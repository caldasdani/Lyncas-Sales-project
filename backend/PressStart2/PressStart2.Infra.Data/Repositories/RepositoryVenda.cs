using Microsoft.EntityFrameworkCore;
using PressStart2.Domain.Entities;
using PressStart2.Domain.Interfaces.Repositories;
using PressStart2.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Infra.Data.Repositories
{
    public class RepositoryVenda : RepositoryBase<Venda>, IRepositoryVenda
    {
        public RepositoryVenda(PressStart2Context context) : base(context)
        {

        }

        public Venda ObterComDependencia(Guid id)
        {
            return _context.VendaDbSet.Include(p => p.Itens).FirstOrDefault(p => p.Id == id);
        }
    }
}
