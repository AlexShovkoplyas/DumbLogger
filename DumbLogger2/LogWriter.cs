
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DumbLogger.Configuration;

namespace DumbLogger
{
    /// <remarks>
    /// General functionality of logger class
    /// 
    /// </remarks>
    public abstract class LogWriter
    {     
        public LogWriter(LogConfig logConfig)
        {
            Config = logConfig;
            logFilePath = Config.LogDirectory + @"\" + Config.LogFileName;
        }

        protected string logFilePath;
        public virtual LogConfig Config { get; set; }

        public abstract void LogWrite(LogParameters logInfo);

        public void Debug(string message, Exception e = null, string appName = "", string className = "", string methodPath = "")
        {
            if (Config.LogLevel>LogLevelEnum.Debug)
            {
                return;
            }

            LogWrite(new LogParameters()
            {
                Message = message,
                LogLevel = LogLevelEnum.Debug,
                Error = e?.ToString(),
                Application = appName,
                ClassName = className,
                MethodPath = methodPath
            });
        }

        public void Error(string message, Exception e = null, string appName = "", string className = "", string methodPath = "")
        {
            if (Config.LogLevel > LogLevelEnum.Error)
            {
                return;
            }

            LogWrite(new LogParameters()
            {
                Message = message,
                LogLevel = LogLevelEnum.Error,
                Error = e?.ToString(),
                Application = appName,
                ClassName = className == "" ? this.GetType().FullName : className,
                MethodPath = methodPath == "" ? System.Reflection.MethodBase.GetCurrentMethod().Name : methodPath
            });
        }

        public void Fatal(string message, Exception e = null, string appName = "", string className = "", string methodPath = "")
        {
            LogWrite(new LogParameters()
            {
                Message = message,
                LogLevel = LogLevelEnum.Fatal,
                Error = e?.ToString(),
                Application = appName,
                ClassName = className == "" ? this.GetType().FullName : className,
                MethodPath = methodPath == "" ? System.Reflection.MethodBase.GetCurrentMethod().Name : methodPath
            });
        }

        public void ReadLogFile()
        {
            LogReader.ReadLogFile(Config);
        }
    }
}



