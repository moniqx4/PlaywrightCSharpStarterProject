using NUnit.Framework;
using Microsoft.Playwright.NUnit;
using System.Threading.Tasks;


namespace PlaywrightCSharpStarterProject
{
  //[Parallelizable(ParallelScope.Self)]
  public class Tests : PageTest
  {
    
    //public void Setup()
    //{
    //}

    [Test]
    public async Task Test1()
    {
      int result = await Page.EvaluateAsync<int>("() => 7 + 3");
      Assert.AreEqual(10, result);
    }
  }
}