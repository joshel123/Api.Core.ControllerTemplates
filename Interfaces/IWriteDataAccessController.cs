using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Api.Core.ControllerTemplates.Interfaces
{
    public interface IWriteAccess<in TEntity, TReturn> where TEntity : class
    {
        [HttpPost("Insert")]
        Task<TReturn> Insert([FromBody] TEntity request);

        [HttpPost("InsertMany")]
        Task<TReturn> InsertMany([FromBody] IEnumerable<TEntity> request);

        [HttpPost("Update")]
        Task<TReturn> Update([FromBody] TEntity request);

        [HttpPost("UpdateMany")]
        Task<IActionResult> UpdateMany([FromBody] IEnumerable<TEntity> request);

        [HttpPost("Delete")]
        Task<IActionResult> Delete([FromBody] TEntity request);

        [HttpPost("DeleteMany")]
        Task<IActionResult> DeleteMany([FromBody] IEnumerable<TEntity> request);

    }
}
