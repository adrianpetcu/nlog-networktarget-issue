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
                        
            LogEventInfo eventInfo = new LogEventInfo(LogLevel.Info, "InfoLogger", "Test");
            eventInfo.Properties.Add("dbResponseTime", 50);
            eventInfo.Properties.Add("messagesSentTotal", 100);
            logger.Info(eventInfo);
         
            Console.WriteLine("Logging done. Press any key to exit");
            Console.Read();
        }
    }
}
