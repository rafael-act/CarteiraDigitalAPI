using Dominio.Core.Interfaces.Repositorios;
using Dominio.Core.Interfaces.Servicos;

namespace Dominio.Servico.Servico

{
    public abstract class ServicoBase<TEntity> : IDisposable, IServicoBase<TEntity> where TEntity : class
    {
        private readonly IRepositorioBase<TEntity> _repositorio;
        private bool disposedValue;

        public ServicoBase(IRepositorioBase<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }

        public virtual async Task Adicionar(TEntity obj)
        {
            await _repositorio.AddAsync(obj);
        }

        public virtual async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await _repositorio.GetAllAsync();
        }

        public virtual void Atualizar(TEntity obj)
        {
            _repositorio.Update(obj);
        }

        public virtual void Remover(TEntity obj)
        {
            _repositorio.Remove(obj);
        }

        public async Task<TEntity?> ObterPeloId(int id)
        {
            return await _repositorio.GetByIdAsync(id);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: descartar o estado gerenciado (objetos gerenciados)
                }

                // TODO: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador
                // TODO: definir campos grandes como nulos
                disposedValue = true;
            }
        }

        // // TODO: substituir o finalizador somente se 'Dispose(bool disposing)' tiver o código para liberar recursos não gerenciados
        // ~ServicoBase()
        // {
        //     // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
