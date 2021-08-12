using MSFlow.Drivers;
using MSFlow.Helpers.Resources;
using System;
using TechTalk.SpecFlow;
using static MSFlow.Helpers.TestHelperData;
using static MSFlow.Base;

namespace MSFlow.Steps
{
    [Binding]
    public class DesktopAviatorSteps : DriverHelper
    {
        [Given(@"Open desktop Adjarabet page")]
        public void GivenOpenDesktopAdjarabetPage()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }

        [Given(@"Navigate to desktop Aviator Page")]
        public void GivenNavigateToDesktopAviatorPage()
        {
            ClickToElement(driver, MainResources.DesktopHeaderNavigationAviator);
        }

    }
}
