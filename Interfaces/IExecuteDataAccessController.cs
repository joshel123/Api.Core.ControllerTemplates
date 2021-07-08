using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Api.Core.ControllerTemplates.Interfaces
{
    public interface IExecuteAccess<in TEntity, TReturn> where TEntity : class
    {
        [HttpPost("GetWithProcedure/{storedProcedure}")]
        Task<TReturn> GetWithProcedure(string storedProcedure, [FromBody] params KeyValuePair<string, object>[] parameters);
    }
}
