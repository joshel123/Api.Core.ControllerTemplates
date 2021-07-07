using Api.Core.ControllerTemplates.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Core.ControllerTemplates.DataAccessInterfaces;
using Microsoft.Extensions.Configuration;

namespace Api.Core.ControllerTemplates
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadControllerTemplate<T> : BaseControllerTemplate<T>, IReadOnlyDataController<T> where T : class
    {
        private readonly IReadDataAccessService<T> _dataService;

        public ReadControllerTemplate(IReadDataAccessService<T> dataService = null, IConfiguration config = null, ILogger logger = null) : base(config, logger)
        {
            _dataService = dataService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<T> resp = null;

            try
            {
                resp = await _dataService.GetAll();
            }
            catch (Exception ex)
            {
                TryLogException(ex);
            }

            return new OkObjectResult(resp);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            T resp = null;

            try
            {
                resp = await _dataService.Get(id);
            }
            catch (Exception ex)
            {
                TryLogException(ex);
            }

            return new OkObjectResult(resp);
        }

        [HttpPost("GetByFilter")]


        public async Task<IActionResult> GetByFilter([FromBody] params KeyValuePair<string, object>[] parameters)
        {
            IEnumerable<T> resp = null;

            try
            {
                resp = await _dataService.GetDataByFilter(parameters);
            }
            catch (Exception ex)
            {
                TryLogException(ex);
            }

            return new OkObjectResult(resp);
        }
    }

}


