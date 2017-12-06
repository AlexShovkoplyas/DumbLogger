using System.Text;
using System;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using DumbLogger.Configuration;


namespace DumbLogger.LogWriters
{
    public class LogWriterXml : LogWriter
    {
        public LogWriterXml(LogConfig logConfig) : base(logConfig) { }

        public override void LogWrite(LogParameters logInfo)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(LogParameters));

            var settings = new XmlWriterSettings() { OmitXmlDeclaration = true };
            var emptyNs = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            using (Stream fileStream = new FileStream(Config.LogDirectory + @"\" + Config.logFileName, FileMode.Append))
            {
                XmlWriter xmlWriter = XmlWriter.Create(fileStream, settings);

                serializer.Serialize(xmlWriter, logInfo, emptyNs);
                xmlWriter.Dispose();

                byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                fileStream.Write(newline, 0, newline.Length);
                
            }            
        }
    }
}



