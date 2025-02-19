using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    [Table("carteira")]
    public class Carteira : DbContext
    {
        [Key]
        [Column("id")]
        public int? Id { get; set; }
        [Column("numerocarteira")]
        public string NumeroCarteira { get; set; }
        [Column("datacriacao")]
        public DateTime DataCriacao { get; set; }
        [Column("situacao")]
        public string Situacao { get; set; }
        [Column("saldo")]
        public decimal Saldo { get; set; }
        [ForeignKey("Cliente")]
        [Column("clienteid")]
        public int? ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        [JsonIgnore]
        public virtual ICollection<Transacao> Transacoes { get; set; }

        public decimal AdicionarSaldoCarteira(decimal valorAdicionar)
        {
            return this.Saldo = this.Saldo + valorAdicionar;
        }
        public decimal DiminuirSaldoCarteira(decimal valorReduzir)
        {
            return this.Saldo = this.Saldo - valorReduzir;
        }
    }
}
