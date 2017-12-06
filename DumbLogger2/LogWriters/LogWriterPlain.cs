
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DumbLogger.Configuration;

namespace DumbLogger.LogWriters
{
    public class LogWriterPlain : LogWriter
    {
        public LogWriterPlain(LogConfig logConfig) : base(logConfig) { }        

        public override void LogWrite(LogParameters logInfo)
        {
            throw new System.NotImplementedException();
        }

    }
}



