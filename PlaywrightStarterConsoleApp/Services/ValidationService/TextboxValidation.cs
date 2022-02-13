using Microsoft.Playwright;
using PlaywrightStarterConsoleApp.Common.Constants;
using PlaywrightStarterConsoleApp.Configuration;
using System;
using System.Threading.Tasks;

namespace PlaywrightStarterConsoleApp.Services.ValidationService
{
  public class TextboxValidation : BasePageElement
  {
    public TextboxValidation(IPage page) : base(page)
    {
    }

    public override IPage Page { get; set; }

    public override IBrowser Browser { get; }
   
    public async Task<Task<bool>> TextInvalidEntry(string locator, string textValue, string expectedMessage)
    {
      await EnterTextAsync(LocatorType.BasicSelector, locator, textValue);

      if(expectedMessage != null)
      {
        var msg = await Page.InnerTextAsync(locator);
        msg.Contains(expectedMessage);
      }     

      return Page.IsVisibleAsync(locator);
    }
    

    public async Task FillInCompanyAlias(string companyAlias)
    {
      try
      {

        await Page.FillAsync("", companyAlias); //TODO add locator
      }
      catch (Exception ex)
      {
        await LogTakeScreenshot(ex.Message, "fillcompanyalias");
        throw;
      }
    }
  }
}
