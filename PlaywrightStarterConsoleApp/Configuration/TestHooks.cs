using BoDi;
using Microsoft.Playwright;
using PlaywrightStarterConsoleApp.Common.Logging;
using PlaywrightStarterConsoleApp.PageObjects;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace PlaywrightStarterConsoleApp.Configuration
{
  [Binding]
  public class TestHooks
  {
    [BeforeScenario]
    public async Task BeforeScenario(IObjectContainer container)
    {
      var playwright = await Playwright.CreateAsync();
      var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
      {
        Headless = false,
      });
      var pageObject = new LoginPage(browser);
      var logger = new LogService();

      container.RegisterInstanceAs(playwright);
      container.RegisterInstanceAs(browser);
      container.RegisterInstanceAs(pageObject);
      container.RegisterInstanceAs(logger);
    }

    [AfterScenario]
    public async Task AfterScenario(IObjectContainer container)
    {
      var browser = container.Resolve<IBrowser>();
      await browser.CloseAsync();
      var playwright = container.Resolve<IPlaywright>();
      var logger = container.Resolve<ILogService>();
      playwright.Dispose();
      logger.Dispose();
    }
  }
}
