using Microsoft.Playwright;
using PlaywrightStarterConsoleApp.Common.Logging;
using System.Threading.Tasks;

namespace PlaywrightStarterConsoleApp.Configuration
{
  public abstract class BasePageObject
  {
    public abstract string PagePath { get; }

    public abstract IPage Page { get; set; }

    public abstract IBrowser Browser { get; }

    private ILogService Logger { get; }

    public async Task NavigateAsync()
    {
      Page = await Browser.NewPageAsync();
      await Page.GotoAsync(PagePath);
    }

    public async Task LogTakeScreenshot(string errorMsg, string screenshotFileName)
    {
      Logger.LogLevelError($"{errorMsg}");
      await Page.ScreenshotAsync(new PageScreenshotOptions { Path = $"./Screenshots/{screenshotFileName}.png" });
    }
  }
}
