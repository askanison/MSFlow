using FluentAssertions;
using MSFlow.Drivers;
using MSFlow.Helpers.Resources;
using TechTalk.SpecFlow;
using static MSFlow.Base;
using static MSFlow.Helpers.TestHelperData;


namespace MSFlow.Steps
{
    [Binding]
    public class MobileAviatorSteps : DriverHelper
    {
        [Given(@"Open mobile Adjarabet page")]
        public void GivenOpenMobileAdjarabetPage()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            // _browserDriver.GoToUrl("https://410merged.opt.adjarabet.com/mobile/ka");
        }

        [Given(@"Login on home page")]
        public void GivenLoginOnHomePage()
        {
            ClickToElement(driver, MainResources.MobileHeaderLoginButton);
            SendKeys(driver, MainResources.MobileLoginFormUsernameInput, "testgames");
            SendKeys(driver, MainResources.MobileLoginFormPasswordInput, "Paroli1#");
            ClickToElement(driver, MainResources.MobileLoginFormLoginButton);
            FindElement(driver, MainResources.MobileHeaderUsernameText).Text.Should().Be("testgames");
            FindElement(driver, MainResources.MobileHeaderVerifiedCheckmark).GetAttribute("class").Contains("_s_color-primary-2").Should().BeTrue();
        }

        [Given(@"Login on home page using '(.*)' and '(.*)'")]
        public void GivenLoginOnHomePageUsingAnd(string username, string password)
        {
            ClickToElement(driver, MainResources.MobileHeaderLoginButton);
            SendKeys(driver, MainResources.MobileLoginFormUsernameInput, username);
            SendKeys(driver, MainResources.MobileLoginFormPasswordInput, password);
            ClickToElement(driver, MainResources.MobileLoginFormLoginButton);
            ElementVanished(driver, MainResources.MobileLoginFormLoginButton);
            FindElement(driver, MainResources.MobileHeaderVerifiedCheckmark).GetAttribute("class").Contains("_s_color-primary-2").Should().BeTrue();
        }


        [Given(@"Navigate to mobile Aviator page")]
        public void GivenNavigateToMobileAviatorPage()
        {
            string currentUrl = driver.Url;
            ClickToElement(driver, MainResources.MobileHeaderNavigationAviator);
            WaitUntilUrlChanges(driver, currentUrl);
            driver.Url.Contains("Aviator").Should().BeTrue();
        }

        [When(@"I click Play Aviator button")]
        public void WhenIClickPlayAviatorButton()
        {
            string currentUrl = driver.Url;
            ClickToElement(driver, MainResources.MobileAviatorPlayButton);
            WaitUntilUrlChanges(driver, currentUrl);
            (driver.Url == currentUrl).Should().BeFalse();
        }

        [Then(@"Game is launched")]
        public void ThenGameIsLaunched()
        {
            ElementExists(driver, "//div[@class='bet-controls']").Should().BeTrue();
        }

        [Then(@"Url is correct")]
        public void ThenUrlIsCorrect()
        {
            driver.Url.Contains("https://aviator-next.spribegaming.com/?user=").Should().BeTrue();
        }
    }
}
