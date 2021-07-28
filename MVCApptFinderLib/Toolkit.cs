using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace MVCApptFinderLib
{
    public class Toolkit
    {
        public static List<Location> Locations;
        public static void LoadData(string url)
        {
            IWebDriver driver = new FirefoxDriver(@"..\");
            driver.Navigate().GoToUrl(url);

            IWebElement locationsDiv = driver.FindElement(By.Id("locationsDiv"));

            CreateObjectsFromData(locationsDiv.Text);
            
            Console.WriteLine(locationsDiv.Text + "\n");

            driver.Quit();
        }

        public static void CreateObjectsFromData(string data)
        {

        }
    }
}