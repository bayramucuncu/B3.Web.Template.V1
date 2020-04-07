using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using B3.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace B3.EntityFramework
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity : class, new()
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);

            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            _dbSet.Remove(entity);

            return entity;
        }

        public IQueryable<TEntity> All()
        {
            return _dbSet;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IQueryable<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> orderBy, bool isDesc)
        {
            return isDesc ? _dbSet.OrderByDescending(orderBy) : _dbSet.OrderBy(orderBy);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}