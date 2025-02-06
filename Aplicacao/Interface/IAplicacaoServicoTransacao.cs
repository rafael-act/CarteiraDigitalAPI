using Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interface
{
    public interface IAplicacaoServicoTransacao
    {
        void Adicionar(TransacaoDTO obj);

        TransacaoDTO ObterPeloId(int id);

        IEnumerable<TransacaoDTO> ObterTodos();

        void Atualizar(TransacaoDTO obj);

        void Remover(TransacaoDTO obj);

        void Dispose();
    }
}
