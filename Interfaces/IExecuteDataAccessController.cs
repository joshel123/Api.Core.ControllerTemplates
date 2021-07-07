using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Api.Core.ControllerTemplates.Interfaces
{
    public interface IExecuteDataAccessController<in T> where T : class
    {
        [HttpPost("GetWithProcedure/{storedProcedure}")]
        Task<IActionResult> GetWithProcedure(string storedProcedure, [FromBody] params KeyValuePair<string, object>[] parameters);
    }
}
