using Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interface
{
    public interface IAplicacaoServicoCarteira
    {
        void Adicionar(CarteiraDTO obj);

        CarteiraDTO ObterPeloId(int id);

        IEnumerable<CarteiraDTO> ObterTodos();

        void Atualizar(CarteiraDTO obj);

        void Remover(CarteiraDTO obj);

        void Dispose();
    }
}
