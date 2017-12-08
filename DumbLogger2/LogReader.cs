using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using DumbLogger.Configuration;
using System.IO;

namespace DumbLogger
{
    public static class LogReader
    {
        static string logFilePath;

        public static void ReadLogFile(LogConfig logConfig)
        {
            logFilePath = logConfig.LogDirectory + @"\" + logConfig.LogFileName;

            switch (logConfig.LogFormat)
            {
                case LogFormatEnum.Txt:
                    ReadPlain();
                    break;
                case LogFormatEnum.Xml:
                    ReadXml();
                    break;
                case LogFormatEnum.Json:
                    ReadJson();
                    break;
                default:
                    break;
            }
        }

        private static void ReadJson()
        {
            List<LogParameters> logData = new List<LogParameters>();
            var serializer = new DataContractJsonSerializer(typeof(List<LogParameters>));

            using (FileStream fileStream = new FileStream(logFilePath, FileMode.Open))
            {
                logData = (List<LogParameters>)serializer.ReadObject(fileStream);
            }

            ConsoleOutput(logData);
        }

        private static void ReadXml()
        {
            throw new NotImplementedException();
        }

        private static void ReadPlain()
        {
            throw new NotImplementedException();
        }

        private static void ConsoleOutput(List<LogParameters> logData)
        {
            foreach (var param in logData)
            {
                Console.WriteLine(param.Message);
            }
        }
    }
}
