
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
        string appName;

        public LogWriter(LogConfig logConfig)
        {
            Config = logConfig;
            appName =  System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        }

        public virtual LogConfig Config
        {
            get;
            set;
        }

        public abstract void LogWrite(LogParameters logInfo);


        public void Debug(string message, Exception e, string className = "", string methodPath ="")
        {
            LogWrite(new LogParameters() {
                Message = message,
                LogLevel = LogLevelEnum.Debug,
                Error = e.ToString(),
                Application = appName,
                ClassName = className == "" ? this.GetType().FullName : className,
                MethodPath = methodPath == "" ? System.Reflection.MethodBase.GetCurrentMethod().Name : methodPath
            });
        }

        public void Error(string message, Exception e, string className = "", string methodPath = "")
        {
            LogWrite(new LogParameters()
            {
                Message = message,
                LogLevel = LogLevelEnum.Error,
                Error = e.ToString(),
                Application = appName,
                ClassName = className == "" ? this.GetType().FullName : className,
                MethodPath = methodPath == "" ? System.Reflection.MethodBase.GetCurrentMethod().Name : methodPath
            });
        }

        public void Fatal(string message, Exception e=null, string className = "", string methodPath = "")
        {
            LogWrite(new LogParameters()
            {
                Message = message,
                LogLevel = LogLevelEnum.Fatal,
                Error = e.ToString(),
                Application = appName,
                ClassName = className == "" ? this.GetType().FullName : className,
                MethodPath = methodPath == "" ? System.Reflection.MethodBase.GetCurrentMethod().Name : methodPath
            });
        }

    }
}



