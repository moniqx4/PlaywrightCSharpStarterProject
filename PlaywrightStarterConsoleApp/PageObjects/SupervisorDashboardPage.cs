using Microsoft.Playwright;
using PlaywrightStarterConsoleApp.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightStarterConsoleApp.PageObjects
{
  public class SupervisorDashboardPage : BasePageObject
  {
    public override string PagePath => "";
    public SupervisorDashboardPage(IBrowser browser)
    {
      Browser = browser;
    }

    public override IPage Page { get; set; }

    public override IBrowser Browser { get; }
  }
}
