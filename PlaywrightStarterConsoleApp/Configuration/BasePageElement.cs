using Microsoft.Playwright;
using PlaywrightStarterConsoleApp.Common.Constants;
using PlaywrightStarterConsoleApp.Common.Logging;
using System;
using System.Threading.Tasks;


namespace PlaywrightStarterConsoleApp.Configuration
{
  public abstract class BasePageElement
  {
    public abstract IPage Page { get; set; }

    public abstract IBrowser Browser { get; }
    private ILogService Logger { get; }

    public BasePageElement(IPage page)
    {
      //Browser = browser;
      Page = page;
    }

    public async Task EnterTextAsync(LocatorType locatorType, string locator, string textValue)
    {
      switch (locatorType)
      {
        case LocatorType.ByDataAutomationId:
          await SetTextByDataAutomationId(locator, textValue);
          break;

        case LocatorType.BasicSelector:
          await SetText(locator, textValue);
          break;

        default:
          await SetText(locator, textValue);
          break;
      }      
    }

    public async Task LogTakeScreenshot(string errorMsg, string screenshotFileName)
    {
      Logger.LogLevelError($"{errorMsg}");
      await Page.ScreenshotAsync(new PageScreenshotOptions { Path = $"./Screenshots/{screenshotFileName}.png" });
    }

    private async Task SetTextByDataAutomationId(string locator, string textValue)
    {
      try
      {
        var options = new PageFillOptions
        {
          //Timeout = 60,        
          Strict = true
        };

        await Page.FillAsync($"[data-automation-id='{locator}']", textValue, options);
      }
      catch (Exception ex)
      {
        await LogTakeScreenshot(ex.Message, $"{locator}_textBoxfill");
        throw;
      }

     
    }

    private async Task SetText(string locator, string textValue)
    {
      try
      {
        var options = new PageFillOptions
        {
          //Timeout = 60,        
          Strict = true
        };

        await Page.FillAsync(locator, textValue, options);
      }
      catch (Exception ex)
      {
        await LogTakeScreenshot(ex.Message, $"{locator}_textBoxfill");
        throw;
      }

      
    }
  }
}
