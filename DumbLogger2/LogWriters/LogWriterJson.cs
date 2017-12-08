using System.Text;
using System;
using System.Runtime.Serialization.Json;
using System.IO;
using DumbLogger.Configuration;


namespace DumbLogger.LogWriters
{
    public class LogWriterJson : LogWriter
    {
        public LogWriterJson(LogConfig logConfig) : base(logConfig) { }

        public override void LogWrite(LogParameters logInfo)
        {
            var serializer = new DataContractJsonSerializer(typeof(LogParameters));

            using (FileStream fileStream = new FileStream(logFilePath, FileMode.Open))
            {
                fileStream.Seek(-2, SeekOrigin.End);

                if (fileStream.Length>5)
                {
                    StreamSupport.WriteString("," + Environment.NewLine, fileStream);
                }
                else
                {
                    StreamSupport.WriteString(Environment.NewLine, fileStream);
                }                

                serializer.WriteObject(fileStream, logInfo);

                StreamSupport.WriteString(Environment.NewLine + "]", fileStream);

            }
        }

    }
}



