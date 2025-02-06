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
        public CarteiraDTO(int? id, string numeroCarteira, string dataCriacao, string situacao, double saldo, Cliente cliente)
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
        public string DataCriacao { get; set; }
        public string Situacao { get; set; }
        public double Saldo { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
