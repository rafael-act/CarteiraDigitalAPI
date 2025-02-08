﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        Task Adicionar(TEntity obj);

        Task<TEntity> ObterPeloId(int id);

        IEnumerable<TEntity> ObterTodos();

        void Atualizar(TEntity obj);

        void Remover(TEntity obj);

        void Dispose();
    }
}
