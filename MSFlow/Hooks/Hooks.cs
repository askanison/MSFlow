using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSFlow.Drivers;
using MSFlow.Helpers.Enums;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using static MSFlow.Base;
[assembly: Parallelize(Scope = ExecutionScope.ClassLevel, Workers = 4)]



namespace MSFlow.Hooks
{
    [Binding]
    public sealed class Hooks : DriverHelper
    {

        BrowserDrivers browserDrivers;
        private readonly ISpecFlowOutputHelper specFlowOutputHelper;
        ScenarioContext scenarioContext;



        public Hooks(BrowserDrivers browserDrivers, ISpecFlowOutputHelper specFlowOutputHelper, ScenarioContext scenarioContext)
        {
            this.browserDrivers = browserDrivers;
            this.specFlowOutputHelper = specFlowOutputHelper;
            this.scenarioContext = scenarioContext;
        }

        [BeforeScenario("Mobile")]
        public void BeforeMobileScenario()
        {
            //driver = browserDrivers.GetWebDriver(BrowserType.ChromeMobileLocal);
            driver = browserDrivers.GetWebDriver(BrowserType.ChromeMobileRemote);

        }

        [BeforeScenario("Desktop")]
        public void BeforeDesktopScenario()
        {
            //driver = browserDrivers.GetWebDriver(BrowserType.ChromeDesktopLocal);
            driver = browserDrivers.GetWebDriver(BrowserType.ChromeDesktopRemote);

        }

        [BeforeScenario("RemoteMobile")]
        public void BeforeRemoteScenario()
        {
            driver = browserDrivers.GetWebDriver(BrowserType.ChromeMobileRemote);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            FinishTest(driver);
        }


        [AfterStep]
        public void TakeScreenshotAfterStep()
        {
            if (scenarioContext.TestError != null)
                specFlowOutputHelper.AddAttachment(GetScreenshot(driver));
        }
    }
}
