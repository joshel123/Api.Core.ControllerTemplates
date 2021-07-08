using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Core.ControllerTemplates.DataAccessInterfaces;
using Microsoft.Extensions.Configuration;
using Api.Core.ControllerTemplates.Interfaces;

namespace Api.Core.ControllerTemplates
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriteControllerTemplate<T> : BaseControllerTemplate<T>, IWriteAccess<T, IActionResult> where T : class
    {
         private readonly IWriteDataAccessService<T> _dataService;

         public WriteControllerTemplate(IWriteDataAccessService<T> dataService = null, IConfiguration config = null, ILogger logger = null) : base(config, logger)
         {
             _dataService = dataService;
         }

       
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] T request)
        {
            bool resp = false;

            try
            {
                resp = await _dataService.Update(request);
            }
            catch (Exception ex)
            {
                TryLogException(ex);
            }

            return new OkObjectResult(resp);        
        }


        [HttpPost("UpdateMany")]
        public async Task<IActionResult> UpdateMany([FromBody] IEnumerable<T> request)
        {
            bool resp = false;

            try
            {
                resp = await _dataService.Update(request);
            }
            catch (Exception ex)
            {
                TryLogException(ex);
            }

            return new OkObjectResult(resp);
        }

    

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] T request)
        {
            long resp = 0;

            try
            {
                resp = await _dataService.Insert(request);
            }
            catch (Exception ex)
            {
                TryLogException(ex);
            }

            return new OkObjectResult(resp);
        }


        [HttpPost("InsertMany")]
        public async Task<IActionResult> InsertMany([FromBody] IEnumerable<T> request)
        {
            long resp = 0;

            try
            {
                resp = await _dataService.Insert(request);
            }
            catch (Exception ex)
            {
                TryLogException(ex);
            }

            return new OkObjectResult(resp);
        }


        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] T request)
        {
            bool resp = false;

            try
            {
                resp = await _dataService.Delete(request);            
            }
            catch (Exception ex)
            {
                TryLogException(ex);
            }

            return new OkObjectResult(resp);
        }

        [HttpPost("DeleteMany")]
        public async Task<IActionResult> DeleteMany([FromBody] IEnumerable<T> request)
        {
            bool resp = false;

            try
            {
                resp = await _dataService.Delete(request);
            }
            catch (Exception ex)
            {
                TryLogException(ex);
            }

            return new OkObjectResult(resp);
        }
    }
}