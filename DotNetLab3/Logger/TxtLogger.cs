using DotNetLab3.Entities;

namespace DotNetLab3.Logger
{
    public class TxtLogger : ILogger
    {
        private const string Path = "../../../Files/TxtLog.txt";
        public void Write(LogEvent logEvent)
        {
            var text = $"{logEvent.LogLevel}\n{logEvent.Source}" +
                $"\n{logEvent.EventDateTime.DateTime}\n{logEvent.Message}";

            var appendText = text + Environment.NewLine;
            File.AppendAllText(Path, appendText);
        }
        public IEnumerable<LogEvent>? GetLogs()
        {
            var readText = File.ReadAllText(Path);
            var logs = new List<LogEvent>();
            var ob = readText.Split('\n');
            for (int i = 0; i < ob.Length - 1; i += 4)
            {
                logs.Add(new LogEvent()
                {
                    LogLevel = (LogLevel)Enum.Parse(typeof(LogLevel), ob[i]),
                    Source = ob[i + 1],
                    EventDateTime = Convert.ToDateTime(ob[i + 2]),
                    Message = ob[i + 3]
                });
            }
            return logs;
        }
    }
}
