using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.DTO
{
    public class CarteiraDTO
    {
        public CarteiraDTO(int? id, string numeroCarteira, DateTime dataCriacao, string situacao, decimal saldo, Cliente cliente)
        {
            Id = id;
            NumeroCarteira = numeroCarteira;
            DataCriacao = dataCriacao;
            Situacao = situacao;
            Saldo = saldo;
            Cliente = cliente;
        }

        public int? Id { get; set; }
        public string NumeroCarteira { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Situacao { get; set; }
        public decimal Saldo { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
