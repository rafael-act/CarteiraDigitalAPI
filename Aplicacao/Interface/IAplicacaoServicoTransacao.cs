using Aplicacao.DTO;

namespace Aplicacao.Interface
{
    public interface IAplicacaoServicoTransacao
    {
        Task Adicionar(TransacaoDTO obj);

        Task<TransacaoDTO>ObterPeloId(int id);

        Task<IEnumerable<TransacaoDTO>> ObterTodos();

        void Atualizar(TransacaoDTO obj);

        void Remover(TransacaoDTO obj);
        void Dispose();

        Task<IEnumerable<TransacaoDTO>> ListarTransferenciasPorCliente (int clienteId, DateTime? dtInicial, DateTime? dtFinal);
    }
}
