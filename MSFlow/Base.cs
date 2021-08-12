using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.IO;

namespace MSFlow
{
    public static class Base
    {
        public static bool ElementVanished(IWebDriver driver, string by, int timer = 5000)
        {
            try
            {
                DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
                wait.PollingInterval = TimeSpan.FromMilliseconds(timer / 10);
                wait.Timeout = TimeSpan.FromMilliseconds(timer);
                wait.Until(de => de.FindElements(By.XPath(by)).Count == 0);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void WaitUntilUrlChanges(IWebDriver driver, string url, int timer = 5000)
        {
            try
            {
                DefaultWait<IWebDriver> wait = new(driver);
                wait.PollingInterval = TimeSpan.FromMilliseconds(timer / 5);
                wait.Timeout = TimeSpan.FromMilliseconds(timer);
                wait.Until(dr => dr.Url != url);

            }
            catch
            {

            }
        }

        public static void ClickToElement(IWebDriver driver, string by, string error = "Object not found", int timer = 5000)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromMilliseconds(timer);
            wait.PollingInterval = TimeSpan.FromMilliseconds(timer / 5);
            Actions action = new Actions(driver);
            IWebElement element;
            try
            {
                wait.Until(de => de.FindElements(By.XPath(by)).Count > 0);
                element = driver.FindElement(By.XPath(by));
                action.MoveToElement(element).Perform();
                action.Click(element).Perform();
            }
            catch
            {
                throw new Exception(error);
            }
        }

        public static IWebElement FindElement(IWebDriver driver, string by, string error = "Object Not Found", int timer = 5000)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromMilliseconds(timer);
            Actions action = new Actions(driver);
            IWebElement elemen;
            try
            {
                wait.Until(de => de.FindElements(By.XPath(by)).Count > 0);
                elemen = driver.FindElement(By.XPath(by));
                action.MoveToElement(elemen).Perform();
                return elemen;
            }
            catch
            {
                throw new Exception(error);
            }

        }

        public static void SendKeys(IWebDriver driver, string by, string text, string error = "Object not found", int timer = 5000)
        {
            try
            {
                ClearField(driver, by, error, timer);
                FindElement(driver, by, error, timer).SendKeys(text);
            }
            catch
            {
                throw new Exception(error);
            }
        }

        public static void ClearField(IWebDriver driver, string XPath, string error = "Object not found", int timer = 5000) => FindElement(driver, XPath, error, timer: timer).Clear();

        public static bool ElementExists(IWebDriver driver, string by, int timer = 5000)
        {
            try
            {
                DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
                wait.PollingInterval = TimeSpan.FromMilliseconds(timer / 5);
                wait.Timeout = TimeSpan.FromMilliseconds(timer);
                wait.Until(de => de.FindElements(By.XPath(by)).Count > 0);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void FinishTest(IWebDriver driver)
        {
            driver.Close();
            driver.Dispose();
        }


        public static Bitmap TakeAScreenshot(IWebDriver driver)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            return new Bitmap(new MemoryStream(screenshot.AsByteArray));

        }
        public static string UploadImage(IWebDriver driver)
        {

            try
            {
                string imageName = $"{DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss")}.{ScreenshotImageFormat.Jpeg}";
                string filePath =
                    @"C:\Users\a.turdzeladze\Pictures\SpecFlowScreenshot\" + imageName;
                //bdtsdrttzvxmx@solarunited.net
                //Paroli1#
                Account account = new Account(
                 "dazhghkhv",
                   "793346215645576",
                   "Ka3fKVTYDmSIV2QaBpFSYweankQ");

                Cloudinary cloudinary = new Cloudinary(account);
                Bitmap imageFile = TakeAScreenshot(driver);
                imageFile.Save(filePath);
                ImageUploadParams uploadParams = new()
                {
                    File = new FileDescription(filePath)
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                Uri uploadURL = uploadResult.Uri;
                if (uploadURL == null)
                {
                    return "Couldn't upload screenshot.";
                }

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                return uploadResult.Uri.ToString();
            }
            catch (Exception)
            {
                return "Couldn't upload screenshot ";
            }
        }
    }
}
