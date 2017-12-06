using System;
using System.Collections.Generic;
using DumbLogger.Configuration;
using DumbLogger.LogWriters;
using System.IO;

namespace DumbLogger
{
    /// <remarks>Class which creates logger instances, configure them, and manage all created loggers.</remarks>
    public class LogManager
    {
        private static Dictionary<string, LogWriter> activeLoggers = new Dictionary<string, LogWriter>();

        public enum OpenLogMode
        {
            Cleare,
            Continue
        }

        public static LogWriter GetLogger(string name, OpenLogMode openLogMode = OpenLogMode.Continue)
        {
            if (activeLoggers.ContainsKey(name))
            {
                Console.WriteLine($"Logger with requested name : {name} already was created. You can log in the same log file.");
                return activeLoggers[name];
            }

            LogConfig logConfigDefault = new LogConfig(name);

            LogConfigManager.AddLogConfig(logConfigDefault);

            LogWriter logger;

            switch (logConfigDefault.LogFormat)
            {
                case LogFormatEnum.Txt:
                    logger = new LogWriterPlain(logConfigDefault);
                    break;
                case LogFormatEnum.Xml:
                    logger = new LogWriterXml(logConfigDefault);
                    break;
                case LogFormatEnum.Json:
                    logger = new LogWriterJson(logConfigDefault);
                    break;
                default:
                    throw new Exception($"Log Writer : {Enum.GetName(typeof(LogFormatEnum), logConfigDefault.LogFormat)} is not implemented");
            }

            CreateLogFile(logConfigDefault);

            activeLoggers.Add(name, logger);
            Console.WriteLine($"Logger (default configuration) with the name : {name} was created and processed");

            return logger;
        }

        public static LogWriter GetLogger(LogConfig logConfig)
        {
            if (activeLoggers.ContainsKey(logConfig.LogName))
            {
                Console.WriteLine("Logger with requested name : {name} already exist. You can not create a new one with the same name");
                return null;
            }

            LogConfigManager.AddLogConfig(logConfig);

            LogWriter logger;

            switch (logConfig.LogFormat)
            {
                case LogFormatEnum.Txt:
                    logger = new LogWriterPlain(logConfig);
                    break;
                case LogFormatEnum.Xml:
                    logger = new LogWriterXml(logConfig);
                    break;
                case LogFormatEnum.Json:
                    logger = new LogWriterJson(logConfig);
                    break;
                default:
                    throw new Exception($"Log Writer : {Enum.GetName(typeof(LogFormatEnum), logConfig.LogFormat)} is not implemented");
            }

            CreateLogFile(logConfig);

            activeLoggers.Add(logConfig.LogName, logger);

            Console.WriteLine($"Logger (manual configuration) with the name : {logConfig.LogName} was created and processed");
            return logger;
        }
        private static void CreateLogFile(LogConfig logConfig)
        {
            string logFileFullName = logConfig.LogDirectory + @"\" + logConfig.logFileName;

            FileInfo configFile = new FileInfo(logFileFullName);

            if (!configFile.Exists)
            {
                Console.WriteLine($"Config file was created");
                configFile.Create().Dispose();
            }
            else
            {
                Console.WriteLine("Config file already exist. I will be cleaned!!!");
                using (FileStream fileStream = configFile.Open(FileMode.Open))
                {
                    fileStream.SetLength(0);
                }
            }
        }

    }

}

