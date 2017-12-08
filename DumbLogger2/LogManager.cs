using System;
using System.Collections.Generic;
using DumbLogger.Configuration;
using DumbLogger.LogWriters;
using System.IO;
using System.Text;

namespace DumbLogger
{
    /// <remarks>Class which creates logger instances, configure them, and manage all created loggers.</remarks>
    public class LogManager
    {
        private static Dictionary<string, LogWriter> activeLoggers = new Dictionary<string, LogWriter>();

        public static LogWriter GetLogger(string name, bool clearLogFile = true)
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

            if (true)
            {

            }
            CreateLogFile(logConfigDefault, clearLogFile);

            activeLoggers.Add(name, logger);
            Console.WriteLine($"Logger (default configuration) with the name : {name} was created and processed");

            return logger;
        }

        public static LogWriter GetLogger(LogConfig logConfig, bool clearLogFile = true)
        {
            if (activeLoggers.ContainsKey(logConfig.LogName))
            {
                Console.WriteLine($"Logger with requested name : {logConfig.LogName} already exist. You can not create a new one with the same name");
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

            CreateLogFile(logConfig, clearLogFile);

            activeLoggers.Add(logConfig.LogName, logger);

            Console.WriteLine($"Logger (manual configuration) with the name : {logConfig.LogName} was created and processed");
            return logger;
        }
        private static void CreateLogFile(LogConfig logConfig, bool clearLogFile)
        {
            string logFileFullName = logConfig.LogDirectory + @"\" + logConfig.LogFileName;

            FileInfo configFile = new FileInfo(logFileFullName);

            if (!configFile.Exists)
            {
                Console.WriteLine($"Config file was created");
                using (FileStream fileStream = configFile.Create())
                {
                    SetUpLogFile(fileStream, logConfig);
                }
            }
            else
            {
                if (clearLogFile)
                {
                    Console.WriteLine("Config file already exist. I will be cleaned!!!");
                    using (FileStream fileStream = configFile.Open(FileMode.Open))
                    {
                        fileStream.SetLength(0);
                        SetUpLogFile(fileStream, logConfig);
                    }
                }                
            }
        }

        private static void SetUpLogFile(FileStream fileStream, LogConfig logConfig)
        {
            string initialString = "";
            //byte[] initialByteArray = null;
            //UnicodeEncoding uniEncoding = new UnicodeEncoding();

            switch (logConfig.LogFormat)
            {
                case LogFormatEnum.Txt:
                    break;
                case LogFormatEnum.Xml:
                    break;
                case LogFormatEnum.Json:
                    initialString = "[" + Environment.NewLine + "]";
                    //initialByteArray = Encoding.ASCII.GetBytes(initialString);
                    break;
                default:
                    break;
            }
            byte[] initialBytes = Encoding.Default.GetBytes(initialString);
            fileStream.Write(initialBytes, 0, initialBytes.Length);
        }
    }

}

