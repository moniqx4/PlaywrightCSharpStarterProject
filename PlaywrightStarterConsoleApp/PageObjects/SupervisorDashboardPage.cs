using Microsoft.Playwright;
using PlaywrightStarterConsoleApp.Common.Constants;
using PlaywrightStarterConsoleApp.Configuration;

namespace PlaywrightStarterConsoleApp.PageObjects
{
  public class SupervisorDashboardPage : BasePageObject
  {
    public override string PagePath => PagePaths.BaseUrl + "";
    public SupervisorDashboardPage(IBrowser browser)
    {
      Browser = browser;
    }

    public override IPage Page { get; set; }

    public override IBrowser Browser { get; }
  }
}
