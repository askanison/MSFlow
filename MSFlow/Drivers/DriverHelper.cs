using OpenQA.Selenium;
using System;

namespace MSFlow.Drivers
{
    public class DriverHelper
    {
        [ThreadStatic] public static IWebDriver driver;
    }
}
