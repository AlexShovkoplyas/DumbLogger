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
`LogFormatEnum` | Variants of log file : Txt,  Xml, Json

`DumbLogger.LogWriters`
Contain classes that are inherited from class `LogWriter` and provide realisation of logging in different file format.

ClassName | Description
--------- | -----------
`LogWriterPlain` | Provide functionality for file format `txt` 
`LogParametersXml` | Provide functionality for file format `xml` 
`LogManagerJson` | Provide functionality for file format `json` 

## Set up project : 
Copy .dll  

## How to start :

You can create logger in 2 different ways : with default configuration or with manual configuration:
```
using DumbLogger;

LogWriter DefaultLogger = LogManager.GetLogger("LoggerName");
```

```
using DumbLogger;
using DumbLogger.Configuration;

LogConfig logConfig = new LogConfig()
{
    LogName="ManualLogger",
    LogDirectory= @"D:\Logger",
    LogFormat = LogFormatEnum.Txt,
    LogLevel = LogLevelEnum.Error,
    logFileName = "MyFirstLogger.txt"
}
LogWriter manualLogger = LogManager.GetLogger(logConfig);
```
3 variants of log messages are available: 

```
manualLogger.Debug("Log message");
```

```
catch (Exception e)
{
    manualLogger.Fatal("Log message", e);
}
```


Functionality
- Config File

- [x] @mentions, #refs, [links](), **formatting**, and <del>tags</del> supported
- [x] list syntax required (any unordered or ordered list supported)
- [x] this is a complete item
- [ ] this is an incomplete item
