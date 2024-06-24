using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

public static class Script
{
    public static void Main()
    {
        // Initialize Chrome WebDriver
        IWebDriver driver = new ChromeDriver();

        try
        {
            // Log message
            Console.WriteLine("Navigating to Home Page");
            driver.Navigate().GoToUrl("http://localhost:5173");
            System.Threading.Thread.Sleep(3000);

            // Log message
            Console.WriteLine("Navigating to About Page");
            IWebElement aboutLink = driver.FindElement(By.XPath("//a[contains(text(), 'About')]"));
            aboutLink.Click();
            System.Threading.Thread.Sleep(3000);

            // Log message
            Console.WriteLine("Clicking on the 'Vue' link");
            IWebElement vueLink = driver.FindElement(By.XPath("//a[contains(text(), 'Vue')]"));
            vueLink.Click();
            System.Threading.Thread.Sleep(3000);

            // Log message
            Console.WriteLine("Clicking on the 'Jenkins' link");
            IWebElement jenkinsLink = driver.FindElement(By.XPath("//a[contains(text(), 'Jenkins')]"));
            jenkinsLink.Click();
            System.Threading.Thread.Sleep(3000);

            // Log message
            Console.WriteLine("Clicking on the 'GitHub' link");
            IWebElement githubLink = driver.FindElement(By.XPath("//a[contains(text(), 'GitHub')]"));
            githubLink.Click();
            System.Threading.Thread.Sleep(3000);

            // Log message
            Console.WriteLine("Clicking on the 'Selenium' link");
            IWebElement seleniumLink = driver.FindElement(By.XPath("//a[contains(text(), 'Selenium')]"));
            seleniumLink.Click();
            System.Threading.Thread.Sleep(3000);

            // Log message
            Console.WriteLine("Clicking on the '000webhost.com' link");
            IWebElement webhostLink = driver.FindElement(By.XPath("//a[contains(text(), '000webhost.com')]"));
            webhostLink.Click();
            System.Threading.Thread.Sleep(3000);

            // Log message
            Console.WriteLine("Clicking on the 'Publish over FTP' link");
            IWebElement ftpLink = driver.FindElement(By.XPath("//a[contains(text(), 'Publish over FTP')]"));
            ftpLink.Click();
            System.Threading.Thread.Sleep(3000);

            // Log message
            Console.WriteLine("Tests completed successfully.");
        }
        finally
        {
            // Close the WebDriver session
            driver.Quit();
        }
    }

    // Method to switch to the new tab or window
    public static void SwitchToNewTab(IWebDriver driver)
    {
        // Get all window handles
        IReadOnlyCollection<string> handles = driver.WindowHandles;

        // Switch to the last opened window (assuming the new one is the last one)
        foreach (string handle in handles)
        {
            driver.SwitchTo().Window(handle);
        }
    }
}