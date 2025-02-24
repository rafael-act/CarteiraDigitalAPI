using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Core.Interfaces.Repositorios
{
    public interface IRepositorioBase<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T obj);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
