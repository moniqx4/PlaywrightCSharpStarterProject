using BoDi;
using Microsoft.Playwright;
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
      container.RegisterInstanceAs(playwright);
      container.RegisterInstanceAs(browser);
      container.RegisterInstanceAs(pageObject);
    }

    [AfterScenario]
    public async Task AfterScenario(IObjectContainer container)
    {
      var browser = container.Resolve<IBrowser>();
      await browser.CloseAsync();
      var playwright = container.Resolve<IPlaywright>();
      playwright.Dispose();
    }
  }
}
