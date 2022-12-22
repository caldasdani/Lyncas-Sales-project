using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using prmToolkit.NotificationPattern;
using PressStart2.Domain.Entities;

namespace PressStart2.Infra.Data.Context
{
    public class PressStart2Context : DbContext // pacote do proprio entity framework
    {
        public PressStart2Context(DbContextOptions<PressStart2Context> options) : base (options) {}
        public DbSet<Cliente> ClienteDbSet { get; set; }
        public DbSet<Venda> VendaDbSet { get; set;}
        public DbSet<VendaItem> VendaItemDbSet { get; set; }
        public DbSet<Usuario> UsuarioDbSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PressStart2Context).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }

    }
}
