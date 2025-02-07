using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    [Table("teachers")]
    public class Carteira : DbContext
    {
        public Carteira(string numeroCarteira, string dataCriacao, string situacao, decimal saldo, Cliente cliente)
        {
            NumeroCarteira = numeroCarteira;
            DataCriacao = dataCriacao;
            Situacao = situacao;
            Saldo = saldo;
            Cliente = cliente;
        }
        [System.ComponentModel.DataAnnotations.Key]
        [Column("id")]
        public int? Id { get; set; }
        [Column("numerocarteira")]
        public string NumeroCarteira { get; set; }
        [Column("datacriacao")]
        public string DataCriacao { get; set; }
        [Column("situacao")]
        public string Situacao { get; set; }
        [Column("saldo")]
        public decimal Saldo { get; set; }
        [Column("clienteid")]
        public int? clienteid { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
