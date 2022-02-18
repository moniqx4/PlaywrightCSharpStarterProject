using Microsoft.Playwright;
using PlaywrightStarterConsoleApp.Common.Constants;
using PlaywrightStarterConsoleApp.Configuration;
using System;
using System.Threading.Tasks;

namespace PlaywrightStarterConsoleApp.PageObjects
{
  public class LoginPage : BasePageObject
  {
    public override string PagePath => PagePaths.BaseUrl;

    public LoginPage(IBrowser browser)
    {
      Browser = browser;
    }

    public override IPage Page { get; set; }

    public override IBrowser Browser { get; }

    public async Task FillInCompanyAlias(string companyAlias)
    {
      try
      {
        await Page.Locator("").FillAsync(companyAlias); //TODO add locator
      }
      catch (Exception ex)
      {
        await LogTakeScreenshot(ex.Message, "fillcompanyalias");
        throw;
      }
    }

    public async Task FillInUsername(string username)
    {
      try
      {
        await Page.Locator("").FillAsync(username); //TODO add locator
      }
      catch (Exception ex)
      {
        await LogTakeScreenshot(ex.Message, "fillusername");        
        throw;
      }      
    }

    public async Task FillInPassword(string password)
    {
      try
      {
        await Page.Locator("").FillAsync(password); //TODO add locator
      }
      catch (Exception ex)
      {
        await LogTakeScreenshot(ex.Message, "fillpassword");       
        throw;
      }
    }

    public async Task ClickOnLoginButton()
    {
      try
      {
        await Page.RunAndWaitForNavigationAsync(async () =>
        {
          await Page.Locator("text=Login").ClickAsync();
        });
      }
      catch (Exception ex)
      {
        await LogTakeScreenshot(ex.Message, "clickloginbutton");        
        throw;
      }      
    }
  }
}
