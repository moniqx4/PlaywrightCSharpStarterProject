using FluentAssertions;
using PlaywrightStarterConsoleApp.Common.Constants;
using PlaywrightStarterConsoleApp.PageObjects;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace PlaywrightStarterConsoleApp.Tests
{
  [Binding]
  public class NavigateToSpecFlowPageSteps
  {
    private readonly LoginPage _loginPage;
    private readonly ChallengePage _challengePage;
    private readonly SupervisorDashboardPage _supervisorDashboardPage;

    public NavigateToSpecFlowPageSteps(LoginPage loginPage, ChallengePage challengePage, SupervisorDashboardPage supervisorDashboardPage)
    {
      _loginPage = loginPage;
      _challengePage = challengePage;
      _supervisorDashboardPage = supervisorDashboardPage;
    }

    [Given(@"the user is on LoginPage")]
    public async Task GivenTheUserIsOnLoginPage()
    {
      await _loginPage.NavigateAsync();
    }

    [Given(@"user types in companyAlias in companyAlias field")]
    public async Task GivenUserTypesInCompanyAliasInCompanyAliasField()
    {
      await _loginPage.FillInCompanyAlias(""); // TODO get this info from a configuration file
    }

    [Given(@"user types in username in username field")]
    public async Task GivenUserTypesInUsernameInUsernameField(string username)
    {
      await _loginPage.FillInUsername(username); // TODO get this info from a configuration file
    }

    [Given(@"user types in password in password field")]
    public async Task GivenUserTypesInPasswordInPasswordField(string password)
    {      
      await _loginPage.FillInPassword(password); // TODO get this info from a configuration file
    }

    [When(@"the login button is clicked the challenge page appears")]
    public async Task WhenUserClicksLoginButtonTheChallengePageAppears()
    {
      await _loginPage.ClickOnLoginButton();
      _challengePage.Page.Url.Should().Contain(PagePaths.ChallengePagePath); 
    }

    [Then(@"the user clicks on the skip button and goes to '(.*)'")]
    public async Task ThenUserClicksOnTheSkipButtonAndGoesTo()
    {
       await _challengePage.ClickOnSkipButton();      
      _supervisorDashboardPage.Page.Url.Should().Contain(PagePaths.SupervisorDashboardPagePath);
    }
  }
}
