using Microsoft.Extensions.Logging;

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
