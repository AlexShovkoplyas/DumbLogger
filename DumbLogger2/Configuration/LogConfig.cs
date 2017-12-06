
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DumbLogger.Configuration
{
    /// <remarks>Specifies what can be configured in logger.</remarks>
    [Serializable]
    public class LogConfig
    {
        public LogConfig() { }

        public LogConfig(string logName)
        {
            LogName = logName;
            LogDirectory = Directory.GetCurrentDirectory();
            LogLevel = LogLevelEnum.Debug;
            LogFormat = LogFormatEnum.Xml;
            logFileName = logName + "." + Enum.GetName(typeof(LogFormatEnum), LogFormat);
        }

        [XmlAttribute]
        public string LogName { get; set; }

        public string LogDirectory
        {
            get;
            set;
        }

        public LogLevelEnum LogLevel
        {
            get;
            set;
        }

        public LogFormatEnum LogFormat
        {
            get;
            set;
        }

        public string logFileName { get; set; }

    }
}



