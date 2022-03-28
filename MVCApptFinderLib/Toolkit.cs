using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace MVCApptFinderLib
{
    public static class Toolkit
    {
        public static IWebDriver driver;
        public static List<Location> LoadData(string url)
        {
            // The two lines below set the Firefox browser to be set to headless mode, which means that the browser won't actually open up/pop-up on-screen.
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArgument("--headless");

            driver = new FirefoxDriver(@"..\");
            driver.Navigate().GoToUrl(url);

            IWebElement locationsDiv = driver.FindElement(By.Id("locationsDiv"));
            List<Location> locations = CreateObjectsFromData(locationsDiv.Text);
            driver.Quit();

            return locations;
        }

        private static List<Location> CreateObjectsFromData(string data)
        {
            List<Location> locs = new List<Location>();
            string[] lines = data.Split("\n");

            for (int i = 0; i < lines.Length; i += 7)
            {
                if (lines[i + 4].Trim().Equals("")) // Two-line address
                {
                    string trimmedDate = lines[i+6].Substring(16, 19);

                    locs.Add(new Location
                        {
                            LocationTitle = lines[i],
                            AppointmentType = lines[i + 1],
                            LocationAddress = $"{lines[i + 2].Trim()} {lines[i + 3].Trim()}",
                            AppointmentTime = new DateTime(
                                year:   Int32.Parse(trimmedDate.Substring(6, 4)),
                                month:  Int32.Parse(trimmedDate.Substring(0, 2)),
                                day:    Int32.Parse(trimmedDate.Substring(3, 2)),
                                hour:   Int32.Parse(trimmedDate.Substring(11, 2)),
                                minute: Int32.Parse(trimmedDate.Substring(14, 2)),
                                second: 0)
                        });
                }
                else // Three-line address
                {
                    string trimmedDate = lines[i+7].Substring(16, 19);

                    locs.Add(new Location
                        {
                            LocationTitle = lines[i],
                            AppointmentType = lines[i + 1],
                            LocationAddress = $"{lines[i + 2].Trim()} {lines[i + 3].Trim()} {lines[i + 4].Trim()}",
                            AppointmentTime = new DateTime(
                                year:   Int32.Parse(trimmedDate.Substring(6, 4)),
                                month:  Int32.Parse(trimmedDate.Substring(0, 2)),
                                day:    Int32.Parse(trimmedDate.Substring(3, 2)),
                                hour:   Int32.Parse(trimmedDate.Substring(11, 2)),
                                minute: Int32.Parse(trimmedDate.Substring(14, 2)),
                                second: 0)
                        });
                    i++;
                }
            }

            return locs;
        }
    }
}