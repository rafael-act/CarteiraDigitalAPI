using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelos;
using Infraestrutura.Data.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Data
{
    public class CarteiraContext:DbContext
    {
        public CarteiraContext()
        {

        }

        public CarteiraContext(DbContextOptions<CarteiraContext> options):base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Carteira> Carteiras { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new RolesMap());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry=>entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
