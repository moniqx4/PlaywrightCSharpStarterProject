using Microsoft.Playwright;
using PlaywrightStarterConsoleApp.Configuration;
using System.Threading.Tasks;

namespace PlaywrightStarterConsoleApp.PageObjects
{
  public class ChallengePage : BasePageObject
  {
    public override string PagePath => "";

    public ChallengePage(IBrowser browser)
    {
      Browser = browser;
    }

    public override IPage Page { get; set; }

    public override IBrowser Browser { get; }

    public async Task ClickOnSkipButton()
    {
      await Page.RunAndWaitForNavigationAsync(async () =>
      {
        await Page.ClickAsync("");
      });
    }
  }
}
