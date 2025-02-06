using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class Carteira:Base
    {
        public Carteira(string numeroCarteira, string dataCriacao, string situacao, double saldo, Cliente cliente)
        {
            NumeroCarteira = numeroCarteira;
            DataCriacao = dataCriacao;
            Situacao = situacao;
            Saldo = saldo;
            Cliente = cliente;
        }

        public string NumeroCarteira { get; set; }
        public string DataCriacao { get; set; }
        public string Situacao { get; set; }
        public double Saldo { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
