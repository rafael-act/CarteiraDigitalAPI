using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.DTO
{
    public class TransacaoDTO
    {
        public TransacaoDTO(string tipoOperacao,Carteira carteiraSacado,Carteira carteiraCedente)
        {
            TipoOperacao=tipoOperacao;
            CarteiraSacado = carteiraSacado;
            CarteiraCedente=carteiraCedente;
        }
        public int? Id { get; set; }
        public DateTime DataOperacao { get; set; }
        public string TipoOperacao { get; set; }
        public decimal ValorOperacao { get; set; }
        public virtual Carteira CarteiraSacado { get; set; }
        public virtual Carteira CarteiraCedente { get; set; }
    }
}
