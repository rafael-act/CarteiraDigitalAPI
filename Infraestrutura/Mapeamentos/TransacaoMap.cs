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
    public class TransacaoMap : IEntityTypeConfiguration<Transacao>
    {

        public void Configure(EntityTypeBuilder<Transacao> builder)
        { 
            // Tabela
            builder.ToTable("Transacao");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.DataOperacao)
                .IsRequired()
                .HasColumnName("DataOperacao")
                .HasColumnType("date");

            builder.Property(x => x.TipoOperacao)
                .IsRequired()
                .HasColumnName("TipoOperacao")
                .HasColumnType("VARCHAR")
                 .HasMaxLength(50);

            builder.Property(x => x.ValorOperacao)
             .IsRequired()
             .HasColumnName("ValorOperacao")
             .HasColumnType("numeric");

            builder.Property(x => x.CarteiraSacado.Id)
            .IsRequired()
            .HasColumnName("CarteiraSacadoId")
            .HasColumnType("numeric");

            builder.Property(x => x.CarteiraCedente.Id)
            .IsRequired()
            .HasColumnName("CarteiraCedenteId")
            .HasColumnType("numeric");
        }
    }
}
