
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using DumbLogger.Configuration;

namespace DumbLogger
{
    /// <remarks>Specifies all data that are requested to be logged.</remarks>
    [Serializable]
    [DataContract]
    public class LogParameters
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public LogLevelEnum LogLevel { get; set; }

        [DataMember]
        public string Error { get; set; }

        [DataMember]
        public string Application { get; set; }

        [DataMember]
        public string ClassName { get; set; }

        [DataMember]
        public string MethodPath { get; set; }

    }
}
