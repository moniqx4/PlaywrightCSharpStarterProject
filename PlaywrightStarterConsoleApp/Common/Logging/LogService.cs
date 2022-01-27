using System;
using log4net.Core;
using log4net;
using log4net.Config;
using System.Collections.Generic;
using PlaywrightStarterConsoleApp.Common.Constants;
using System.Reflection;
using System.Xml;
using System.IO;

namespace PlaywrightStarterConsoleApp.Common.Logging
{
  public class LogService : ILogService
  {
    private readonly ILog _logger = LogManager(typeof(LogService));
    private const string _LOG_FILE_TYPE = ".txt";

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    private readonly Dictionary<LogLevel, Level> LogLevelLookup = new Dictionary<LogLevel, Level>
    {
      {LogLevel.Debug, Level.Debug },
      {LogLevel.Error, Level.Error },
      {LogLevel.Fatal, Level.Fatal },
      {LogLevel.Warn, Level.Warn },
    };

    public LogService()
    {
      try
      {
        XmlDocument log4netConfig = new XmlDocument();

        using var fs = File.OpenRead("log4net.config");
        log4netConfig.Load(fs);

        var repo = LogManager.CreateRepository(
          Assembly.GetEntryAssembly(),
          typeof(log4net.Repository.Hierarchy.Hierarchy));

        XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
      }
      catch (Exception ex)
      {
        _logger.Error("Error", ex);
      }
    }

    //public void SetDynamicGeneratedLoggerProperties(LoggerModel settings, string testname)
    //{
    //  var rootRep = LogManager.GetRepository();

    //  ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level = LogLevelLookup.GetValueOrDefault(settings.LogLevel, Level.Debug);

    //  foreach (var iApp in rootRep.GetAppenders())
    //  {

    //    if (iApp.Name.Equals("FileAppender") && iApp is log4net.Appender.FileAppender)
    //    {
    //      var fApp = (log4net.Appender.FileAppender)iApp;
    //      fApp.File = Path.Combine(settings.LogFileLocation, $"{testname}{_LOG_FILE_TYPE}");

    //      fApp.ActivateOptions();
    //    }
    //  }
    //}

    public void Dispose()
    {
      throw new NotImplementedException();
}

    public void LogLevelDebug(string message)
    {
      _logger.Debug(message);
    }

    public void Debug(string message, params object[] args)
    {
      _logger.DebugFormat(message, args);
    }

    public void LogLevelError(string message)
    {
      _logger.Error(message);
    }

    public void Error(string message, params object[] args)
    {
      _logger.ErrorFormat(message, args);
    }

    public void LogLevelFatal(string message)
    {
      _logger.Fatal(message);
    }

    public void Fatal(string message, params object[] args)
    {
      _logger.FatalFormat(message, args);
    }

    public void LogLevelInfo(string message)
    {
      throw new NotImplementedException();
    }

    public void LogLevelWarn(string warnMsg)
    {
      throw new NotImplementedException();
    }

    public void LogTestStarting(string testcaseName)
    {

    }

    public void LogTestEnding(string testcaseName)
    {

    }
  }
}
