using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Core.ControllerTemplates.DataAccessInterfaces
{
    public interface IWriteDataAccessService<T>
    {
        Task<long> Insert(T entity);

        Task<long> Insert(IEnumerable<T> entities);

        Task<long> BulkInsert(IEnumerable<T> entities);

        Task<bool> Delete(T entity);

        Task<bool> Delete(IEnumerable<T> entities);

        Task<bool> Update(T entity);

        Task<bool> Update(IEnumerable<T> entities);
    }
}
