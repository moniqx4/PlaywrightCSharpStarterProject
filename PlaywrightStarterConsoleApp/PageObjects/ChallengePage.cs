using Microsoft.Playwright;
using PlaywrightStarterConsoleApp.Common.Constants;
using PlaywrightStarterConsoleApp.Configuration;
using System;
using System.Threading.Tasks;

namespace PlaywrightStarterConsoleApp.PageObjects
{
  public class ChallengePage : BasePageObject
  {
    public override string PagePath => PagePaths.BaseUrl + PagePaths.ChallengePagePath;

    public ChallengePage(IBrowser browser)
    {
      Browser = browser;
    }

    public override IPage Page { get; set; }

    public override IBrowser Browser { get; }

    public async Task ClickOnSkipButton()
    {
      try
      {
        await Page.RunAndWaitForNavigationAsync(async () =>
        {
          await Page.ClickAsync("text=Skip");
        });
      }
      catch (Exception ex)
      {        
        await LogTakeScreenshot (ex.Message, "clickskipbutton");        
        throw;
      }      
    }
  }
}
