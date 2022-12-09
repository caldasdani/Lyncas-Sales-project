using PressStart2.Domain.Entities;


namespace PressStart2.Domain.Interfaces.Repositories
{
    public interface IRepositoryVenda : IRepositoryBase<Venda>
    {
        Venda ObterComDependencia(Guid id);
    }
}
