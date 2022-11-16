using PressStart2.Domain.Entities;

namespace PressStart2.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : EntidadeBase
        //padrao de interface começar com i ------ repositorio de tipo entidade;
                                             // especificado apenas para as classes da Entidade Base
    {
        IEnumerable<TEntity> Listar();
        TEntity Obter(Guid id);
        void Adicionar (TEntity entity);
        void Atualizar (TEntity entity);
        void Remover (TEntity entity);
        void VerificaDuplicidade(TEntity entity);
        void Commit();
    }
}
