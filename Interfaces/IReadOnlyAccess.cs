using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Api.Core.ControllerTemplates.Interfaces
{
    public interface IReadOnlyAccess<in TEntity, TReturn> where TEntity : class
    {
        [HttpGet("GetAll")]
        Task<TReturn> GetAll();

        [HttpGet("Get/{id}")]
        Task<TReturn> Get(int id);

        [HttpPost("GetByFilter")]
        Task<TReturn> GetByFilter([FromBody] params KeyValuePair<string, object>[] parameters);
    }
}

