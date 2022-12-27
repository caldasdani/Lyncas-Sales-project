using PressStart2.Domain.Entities;
using PressStart2.Domain.Interfaces.Repositories;
using PressStart2.Infra.Data.Context;

namespace PressStart2.Infra.Data.Repositories
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        public RepositoryUsuario(PressStart2Context context) : base(context)
        {
        }

        public Usuario Autenticar(string login, string senha)
        {
            return DbSet.FirstOrDefault(p => p.Login == login && p.Senha == senha);
        }
    }
}
