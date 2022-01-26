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

    [Given(@"user types in username in username field")]
    public async Task GivenUserTypesInUsernameInUsernameField()
    {
      await _loginPage.FillInUsername("");
    }

    [Given(@"user types in password in password field")]
    public async Task GivenUserTypesInPasswordInPasswordField()
    {
      await _loginPage.FillInPassword("");
    }


    [When(@"the login button is clicked the challenge page appears")]
    public async Task WhenUserClicksLoginButtonTheChallengePageAppears(string targetUrl)
    {
      await _loginPage.ClickOnLoginButton();
      //_challengePage.Page.Url.Should().Be(targetUrl);
    }

    [Then(@"the user clicks on the skip button and goes to '(.*)'")]
    public async Task ThenUserClicksOnTheSkipButtonAndGoesTo(string targetUrl)
    {
       await _challengePage.ClickOnSkipButton();      
      //_supervisorDashboardPage.Page.Url.Should().Be(targetUrl);
    }
  }
}
