using Microsoft.EntityFrameworkCore;
using PressStart2.Domain.Entities;
using PressStart2.Domain.Interfaces.Repositories;
using PressStart2.Infra.Data.Context;


namespace PressStart2.Infra.Data.Repositories
{
    public class RepositoryVenda : RepositoryBase<Venda>, IRepositoryVenda
    {
        public RepositoryVenda(PressStart2Context context) : base(context)
        {

        }

        public Venda ObterComDependencia(Guid id)
        {
            return _context.VendaDbSet
                .Include(p => p.Cliente)
                .Include(p => p.Itens)
                .FirstOrDefault(p => p.Id == id);
        }

        public bool ClientePossuiVendas(Guid clienteId)
        {
            return _context.VendaDbSet.Any(p => p.ClienteId == clienteId);
        }

        public IEnumerable<Venda> ListarComDependencia()
        {
            return _context.VendaDbSet .Include(p => p.Cliente)
                                       .AsEnumerable();
        }
    }
}
