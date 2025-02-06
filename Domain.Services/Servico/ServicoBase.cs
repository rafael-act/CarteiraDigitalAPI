using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core.Interfaces;
using Dominio.Core.Interfaces.Repositorios;
using Dominio.Core.Interfaces.Servicos;

namespace Dominio.Servico.Servico

{
    public abstract class ServicoBase<TEntity> : IDisposable, IServicoBase<TEntity> where TEntity : class
    {
        private readonly IRepositorioBase<TEntity> _repositorio;
        public ServicoBase(IRepositorioBase<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }

        public virtual void Adicionar(TEntity obj)
        {
            _repositorio.Adicionar(obj);
        }

        public virtual TEntity ObterPeloId(int id)
        {
            return _repositorio.ObterPeloId(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }

        public virtual void Atualizar(TEntity obj)
        {
            _repositorio.Atualizar(obj);
        }

        public virtual void Remover(TEntity obj)
        {
            _repositorio.Remover(obj);
        }

        public void Dispose()
        {
           _repositorio.Dispose();
        }
    }
}
