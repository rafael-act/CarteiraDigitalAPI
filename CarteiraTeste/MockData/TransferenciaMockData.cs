using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelos;
using Infraestrutura.CrossCutting.Adapter.Map;

namespace CarteiraTeste.MockData
{
    class TransferenciaMockData
    {
        public static IEnumerable<Transacao> ObterTarefas()
        {
            var mapper = new MapperTransacao();
            var lista =  new List<Transacao>
            {
                new Transacao()
                {
                    carteiracedenteid=1,
                    carteirasacadoid=2,
                    DataOperacao=DateTime.UtcNow,
                    Id=1,
                    TipoOperacao="Transferencia",
                    ValorOperacao=100.15M
                },
                 new Transacao()
                {
                    carteiracedenteid=2,
                    carteirasacadoid=1,
                    DataOperacao=DateTime.UtcNow,
                    Id=1,
                    TipoOperacao="Transferencia",
                    ValorOperacao=250.15M
                },
                  new Transacao()
                {
                    carteiracedenteid=1,
                    carteirasacadoid=2,
                    DataOperacao=DateTime.UtcNow,
                    Id=1,
                    TipoOperacao="Transferencia",
                    ValorOperacao=10.15M
                }
            };

            return (IEnumerable<Transacao>)mapper.MapperListTransacao(lista);
        }
    }
}
