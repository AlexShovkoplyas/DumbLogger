using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DumbLogger;
using DumbLogger.Configuration;
using DumbLogger.LogReaders;

namespace TestDumbLogger
{
    class Program
    {
        static void Main(string[] args)
        {

            LogConfig logConfig = new LogConfig("ManualLogger", logFormat: LogFormatEnum.Json);

            LogWriter jsonLogger = LogManager.GetLogger(logConfig);

            jsonLogger.Debug("Message");
            jsonLogger.Fatal("Message 2", new Exception("some error"), methodPath : "SuperApp");

            LogReaderJson reader = new LogReaderJson(logConfig);

            reader.GetLogData();

            //LogConfig xmlConfig = new LogConfig("ManualLogger2", logFormat: LogFormatEnum.Xml);

            //LogWriter xmlLogger = LogManager.GetLogger(xmlConfig);

            //jsonLogger.Debug("Message");
            //jsonLogger.Fatal("Message 2", new Exception("some error"), methodPath: "SuperApp");

            Console.ReadKey();

        }

    }


}
