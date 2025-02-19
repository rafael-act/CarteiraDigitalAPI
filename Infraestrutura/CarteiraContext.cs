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
    public class CarteiraContext : DbContext
    {
        public CarteiraContext(DbContextOptions<CarteiraContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Carteira> Carteiras { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new RolesMap());

            modelBuilder.Entity<Carteira>().HasKey(s => s.Id);

            modelBuilder.Entity<Carteira>()
               .HasOne(e => e.Cliente)
               .WithMany(e => e.Carteiras)
               .HasForeignKey(e => e.ClienteId);

            modelBuilder.Entity<Cliente>()
              .HasMany(e => e.Carteiras)
              .WithOne(e => e.Cliente);

            modelBuilder.Entity<Cliente>()
              .HasOne(e => e.Role)
              .WithMany(e => e.Clientes);

            modelBuilder.Entity<Carteira>()
              .Property(c => c.DataCriacao)
              .HasConversion(
           v => v.ToUniversalTime(),
           v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            modelBuilder.Entity<Transacao>()
                .HasOne(t => t.CarteiraSacado)
                .WithMany(c => c.Transacoes)
                .HasForeignKey(t => t.carteirasacadoid)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transacao>()
                .HasOne(t => t.CarteiraCedente)
                .WithMany() // Sem coleção para evitar conflito
                .HasForeignKey(t => t.carteiracedenteid)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
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
