using Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interface
{
    public interface IAplicacaoServicoCliente
    {
        Task Adicionar(ClienteDTO obj);

        Task<ClienteDTO> ObterPeloId(int id);

        IEnumerable<ClienteDTO> ObterTodos();

        void Atualizar(ClienteDTO obj);

        void Remover(ClienteDTO obj);

        void Dispose();
    }
}
