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
        void Adicionar(ClienteDTO obj);

        ClienteDTO ObterPeloId(int id);

        IEnumerable<ClienteDTO> ObterTodos();

        void Atualizar(ClienteDTO obj);

        void Remover(ClienteDTO obj);

        void Dispose();
    }
}
