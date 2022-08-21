using DotNetLab3.Logger;

namespace DotNetLab3.Factory
{
    class XmlLoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new XmlLogger();
        }
    }
}
