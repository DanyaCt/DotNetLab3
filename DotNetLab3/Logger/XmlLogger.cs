using DotNetLab3.Entities;
using System.Xml.Linq;

namespace DotNetLab3.Logger
{
    public class XmlLogger : ILogger
    {
        private const string Path = "../../../Files/XmlLog.xml";
        public void Write(LogEvent logEvent)
        {
            var xDoc = XElement.Load(Path);
            xDoc.Add(
                new XElement("Event",
                    new XElement("LogLevel", logEvent.LogLevel.ToString()),
                    new XElement("Source", logEvent.Source),
                    new XElement("EventDateTime", logEvent.EventDateTime.ToString()),
                    new XElement("Message", logEvent.Message)));
            xDoc.Save(Path);
        }
        public IEnumerable<LogEvent>? GetLogs() 
        {
            var xDoc = XDocument.Load(Path);
            return xDoc.Element("Events")?
                .Elements("Event")            
                .Select(p => new LogEvent
                {
                    LogLevel = (LogLevel)Enum.Parse(typeof(LogLevel), p.Element("LogLevel")?.Value) ,
                    Source = p.Element("Source")?.Value,
                    EventDateTime = Convert.ToDateTime(p.Element("EventDateTime")?.Value),
                    Message = p.Element("Message")?.Value
                });
        }
    }
}
