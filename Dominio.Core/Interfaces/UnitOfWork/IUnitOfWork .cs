using Dominio.Core.Interfaces.Repositorios;

namespace Dominio.Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositorioCarteira Carteiras { get; }
        IRepositorioCliente Clientes { get; }
        IRepositorioTransacao Transacoes { get; }
        int Complete();
    }
}
