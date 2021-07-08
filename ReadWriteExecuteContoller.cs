using Api.Core.ControllerTemplates.Interfaces;
using Api.Core.ControllerTemplates.DataAccessInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Core.ControllerTemplates
{
    [Route("api/[controller]")]
    public class ReadWriteExecuteContoller<T> : BaseControllerTemplate<T>, IReadOnlyAccess<T, IActionResult>, IWriteAccess<T, IActionResult>, IExecuteAccess<T, IActionResult> where T : class
    {
        private readonly IReadWriteExecuteDataAccessService<T> _dataService;
        private readonly ReadControllerTemplate<T> _readCtrl;
        private readonly WriteControllerTemplate<T> _writeCtrl;
        private readonly ExecuteControllerTemplate<T> _executeCtrl;


        public ReadWriteExecuteContoller(IReadWriteExecuteDataAccessService<T> dataService = null, IConfiguration config = null, ILogger logger = null) : base(config, logger)
        {
            _dataService = dataService;
            _readCtrl = new ReadControllerTemplate<T>(dataService, config, logger);
            _writeCtrl = new WriteControllerTemplate<T>(dataService, config, logger);
            _executeCtrl = new ExecuteControllerTemplate<T>(dataService, config, logger);
        }

        public Task<IActionResult> Delete([FromBody] T request)
        {
            return _writeCtrl.Delete(request);
        }

        public Task<IActionResult> DeleteMany([FromBody] IEnumerable<T> request)
        {
            return _writeCtrl.DeleteMany(request);
        }

        public Task<IActionResult> Get(int id)
        {
            return _readCtrl.Get(id);
        }

        public Task<IActionResult> GetAll()
        {
            return _readCtrl.GetAll();
        }

        public Task<IActionResult> GetByFilter([FromBody] params KeyValuePair<string, object>[] parameters)
        {
            return _readCtrl.GetByFilter(parameters);
        }

        public Task<IActionResult> GetWithProcedure(string storedProcedure, [FromBody] params KeyValuePair<string, object>[] parameters)
        {
            return _executeCtrl.GetWithProcedure(storedProcedure, parameters);
        }

        public Task<IActionResult> Insert([FromBody] T request)
        {
            return _writeCtrl.Insert(request);
        }

        public Task<IActionResult> InsertMany([FromBody] IEnumerable<T> request)
        {
            return _writeCtrl.InsertMany(request);
        }

        public Task<IActionResult> Update([FromBody] T request)
        {
            return _writeCtrl.Update(request);
        }

        public Task<IActionResult> UpdateMany([FromBody] IEnumerable<T> request)
        {
            return _writeCtrl.UpdateMany(request);
        }
    }
}
