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
            LogConfig.SetDefaultValues(logDirectory: @"D:\",logFormat: LogFormatEnum.Csv, logLevel: LogLevelEnum.Fatal);

            Console.WriteLine();
            Console.WriteLine("===== Logger with default configuration =====");
            LogWriter DefaultLogger = LogManager.GetLogger("LoggerName");
            LogWriter DefaultLogger2 = LogManager.GetLogger("LoggerName");
            Console.WriteLine($"DefaultLogger is the same logger as DefaultLogger2 ? - {DefaultLogger== DefaultLogger2}" );

            Console.WriteLine();
            Console.WriteLine("===== Logger with custom configuration =====");

            LogConfig logConfig = new LogConfig(
                logName : "ManualLogger",
                logFormat: LogFormatEnum.Csv,
                logLevel: LogLevelEnum.Error,
                logFileName: "MyFirstLogger.csv"
            );
            LogWriter manualLogger = LogManager.GetLogger(logConfig);


            manualLogger.Debug("Log message Debug");
            manualLogger.Error("Log message Error");
            var e = new Exception("Error msg");
            manualLogger.Fatal("Log message Fatal", e);

            manualLogger.ReadLogFile();

            Console.WriteLine();
            Console.WriteLine("===== Logger with wrong configuration =====");

            LogConfig logConfigWrong = new LogConfig(            
                logName : "WrongLogger",
                logDirectory : @"DDD:\",
                logFormat : LogFormatEnum.Json
            );
            LogWriter wrongLogger = LogManager.GetLogger(logConfigWrong);

            wrongLogger?.Debug("Log message Debug");
            wrongLogger?.Error("Log message Error");
            var e2 = new Exception("Error msg");
            wrongLogger?.Fatal("Log message Fatal", e2);

            wrongLogger?.ReadLogFile();

            Console.ReadKey();           

        }

    }


}
