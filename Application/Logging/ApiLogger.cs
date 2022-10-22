using Application.Interfaces;
using Application.Models;
using System.Text.Json;

namespace Application.Logging
{
    public class ApiLogger : IApiLogger
    {
        private readonly ILoggerManager logger;
        public ApiLogger(ILoggerManager logger)
        {
            this.logger = logger;
            logger.SetLogger("ECommerceServiceRequestResponseLog");
        }

        public void Log(LogDetail logDetail)
        {
            logger.LogInfo(JsonSerializer.Serialize(logDetail));
        }
    }
}
