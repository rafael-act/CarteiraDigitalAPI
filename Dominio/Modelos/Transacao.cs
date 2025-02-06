using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class Transacao : Base
    {
        public Transacao(DateTime dataOperacao, string tipoOperacao, double valorOperacao, Carteira carteiraSacado, Carteira carteiraCedente)
        {
            DataOperacao = dataOperacao;
            TipoOperacao = tipoOperacao;
            ValorOperacao = valorOperacao;
            CarteiraSacado = carteiraSacado;
            CarteiraCedente = carteiraCedente;
        }

        public DateTime DataOperacao { get; set; }
        public string TipoOperacao { get; set; }
        public double ValorOperacao{ get; set; }
        public virtual Carteira CarteiraSacado { get; set; }
        public virtual Carteira CarteiraCedente { get; set; }
    }
}
