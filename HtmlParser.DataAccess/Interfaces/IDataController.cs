using System.Collections.Generic;
using System.Threading.Tasks;

namespace HtmlParser.DataAccess.Interfaces
{
    public interface IDataController<TParse, TTag>
        where TParse : class
        where TTag : class
    {
        Task AddDataAsync(TParse parsing);
        Task<IEnumerable<TParse>> GetAllDataAsync();
        Task<IEnumerable<TTag>> GetTagsAsync();
        Task<TTag> GetTagByIdAsync(long tagId);
        Task RemoveDataAsync<TEntity>(long elementId) where TEntity: class;
    }
}
