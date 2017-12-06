
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DumbLogger.Configuration;

namespace DumbLogger
{
    /// <remarks>Specifies all data that are requested to be logged.</remarks>
    [Serializable]
    public class LogParameters
    {
        public string Message
        {
            get;
            set;
        }

        public LogLevelEnum LogLevel
        {
            get;
            set;
        }

        public string Error
        {
            get;
            set;
        }

        public string Application
        {
            get;
            set;
        }

        public string ClassName { get; set; }

        public string MethodPath
        {
            get;
            set;
        }

    }
}
