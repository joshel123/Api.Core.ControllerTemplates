using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Core.ControllerTemplates.DataAccessInterfaces;
using Microsoft.Extensions.Configuration;
using Api.Core.ControllerTemplates.Interfaces;

namespace Api.Core.ControllerTemplates
{

    [Route("api/[controller]")]
    [ApiController]
    public class ExecuteControllerTemplate<T> : BaseControllerTemplate<T>, IExecuteDataAccessController<T> where T : class
    {
        private readonly IExecuteDataAccessService<T> _dataService;

        public ExecuteControllerTemplate(IExecuteDataAccessService<T> dataService = null, IConfiguration config = null, ILogger logger = null) : base(config, logger)
        {
            _dataService = dataService;
        }

        [HttpPost("GetWithProcedure/{storedProcedure}")]
        public async Task<IActionResult> GetWithProcedure(string storedProcedure, [FromBody] params KeyValuePair<string, object>[] parameters)
        {
            IEnumerable<T> resp = null;

            try
            {
                resp = await _dataService.GetDataWithProc(storedProcedure, parameters);
            }
            catch (Exception ex)
            {
                TryLogException(ex);
            }

            return new OkObjectResult(resp);
        }
    }
}
