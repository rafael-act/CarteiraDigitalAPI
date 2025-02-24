using Dominio.Modelos;

namespace Dominio.Core.Interfaces.Servicos
{
    public interface IServicoTransacao:IServicoBase<Transacao>
    {
        Task<IEnumerable<Transacao>> ListarTransferenciasPorCliente(int clienteId, DateTime? dtInicial, DateTime? dtFinal);
    }
}
