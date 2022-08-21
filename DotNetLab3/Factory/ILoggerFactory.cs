using DotNetLab3.Logger;

namespace DotNetLab3.Factory
{
    public interface ILoggerFactory
    {
        public ILogger CreateLogger();
    }
}
