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
    public class CarteiraMap : IEntityTypeConfiguration<Carteira>
    {
        public void Configure(EntityTypeBuilder<Carteira> builder)
        {
            // Tabela
            builder.ToTable("Carteira");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.NumeroCarteira)
                .IsRequired()
                .HasColumnName("NumeroCarteira")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.DataCriacao)
            .IsRequired()
            .HasColumnName("DataCriacao")
            .HasColumnType("VARCHAR");

            builder.Property(x => x.Situacao)
              .IsRequired()
              .HasColumnName("Situacao")
              .HasColumnType("VARCHAR")
              .HasMaxLength(20);

            builder.Property(x => x.Saldo)
            .IsRequired()
            .HasColumnName("Saldo")
            .HasColumnType("NUMERIC");

            builder.Property(x => x.Cliente.Id)
            .IsRequired()
            .HasColumnName("ClienteId")
            .HasColumnType("integer");
        }
    }
}
