using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace MSFlow.Drivers
{
    public class DriverHelper
    {
       [ThreadStatic] public static IWebDriver driver;
    }
}
