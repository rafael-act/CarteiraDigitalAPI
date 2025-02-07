using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Data.Mapeamentos
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            // Tabela
            builder.ToTable("Cliente");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Nome)
               .IsRequired()
               .HasColumnName("Sobrenome")
               .HasColumnType("VARCHAR")
               .HasMaxLength(100);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(150); 
            
            builder.Property(x => x.DataCadastro)
                .IsRequired()
                .HasColumnName("DataCadastro")
                .HasColumnType("VARCHAR");

            builder.Property(x => x.Ativo)
                .IsRequired()
                .HasColumnName("Ativo");

            builder.Property(x => x.PasswordHash).IsRequired()
                .HasColumnName("PasswordHash")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);


            // Índices
            builder
                .HasIndex(x => x.Slug, "IX_User_Slug")
                .IsUnique();
        }
    }

}
