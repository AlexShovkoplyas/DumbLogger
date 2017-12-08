using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using DumbLogger.Configuration;
using System.Text;

namespace DumbLogger
{
    public static class LogConfigManager
    {
        const string configFileName = "logConfig.xml";

        static LogConfigManager()
        {
            FileInfo configFile = new FileInfo(configFileName);

            if (!configFile.Exists)
            {
                Console.WriteLine($"Config file : {configFileName} was created");
                configFile.Create().Dispose();
            }
        }       

        static public void AddLogConfig(LogConfig logConfig)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(LogConfig));

            var settings = new XmlWriterSettings() { OmitXmlDeclaration = true };
            var emptyNs = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            using (Stream fileStream = new FileStream(configFileName, FileMode.Append))
            {
                XmlWriter xmlWriter = XmlWriter.Create(fileStream, settings);

                serializer.Serialize(xmlWriter, logConfig, emptyNs);

                byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                fileStream.Write(newline, 0, newline.Length);

                Console.WriteLine($"New confidugation : {logConfig.LogName} was added to config file {configFileName}");

                xmlWriter.Dispose();

            }            
        }

        //static public void CreateConfigFile()
        //{
        //    LogConfig logConfig = new LogConfig();

        //    FileInfo configFile = new FileInfo(configFilePath);

        //    if (configFile.Exists)
        //    {
        //        Console.WriteLine($"Error. Config file already exist");
        //        return;
        //    }
        //    else
        //    {
        //        using (FileStream fs = configFile.Create())
        //        {
        //            XmlSerializer formatter = new XmlSerializer(typeof(LogConfig));
        //            Console.WriteLine($"Log. Config file was created");
        //            formatter.Serialize(fs, logConfig);
        //            Console.WriteLine($"Log. LogConfig was serialized");
        //            Console.WriteLine($"Log. Config file was filled in");
        //        }
        //    }
        //}

        //static public FileInfo GetConfigFile()
        //{
        //    FileInfo configFile = new FileInfo(configFileName);

        //    if (!configFile.Exists)
        //    {
        //        Console.WriteLine($"Config file was created");
        //        configFile.Create();
        //    }

        //    return configFile;
        //}

        //static public LogConfig ReadConfigFile()
        //{
        //    FileInfo configFile = new FileInfo(configFilePath);

        //    if (configFile.Exists)
        //    {
        //        using (FileStream fs = configFile.Open(FileMode.Open))
        //        {
        //            LogConfig logConfig;
        //            XmlSerializer formatter = new XmlSerializer(typeof(LogConfig));
        //            logConfig = (LogConfig)formatter.Deserialize(fs);
        //            Console.WriteLine($"Log. Config file was deserialised");

        //            return logConfig;
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Error. Config file don't exist");
        //        return null;
        //    }
        //}

    }
}
