using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagementAPI.Tests
{
    public class LoggerTest
    {
        private readonly ILogger _logger;

        public LoggerTest(ILogger logger)
        {
            _logger = logger;
            var message = $" LogTest logger created at {DateTime.UtcNow.ToLongTimeString()}";
            _logger.LogInformation(message);
        }
    }
}
