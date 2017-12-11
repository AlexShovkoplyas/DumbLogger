# DumbLogger


2 projects:
  - Library "DumbLogger"
  - Examples of working wth library

## NameSpaces and Classes :

`DumbLogger`
Contain classes of main functionality.

ClassName | Description
--------- | -----------
`LogWriter` | Abstract class pointed main functionality of logger 
`LogParameters` | Specifies all parameters that can be logged.
`LogManager` | Manage loggers creation.
`LogConfigManager` | Manage config file were settings for all loggers are stored.  

`DumbLogger.Configuration`
Supports configuring of loggers.

ClassName | Description
--------- | -----------
`LogConfig` | Specify configuration settings 
`LogLevelEnum` | Variants of log inportance : Debug, Error, Fatal
`LogFormatEnum` | Variants of log file : Csv,  Xml, Json

`DumbLogger.LogWriters`
Contain classes that are inherited from class `LogWriter` and provide realisation of logging in different file format.

ClassName | Description
--------- | -----------
`LogWriterCsv` | Provide functionality for file format `csv` 
`LogParametersXml` | Provide functionality for file format `xml` 
`LogManagerJson` | Provide functionality for file format `json` 

`DumbLogger.Serializers`
Contain classes that implement interface `ITextSerializer` for object serialization.

ClassName | Description
--------- | -----------
`CsvSerializer` | Provide methods Serialize and Deserialize for format `csv` 

`DumbLogger.LogReaders`
Contain static class for reading log file.

ClassName | Description
--------- | -----------
`LogReader` | Static class for reading log files from all formats



## Set up project : 
Copy DumbLogger2.dll to Debug folder.
Use namespaces `DumbLogger`, `DumbLogger.Configuration`

Logging configuration is stored in file `logConfig.xml`. It can be created and populated programmatically or manually modifying config file.

## How to use library :

You can create logger in 2 different ways : with default configuration or with manual configuration:
```
using DumbLogger;

//Logger with default configuration
LogWriter DefaultLogger = LogManager.GetLogger("LoggerName");
```

```
using DumbLogger;
using DumbLogger.Configuration;

//Logger with custon configuration
LogConfig logConfig = new LogConfig(
    logName : "ManualLogger",
    logFormat: LogFormatEnum.Csv,
    logLevel: LogLevelEnum.Error,
    logFileName: "MyFirstLogger.csv"
);
LogWriter manualLogger = LogManager.GetLogger(logConfig);
```
For loggers with default configuration it is possible to set up default settings:
```
LogConfig.SetDefaultValues(logDirectory: @"D:\",logFormat: LogFormatEnum.Csv, logLevel: LogLevelEnum.Fatal);
```
Available formats for logging: XML, JSON, CSV.
```
LogFormatEnum.Csv
LogFormatEnum.Json
LogFormatEnum.Xml
```

3 variants of log messages are available: 

```
manualLogger.Debug("Log message Debug");
```

```
manualLogger.Error("Log message Error");
```

```
catch (Exception e)
{
    manualLogger.Fatal("Log message Fatal", e);
}
```

To read log file use method `ReadLogFile()` (data from log file will be written into Console)
```
manualLogger.ReadLogFile();
```


