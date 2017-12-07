using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DumbLogger;
using DumbLogger.Configuration;


namespace TestDumbLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            LogWriter firstLogger = LogManager.GetLogger("First");

            LogConfig logConfig = new LogConfig()
            {
                LogName="ManualLogger",
                LogDirectory= @"D:\Logger",
                LogFormat = LogFormatEnum.Txt,
                LogLevel = LogLevelEnum.Error,
                logFileName = "MyFirstLogger.txt"
            }

            LogWriter manualLogger = LogManager.GetLogger(logConfig);

            try
            {

            }
            catch (Exception e)
            {
                manualLogger.Debug("Log message");
                throw;
            }
            manualLogger.Debug("Log message");

            
            


            firstLogger.Debug("First message", new Exception("exception_message"));
            
            firstLogger.Error("First message", new Exception("exception_message"));

            Console.ReadLine();
        }

    }


}
