using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace PlaywrightStarterConsoleApp.Configuration
{
  public abstract class BasePageObject
  {
    public abstract string PagePath { get; }

    public abstract IPage Page { get; set; }

    public abstract IBrowser Browser { get; }

    public async Task NavigateAsync()
    {
      Page = await Browser.NewPageAsync();
      await Page.GotoAsync(PagePath);
    }

    public async Task LogTakeScreenshot(string errorMsg, string screenshotFileName)
    {
      Console.WriteLine($"{errorMsg}");
      await Page.ScreenshotAsync(new PageScreenshotOptions { Path = $"./Screenshots/{screenshotFileName}.png" });
    }
  }
}
