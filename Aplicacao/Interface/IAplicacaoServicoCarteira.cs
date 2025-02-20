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
        Task Adicionar(CarteiraDTO obj);

        Task<CarteiraDTO> ObterPeloId(int id);

        Task<IEnumerable<CarteiraDTO>> ObterTodos();

        void Atualizar(CarteiraDTO obj);

        void Remover(CarteiraDTO obj);

        Task<CarteiraDTO> ObterCarteira(string numeroCarteira);

        Task AdicionarSaldoCarteira(string numeroCarteira, decimal valorAdicionar);
        Task TransferênciaEntreCarteiras(string carteiraCedente, string carteiraSacado, decimal valorAdicionar);
    }
}
