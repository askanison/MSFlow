﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using MSFlow.Helpers.Enums;

namespace MSFlow.Drivers
{
    public class BrowserDrivers
    {


        public IWebDriver GetWebDriver(BrowserType browserType)
        {
            return browserType switch
            {
                BrowserType.ChromeMobileLocal => GetLocalChromeMobile(),
                BrowserType.ChromeMobileRemote => RemoteChromeMobile,
                BrowserType.ChromeDesktopLocal => GetLocalChromeDesktop(),
                BrowserType.ChromeDesktopRemote => RemoteChromeDesktop,
                _ => throw new NotSupportedException("not supported browser: <null>"),
            };
        }


        private static IWebDriver RemoteChromeMobile
        {
            get
            {
                ChromeOptions options = new();
                //options.AddArgument("--disable-notifications");
                options.AddArguments("--disable-infobars");
                //options.AddArguments("--headless");
                options.EnableMobileEmulation("iPhone X");
                options.AddUserProfilePreference("profile.default_content_setting_values.plugins", 1);
                options.AddArguments("--ignore-certificate-errors");
                options.AddArguments("start-maximized");
                options.AddArguments("--disable-extensions");

                return new RemoteWebDriver(new Uri("http://10.10.24.250:666/wd/hub"), options);
            }
        }

        private static IWebDriver RemoteChromeDesktop
        {
            get
            {
                ChromeOptions options = new();
                options.AddArgument("--disable-notifications");
                options.AddArguments("--disable-infobars");
                //options.AddArguments("--headless");
                //options.AddArguments("--disable-popup-blocking");
                options.AddArgument("no-sandbox");
                options.AddUserProfilePreference("profile.default_content_setting_values.plugins", 1);
                options.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
                options.AddArguments("--ignore-certificate-errors");
                options.AddArguments("start-maximized");
                return new RemoteWebDriver(new Uri("http://10.10.24.250:666/wd/hub"), options);
            }
        }

        private IWebDriver GetLocalChromeMobile()
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--disable-notifications");
            options.AddArguments("--disable-infobars");
            options.AddArguments("--headless");
            options.EnableMobileEmulation("iPhone X");
            options.AddUserProfilePreference("profile.default_content_setting_values.plugins", 1);
            options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("start-maximized");
            options.AddArguments("--disable-extensions");

            return new ChromeDriver("C:\\", options);
        }

        private IWebDriver GetLocalChromeDesktop()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-notifications");
            options.AddArguments("--disable-infobars");
            //options.AddArguments("--headless");
            //options.AddArguments("--disable-popup-blocking");
            options.AddArgument("no-sandbox");
            options.AddUserProfilePreference("profile.default_content_setting_values.plugins", 1);
            options.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
            options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("start-maximized");


            return new ChromeDriver("C:\\", options);

        }

    }
}