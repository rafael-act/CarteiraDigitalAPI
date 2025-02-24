using Dominio.Core.Interfaces.Repositorios;
using Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestrutura.Repositorio
{
    public abstract class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        protected readonly CarteiraContext _context;

        public RepositorioBase(CarteiraContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public void Update(T obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
            }
            catch
            {
                throw;
            }
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}