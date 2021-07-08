﻿using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;

namespace Api.Core.ControllerTemplates
{
    [ApiController]
    public abstract class BaseControllerTemplate<T>
    {      
        protected readonly ILogger _logger;

        protected readonly IConfiguration _configuration;
       
        protected BaseControllerTemplate(IConfiguration config, ILogger logger)
        {
            _configuration = config;
            _logger = logger;
        }

        /// <summary>
        /// Prints the exposed APIs for this controller.
        /// Not meant to be consumed, for testing purposes only.
        /// </summary>
        /// <returns>Formatted text with exposed API endpoints.</returns>
        [HttpGet("Test")]
        public virtual IActionResult Test()
        {            
            var sb = new StringBuilder();
            var methods = GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            string partition = $"------------------------------\n";

            //header 
            sb.Append(partition);
            sb.Append($"Service Name: {GetType().Name}<{typeof(T).GetType().Name}>\n");
            sb.Append(partition);

            //body
            foreach(var m in methods)
                sb.Append($"public {m.ReturnType.Name} {m.Name}\n");
            
            //footer
            sb.Append(partition);

            return new OkObjectResult(sb.ToString());
        }

        protected virtual void TryLogException(Exception ex, [CallerMemberName] string callerName = "")
        {
            if (_logger != null)
                _logger.Log(LogLevel.Error, ex, GetLoggerMessege(callerName));
        }

        private string GetLoggerMessege(string rootMethod) =>
            $"{GetType().Name}<{typeof(T).Name}> -> {rootMethod}<{typeof(T).Name}>";
    }
}
