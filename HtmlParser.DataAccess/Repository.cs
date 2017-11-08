using HtmlParser.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlParser.DataAccess
{
    public class ParserRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        DbContext _context;
        DbSet<TEntity> _dbSet;

        public ParserRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await Task.Run(()=> {
               return _dbSet.AsNoTracking().ToList() as IEnumerable<TEntity>;
            }); 
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate)
        {
            return await Task.Run(() => {
                return _dbSet.AsNoTracking().Where(predicate).ToList() as IEnumerable<TEntity>;
            });
        }

        public async Task AddAsync(TEntity item)
        {
            await Task.Run(() => {
                _dbSet.Add(item);
                _context.SaveChanges();
            });
        }

        public async Task RemoveAsync(long elementId)
        {
            TEntity element = await FindByIdAsync(elementId) as TEntity;
            await RemoveAsync(element);
        }
        public async Task RemoveAsync(TEntity element)
        {
            await Task.Run(()=> {
                _dbSet.Remove(element);
            });
        }
        public async Task RemoveRangeAsync(params long[] elementsIds)
        {
            List<TEntity> elements = new List<TEntity>();
            TEntity element;
                for (int i = 0; i < elementsIds.Length; i++)
                {
                element = await FindByIdAsync(elementsIds[i]);
                   elements.Add(element);
                }
            await RemoveRangeAsync(elements);
        }
        public async Task RemoveRangeAsync(IEnumerable<TEntity> elements)
        {
            await Task.Run(() => {
                _dbSet.RemoveRange(elements);
            });
        }

        public async Task<TEntity> FindByIdAsync(long elementId)
        {
            return await _dbSet.FindAsync(elementId);
        }

    }
}
