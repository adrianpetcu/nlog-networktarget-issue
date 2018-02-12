using NLog;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLogConsole
{
    class Program
    {
        static void Main(string[] args)
        {            
            Logger logger = LogManager.GetLogger("InfoLogger");

            //logging data from an expando object
            LogEventInfo eventInfo = GetLogEvent();
            logger.Info(eventInfo);
         
            Console.WriteLine("Logging done. Press any key to exit");
            Console.Read();
        }


        private static LogEventInfo GetLogEvent()
        {
            //construct object
            IDictionary<string, object> loggedObject = new ExpandoObject();
            loggedObject.Add("dbResponseTime", 50);
            loggedObject.Add("messagesSentTotal", 100);

            LogEventInfo eventInfo = new LogEventInfo(LogLevel.Info, "InfoLogger", "Test");
            foreach (var pair in loggedObject)
            {
                eventInfo.Properties.Add(pair.Key, pair.Value);
            }
            return eventInfo;
        }
    }
}
