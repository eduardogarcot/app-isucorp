using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Backend.Core.Repositories
{
    interface IRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity Entity);
        void Remove(TEntity Entity);
    }
}
