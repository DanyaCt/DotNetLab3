namespace DotNetLab3.Entities
{
    public class LogEvent
    {
        public LogLevel LogLevel { get; set; }
        public string Source { get; set; }
        public DateTimeOffset EventDateTime { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return $"Level of importance: {LogLevel}\nSource: {Source}\n" +
                $"Event time: {EventDateTime.DateTime}\nMessage: {Message}\n";
        }
    }
}
