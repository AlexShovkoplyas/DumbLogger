
using DumbLogger.Configuration;

namespace DumbLogger.LogWriters
{
    public class LogWriterJson : LogWriter
    {
        public LogWriterJson(LogConfig logConfig) : base( logConfig) { }

        public override void LogWrite(LogParameters logInfo)
        {
            throw new System.NotImplementedException();
        }

    }
}



