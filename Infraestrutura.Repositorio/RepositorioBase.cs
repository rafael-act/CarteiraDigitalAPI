﻿using Dominio.Core.Interfaces.Repositorios;
using Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorio
{
    public abstract class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class

    {
        private readonly CarteiraContext _context;
        public RepositorioBase(CarteiraContext context)
        {
            _context = context;
        }

        public void Adicionar(TEntity obj)
        {
            try
            {
                _context.Set<TEntity>().Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(TEntity obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<TEntity> ObterPeloId(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            if (entity == null)
                throw new KeyNotFoundException($"{typeof(TEntity).Name} com ID {id} não encontrado.");

            return entity;
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Remover(TEntity obj)
        {
            try
            {
                _context.Set<TEntity>().Remove(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}