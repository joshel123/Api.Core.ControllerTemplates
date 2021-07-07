using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Api.Core.ControllerTemplates.Interfaces
{
    public interface IWriteDataAccessController<in T> where T : class
    {
        [HttpPost("Insert")]
        Task<IActionResult> Insert([FromBody] T request);

        [HttpPost("InsertMany")]
        Task<IActionResult> InsertMany([FromBody] IEnumerable<T> request);

        [HttpPost("Update")]
        Task<IActionResult> Update([FromBody] T request);

        [HttpPost("UpdateMany")]
        Task<IActionResult> UpdateMany([FromBody] IEnumerable<T> request);

        [HttpPost("Delete")]
        Task<IActionResult> Delete([FromBody] T request);

        [HttpPost("DeleteMany")]
        Task<IActionResult> DeleteMany([FromBody] IEnumerable<T> request);

    }
}
