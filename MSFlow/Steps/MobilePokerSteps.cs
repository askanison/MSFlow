using FluentAssertions;
using MSFlow.Drivers;
using MSFlow.Helpers.Resources;
using System.Threading;
using TechTalk.SpecFlow;
using static MSFlow.Base;
using static MSFlow.Helpers.TestHelperData;
using static MSFlow.Helpers.GetSelector;

namespace MSFlow.Steps
{
    [Binding]
    public class MobilePokerSteps : DriverHelper
    {
        [Given(@"Navigate to '(.*)' page")]
        public void GivenNavigateToPage(string p0)
        {
            string currentUrl = driver.Url;
            ClickToElement(driver, GetMobileSelectorByName(p0));
            Thread.Sleep(1000);
            string because = $"After navigating to {p0} page action failed or navigated to different page( {driver.Url} )";
            _ = (driver.Url == currentUrl).Should().BeFalse(because);
        }
        
        [Then(@"'(.*)' game is launched")]
        public void ThenGameIsLaunched(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Mobile Poker game is launched")]
        public void ThenMobilePokerGameIsLaunched()
        {
            ElementExists(driver, "//iframe");
            driver.SwitchTo().Frame(FindElement(driver, "//iframe", "Mobile Poker iframe not found"));
            ElementExists(driver, "//main//app-cash", 15000).Should().BeTrue("Mobile Poker game not loaded");
            driver.SwitchTo().DefaultContent();
        }

        [When(@"I log in from Login Form using '(.*)' and '(.*)'")]
        public void WhenILogInFromLoginFormUsingAnd(string username, string password)
        {

            SendKeys(driver, MainResources.MobileLoginFormUsernameInput, username, "Username input for mobile login form not found");
            SendKeys(driver, MainResources.MobileLoginFormPasswordInput, password, "Password input for mobile login form not found");
            ClickToElement(driver, MainResources.MobileLoginFormLoginButton, "Mobile Login form authorization/login button not found");
            Thread.Sleep(1000);
            ElementVanished(driver, MainResources.MobileLoginFormLoginButton).Should().BeTrue("Login form still visible after login procedure");
        }


    }
}
