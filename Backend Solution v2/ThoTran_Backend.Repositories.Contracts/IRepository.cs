using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace $safeprojectname$.Repositories.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> Get<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> sort, bool isDesending = false);
        IQueryable<TResult> Get<TKey, TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> sort, bool isDesending, Expression<Func<TEntity, TResult>> selector);
        TEntity GetById(params object[] keys);
        TEntity Single(Expression<Func<TEntity, bool>> filter);
        TEntity Create(TEntity newEntity);
        TEntity Delete(TEntity entity);
        IEnumerable<TEntity> DeleteMultiple(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        IQueryable<TEntity> GetWithPaging(int page = 1, int pageSize = 20);
        IQueryable<TEntity> GetWithPaging(Expression<Func<TEntity, bool>> filter, int page = 1, int pageSize = 20);
        IQueryable<TEntity> GetWithPaging<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> sort, bool isDesending = false, int page = 1, int pageSize = 20);
        IQueryable<TResult> GetWithPaging<TKey, TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> sort, bool isDesending, Expression<Func<TEntity, TResult>> selector, int page = 1, int pageSize = 20);
    }
}
