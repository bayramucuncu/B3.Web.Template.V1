using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace B3.Infrastructure.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(TEntity entity);

        IQueryable<TEntity> All();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> orderBy, bool isDesc);
    }
}