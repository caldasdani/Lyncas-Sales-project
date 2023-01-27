using PressStart2.Domain.Entities;


namespace PressStart2.Domain.Interfaces.Repositories
{
    public interface IRepositoryVenda : IRepositoryBase<Venda>
    {
        IQueryable<Venda> ListarComDependencia();
        Venda ObterComDependencia(Guid id);
        bool ClientePossuiVendas (Guid clienteId);
    }
}
