using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Core.ControllerTemplates.DataAccessInterfaces
{
    public interface IReadDataAccessService<T>
    {
        Task<T> Get(long key);

        Task<T> Get(int key);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetDataByFilter(string table = "", params KeyValuePair<string, string>[] filter);

        Task<IEnumerable<T>> GetDataByFilter(params KeyValuePair<string, string>[] filter);

        Task<IEnumerable<T>> GetDataByFilter(object filter, string table = "");

    }
}
