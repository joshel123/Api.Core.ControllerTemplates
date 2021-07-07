using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Core.ControllerTemplates.DataAccessInterfaces
{
    public interface IExecuteDataAccessService<T>
    {
        Task ExecuteProc(string proc, object parameters);

        Task ExecuteStatement(string statement, object parameters);

        Task<IEnumerable<T>> GetDataWithQuery(string query, object parameters);

        Task<IEnumerable<T>> GetDataWithProc(string proc, object parameters);

    }
}
