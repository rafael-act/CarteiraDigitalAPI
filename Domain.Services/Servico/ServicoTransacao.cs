using Dominio.Core.Interfaces.Repositorios;
using Dominio.Core.Interfaces.Servicos;
using Dominio.Modelos;

namespace Dominio.Servico.Servico
{
    public class ServicoTransacao : ServicoBase<Transacao>, IServicoTransacao
    {
        public readonly IRepositorioTransacao _repositorio;
        public ServicoTransacao(IRepositorioTransacao repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<Transacao>> ListarTransferenciasPorCliente(int clienteId, DateTime? dtInicial, DateTime? dtFinal)
        {
            return await _repositorio.ListarTransferenciasPorCliente(clienteId, dtInicial, dtFinal);
        }
    }
}
