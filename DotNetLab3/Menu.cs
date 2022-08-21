using DotNetLab3.Entities;
using DotNetLab3.Logger;

namespace DotNetLab3
{
    public class Menu
    {
        private readonly ILogger _txtLogger;
        private readonly ILogger _xmlLogger;
        public Menu(ILogger txtLogger, ILogger xmlLogger)
        {
            _txtLogger = txtLogger;
            _xmlLogger = xmlLogger;
        }
        public void PrintMenu()
        {
            Console.WriteLine("Please enter what you want:\n1 - Create and add a new event into txt file\n" +
                              "2 - Create and add a new event into xml file\n3 - Check last 10 events\n" +
                              "\n0 - Leave the program");
            var key = Console.ReadKey().KeyChar;
            Console.WriteLine();
            LogEvent logEvent;
            switch (key)
            {
                case '0':
                    Environment.Exit(0);
                    break;
                case '1':
                    logEvent = EnterEvent();
                    _txtLogger.Write(logEvent);
                    break;
                case '2':
                    logEvent = EnterEvent();
                    _xmlLogger.Write(logEvent);
                    break;
                case '3':
                    ShowAllEvents();
                    break;
                default:
                    throw new ArgumentException("Wrong key.");
            }
        }

        public void ShowAllEvents()
        {
            Console.Clear();
            var txtlogs = _txtLogger.GetLogs();
            var xmllogs = _xmlLogger.GetLogs();

            var allEventLogs = txtlogs.Concat(xmllogs);
            var query = allEventLogs.OrderByDescending(LogEvent => LogEvent.EventDateTime).Take(10);
            for (var i = 0; i < query.Count(); i++)
            {
                Console.WriteLine($"{i + 1}: {query.ElementAt(i)}\n");
            }
        }

        public LogEvent EnterEvent()
        {
            Console.Clear();
            Console.WriteLine("\nPick level of importance:\n1 - Info\n2 - Warn\n3 - Error");
            var key = Console.ReadKey().KeyChar;
            var loglevel = key switch
            {
                '1' => LogLevel.Info,
                '2' => LogLevel.Warn,
                '3' => LogLevel.Error,
                _ => throw new ArgumentException("Wrong key.")
            };
            Console.WriteLine("\nWrite the source:");
            var source = Console.ReadLine();
            if (source == null)
                throw new ArgumentException("The field is empty.");
            Console.WriteLine("\nWrite the message:");
            var message = Console.ReadLine();
            if (message == null)
                throw new ArgumentException("The field is empty.");
            Console.Clear();
            return new LogEvent()
            {
                LogLevel = loglevel,
                Source = source,
                EventDateTime = DateTimeOffset.Now.DateTime,
                Message = message
            };
        }
    }
}
