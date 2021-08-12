using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSFlow.Drivers;
using MSFlow.Helpers.Enums;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
        //[BeforeTestRun]
        //public void BeforeTest()
        //{

        //}

        //[AfterTestRun]
        //public void GenerateLivingDoc()
        //{
        //    string path = @"C:\Users\a.turdzeladze\source\repos\SpecFlowProject2\SpecFlowProject2\bin\Debug\net5.0";
        //    string generateLivingDoc = "livingdoc test-assembly SpecFlowProject2.dll -t TestExecution.json";
        //    Process process = new Process();
        //    ProcessStartInfo processStartInfo = new ProcessStartInfo();
        //    processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        //    processStartInfo.FileName = "cmd.exe";
        //    processStartInfo.ArgumentList.Add($"cd {path}");
        //    processStartInfo.ArgumentList.Add(generateLivingDoc);
        //    processStartInfo.ArgumentList.Add("LivingDoc.html");
        //    process.StartInfo = processStartInfo;
        //    process.Start();

        //}

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

        //[BeforeStep]
        //public void BeforeStep()
        //{

        //}

        [AfterStep]
        public void TakeScreenshotAfterStep()
        {
            if (scenarioContext.TestError != null)
                specFlowOutputHelper.AddAttachment(UploadImage(driver));
        }
    }
}
