using HSB.Domain.Contracts;
using NLog;

namespace HSB.Infrastructure.Logger
{
	public class LoggerManager : ILoggerManager
	{
		private readonly static ILogger _logger = LogManager.GetCurrentClassLogger();
		public void LogError(string message) => _logger.Error(message);
		
	}
}
