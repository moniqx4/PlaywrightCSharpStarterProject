namespace PlaywrightStarterConsoleApp.Common.Logging
{
  public interface ILogService
  {
    void LogLevelError(string errorMsg);

    void LogLevelInfo(string infoMsg);

    void LogLevelDebug(string debugMsg);

    void LogLevelFatal(string fatalMsg);

    void Dispose();
    void LogTestStarting(string testcaseName);
    void LogTestEnding(string testcaseName);
    void LogLevelWarn(string warnMsg);
  }
}
