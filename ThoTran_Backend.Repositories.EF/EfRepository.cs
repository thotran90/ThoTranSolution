using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using $safeprojectname$.Repositories.Contracts;
using $safeprojectname$.Repositories.EF.Contracts;

namespace $safeprojectname$.Repositories.EF
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IDbFactory _dbContext;
        internal DbSet<TEntity> dbSet;

        public EfRepository(IDbFactory dbContext)
        {
            this._dbContext = dbContext;
            dbSet = dbContext.GetInstance().Set<TEntity>();
        }

        public TEntity Create(TEntity newEntity)
        => dbSet.Add(newEntity);


        public TEntity Delete(TEntity entity)
        {
            if (_dbContext.GetInstance().Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            return dbSet.Remove(entity);
        }

        public IEnumerable<TEntity> DeleteMultiple(IEnumerable<TEntity> entities)
        => dbSet.RemoveRange(entities);


        public TEntity GetById(params object[] keys)
        => dbSet.Find(keys);

        public TEntity Single(Expression<Func<TEntity, bool>> filter)
        => dbSet.FirstOrDefault(filter);

        public IQueryable<TEntity> Get()
        => dbSet.AsQueryable();

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        => dbSet.Where(filter);

        public IQueryable<TEntity> Get<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> sort, bool isDesending = false)
        {
            if (isDesending)
            {
                return dbSet.Where(filter).OrderByDescending(sort);
            }
            return dbSet.Where(filter).OrderBy(sort);
        }

        public IQueryable<TResult> Get<TKey, TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> sort, bool isDesending, Expression<Func<TEntity, TResult>> selector)
        {
            if (isDesending)
            {
                return dbSet.Where(filter).OrderByDescending(sort).Select(selector);
            }
            return dbSet.Where(filter).OrderBy(sort).Select(selector);
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            _dbContext.GetInstance().Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<TEntity> GetWithPaging(int page = 1, int pageSize = 20)
        => dbSet.Skip((page - 1) * pageSize).Take(pageSize);


        public IQueryable<TEntity> GetWithPaging(Expression<Func<TEntity, bool>> filter, int page = 1, int pageSize = 20)
        => dbSet.Where(filter).Skip((page - 1) * pageSize).Take(pageSize);

        public IQueryable<TEntity> GetWithPaging<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> sort, bool isDesending = false, int page = 1, int pageSize = 20)
        {
            if (isDesending)
            {
                return dbSet.Where(filter).OrderByDescending(sort).Skip((page - 1) * pageSize).Take(pageSize);
            }
            return dbSet.Where(filter).OrderBy(sort).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IQueryable<TResult> GetWithPaging<TKey, TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> sort, bool isDesending, Expression<Func<TEntity, TResult>> selector, int page = 1, int pageSize = 20)
        {
            if (isDesending)
            {
                return dbSet.Where(filter)
                    .OrderByDescending(sort)
                    .Select(selector)
                    .Skip((page - 1) * pageSize).Take(pageSize);
            }
            return dbSet.Where(filter)
                    .OrderBy(sort)
                    .Select(selector)
                    .Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
