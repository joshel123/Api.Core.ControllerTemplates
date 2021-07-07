using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Api.Core.ControllerTemplates.Interfaces
{
    public interface IReadOnlyDataController<in T> where T : class
    {
        [HttpGet("GetAll")]
        Task<IActionResult> GetAll();

        [HttpGet("Get/{id}")]
        Task<IActionResult> Get(int id);

        [HttpPost("GetByFilter")]
        Task<IActionResult> GetByFilter([FromBody] params KeyValuePair<string, object>[] parameters);

    }
}

