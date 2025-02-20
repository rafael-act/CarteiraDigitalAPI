using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio.Core.Interfaces.Servicos
{
    public interface IServicoBase<TEntity> where TEntity : class
    {
        Task Adicionar(TEntity obj);

        Task<TEntity?> ObterPeloId(int id);

        Task<IEnumerable<TEntity>> ObterTodos();

        void Atualizar(TEntity obj);

        void Remover(TEntity obj);

        void Dispose();
    }
}
