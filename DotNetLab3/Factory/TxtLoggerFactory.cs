using DotNetLab3.Logger;

namespace DotNetLab3.Factory
{
    class TxtLoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new TxtLogger();
        }
    }
}
