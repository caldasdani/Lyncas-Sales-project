using PressStart2.Domain.Interfaces.Repositories;
using PressStart2.Domain.Entities;
using PressStart2.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace PressStart2.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntidadeBase
    {
        protected readonly DbSet<TEntity> DbSet;
        protected readonly PressStart2Context _context;
        

        public RepositoryBase(PressStart2Context context)
        {
            DbSet = context.Set<TEntity>();
            _context = context;
        }

        public void Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public IEnumerable<TEntity> Listar()
        {
            return DbSet.AsEnumerable();
        }

        public TEntity Obter(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Remover(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IQueryable<TEntity> Query() 
        {
            return DbSet.AsQueryable();
        }
    }
}
