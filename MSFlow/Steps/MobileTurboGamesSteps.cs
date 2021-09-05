using FluentAssertions;
using MSFlow.Drivers;
using MSFlow.Helpers.Resources;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static MSFlow.Base;
using static MSFlow.Helpers.GetSelector;

namespace MSFlow.Steps
{
    [Binding]
    public class MobileTurboGamesSteps : DriverHelper
    {
        [Given(@"Navigate to mobile Turbo Games page")]
        public void GivenNavigateToMobileTurboGamesPage()
        {
            string currentUrl = driver.Url;
            ClickToElement(driver, MainResources.MobileHeaderNavigationTurboGames);
            WaitUntilUrlChanges(driver, currentUrl);
            driver.Url.Contains("TurboGames").Should().BeTrue("Navigating to Mobile turbo games from header didn't work or redirected to incorrect page");
        }

        [When(@"I click '(.*)' button")]
        [Given(@"I click '(.*)' button")]
        public void WhenIClickButton(string p0)
        {
            string currentUrl = driver.Url;
            ClickToElement(driver, GetMobileSelectorByName(p0));
            Thread.Sleep(1000);
            string because = $"After navigating to {p0} page action failed or navigated to different page( {driver.Url} )";
            _ = (driver.Url == currentUrl).Should().BeFalse(because);
        }

        [When(@"I log in from Login Form")]
        public void WhenILogInFromLoginForm()
        {
            SendKeys(driver, MainResources.MobileLoginFormUsernameInput, "testgames");
            SendKeys(driver, MainResources.MobileLoginFormPasswordInput, "Paroli1#");
            ClickToElement(driver, MainResources.MobileLoginFormLoginButton);
            Thread.Sleep(1000);
            ElementVanished(driver, MainResources.MobileLoginFormLoginButton).Should().BeTrue();
        }


        [Then(@"Turbo Game is launched")]
        public void ThenTurboGameIsLaunched()
        {
            ElementExists(driver, "//div[@class='next-games-container mobile']").Should().BeTrue();
        }

        [Then(@"'(.*)' is correct")]
        public void ThenIsCorrect(string p0)
        {
            Thread.Sleep(1000);
            driver.Url.Contains(p0).Should().BeTrue("Url is incorrect after opening the game");

        }


        


    }
}
