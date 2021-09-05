using FluentAssertions;
using MSFlow.Drivers;
using MSFlow.Helpers.Resources;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static MSFlow.Base;

namespace MSFlow.Steps
{
    [Binding]
    public class MobileTableGamesSteps : DriverHelper
    {
        [Given(@"Navigate to mobile Table Games page")]
        public void GivenNavigateToMobileTableGamesPage()
        {
            string currentUrl = driver.Url;
            ClickToElement(driver, MainResources.MobileHeaderNavigationTableGames);
            WaitUntilUrlChanges(driver, currentUrl);
            driver.Url.Contains("/Games").Should().BeTrue();
        }

        [Then(@"Table Game is launched")]
        public void ThenTableGameIsLaunched()
        {
            ElementExists(driver, "//iframe");
            driver.SwitchTo().Frame(FindElement(driver, "//iframe"));
            ElementExists(driver, "//div[contains(@class,'main-table')]", 15000).Should().BeTrue();
            driver.SwitchTo().DefaultContent();
        }

        

    }
}
