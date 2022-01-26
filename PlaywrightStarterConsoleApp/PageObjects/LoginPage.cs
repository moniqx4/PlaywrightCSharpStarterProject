using Microsoft.Playwright;
using PlaywrightStarterConsoleApp.Configuration;
using System.Threading.Tasks;

namespace PlaywrightStarterConsoleApp.PageObjects
{
  public class LoginPage : BasePageObject
  {
    public override string PagePath => "https://www.google.com/";

    public LoginPage(IBrowser browser)
    {
      Browser = browser;
    }

    public override IPage Page { get; set; }

    public override IBrowser Browser { get; }

    public Task FillInUsername(string username) => Page.FillAsync("", username);

    public Task FillInPassword(string password) => Page.FillAsync("", password);


    public async Task ClickOnLoginButton()
    {
      await Page.RunAndWaitForNavigationAsync(async () =>
      {
        await Page.ClickAsync("");
      });
    }
  }
}
