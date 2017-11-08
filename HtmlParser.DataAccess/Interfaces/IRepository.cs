using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HtmlParser.DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity item);
        Task<TEntity> FindByIdAsync(long elementId);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate);
        Task RemoveAsync(long elementId);
        Task RemoveAsync(TEntity element);
        Task RemoveRangeAsync(params long[] elementsIds);
        Task RemoveRangeAsync(IEnumerable<TEntity> elements);
    }
}
