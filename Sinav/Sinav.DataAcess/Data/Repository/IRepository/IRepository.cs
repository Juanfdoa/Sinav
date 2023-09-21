using System.Linq.Expressions;

namespace Sinav.DataAcess.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null!,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!,
            string includeProperties = null!
        );

        T GetFirtsOrDefault(
            Expression<Func<T, bool>> filter = null!,
            string includeProperties = null!
        );

        void Add(T entity);

        void Remove(int id);

        void Remove(T entity);

        //IQueryable<T> Include(params Expression<Func<T, object>>[] includes);
    }
}
