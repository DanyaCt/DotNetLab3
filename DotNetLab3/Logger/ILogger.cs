using DotNetLab3.Entities;

namespace DotNetLab3.Logger
{
    public interface ILogger
    {
        public void Write(LogEvent logEvent);
        public IEnumerable<LogEvent>? GetLogs();
    }
}