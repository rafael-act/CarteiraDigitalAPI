using Dominio.Core.Interfaces.Repositorios;
using Dominio.Core.Interfaces.UnitOfWork;
using Infraestrutura.Data;

namespace Infraestrutura.Repositorio.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarteiraContext _context;

        public UnitOfWork(CarteiraContext context)
        {
            _context = context;
            Carteiras = new RepositorioCarteira(_context);
            Clientes = new RepositorioCliente(_context);
            Transacoes = new RepositorioTransacao(_context);
        }
        public IRepositorioCarteira Carteiras { get; private set; }
        public IRepositorioCliente Clientes { get; private set; }
        public IRepositorioTransacao Transacoes { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
