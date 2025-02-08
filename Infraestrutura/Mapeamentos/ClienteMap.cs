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
            builder.ToTable("cliente");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("nome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Sobrenome)
               .IsRequired()
               .HasColumnName("sobrenome")
               .HasColumnType("VARCHAR")
               .HasMaxLength(100);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(150); 
            
            builder.Property(x => x.DataCadastro)
                .IsRequired()
                .HasColumnName("datacadastro")
                .HasColumnType("date");

            builder.Property(x => x.Ativo)
                .IsRequired()
                .HasColumnName("ativo");

            builder.Property(x => x.PasswordHash).IsRequired()
                .HasColumnName("passwordhash")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName("slug")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.RolesId)
                .HasColumnName("rolesid")
                .HasColumnType("numeric")
               .ValueGeneratedOnAdd();
            // Índices
            builder
                .HasIndex(x => x.Slug, "IX_User_Slug")
                .IsUnique();
        }
    }

}
