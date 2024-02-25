using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using ScrapeHero.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YelpMe.Models;
using ScrapeHero.Models;

namespace ScrapeHero.Repositories
{
    internal class EmailBounceCheckerRepo : IEmailBounceChecker
    {
        private AppDbContext appDbContext = new AppDbContext();
        private int delayInteger = 3000;
        private int delay2ndInteger = 5000;
        private int timeSpanInteger = 10;

        public bool UseSendBridge()
        {
            try
            {
                var existingEmails = appDbContext.VerifyLoggers.Select(v => v.Email).ToList();
                var filteredBusinesses = appDbContext.Business
                    .Where(b => !existingEmails.Contains(b.Email))
                    .ToList();

                var deviceDriver = EdgeDriverService.CreateDefaultService();
                deviceDriver.HideCommandPromptWindow = true;
                EdgeOptions options = new EdgeOptions();
                options.AddArguments("--disable-infobars");

                var driver = new EdgeDriver(deviceDriver, options);
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                driver.Navigate().GoToUrl("https://sendbridge.com/free-email-validator");

                foreach (var bs in filteredBusinesses)
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                    IWebElement inputBox = driver.FindElement(By.XPath("//form[@id='emailtest']//div[@class='input-group']//input[@name='email']"));
                    IWebElement submitBtn = driver.FindElement(By.XPath("//form[@id='emailtest']//div[@class='input-group']//span[@class='input-group-btn form-btn']//button"));

                    inputBox.SendKeys(bs.Email);

                    Thread.Sleep(delayInteger);
                    submitBtn.Click();

                    Thread.Sleep(9000); //Wait for the results....

                    IWebElement resultTag = driver.FindElement(By.XPath("//table[@class='table table-bordered vrt']//tbody//tr//td//span[@class='badge badge-pill badge-success ml-2']"));

                    string result = resultTag.Text;

                    Thread.Sleep(1000);

                    if (result != "Deliverable")
                    {
                        appDbContext.Business.Remove(bs);
                        appDbContext.SaveChanges();

                        VerifyLogger verifyLogger = new VerifyLogger();

                        verifyLogger.Email = bs.Email;
                        verifyLogger.Valid = false;

                        appDbContext.VerifyLoggers.Add(verifyLogger);
                        appDbContext.SaveChanges();
                    }
                    else
                    {
                        VerifyLogger verifyLogger = new VerifyLogger();

                        verifyLogger.Email = bs.Email;
                        verifyLogger.Valid = true;

                        appDbContext.VerifyLoggers.Add(verifyLogger);
                        appDbContext.SaveChanges();
                    }

                    Thread.Sleep(1000);
                    driver.Navigate().Refresh();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UseSite24()
        {
            try
            {
                var existingEmails = appDbContext.VerifyLoggers.Select(v => v.Email).ToList();
                var filteredBusinesses = appDbContext.Business
                    .Where(b => !existingEmails.Contains(b.Email))
                    .ToList();

                var deviceDriver = EdgeDriverService.CreateDefaultService();
                deviceDriver.HideCommandPromptWindow = true;
                EdgeOptions options = new EdgeOptions();
                options.AddArguments("--disable-infobars");

                var driver = new EdgeDriver(deviceDriver, options);
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeSpanInteger);

                driver.Navigate().GoToUrl("https://www.site24x7.com/tools/email-validator.html");

                foreach (var bs in filteredBusinesses)
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeSpanInteger);

                    IWebElement inputBox = driver.FindElement(By.Id("emailInput"));
                    IWebElement submitBtn = driver.FindElement(By.XPath("//button[text()='Validate']"));

                    inputBox.SendKeys(bs.Email);

                    Thread.Sleep(delayInteger);
                    submitBtn.Click();

                    Thread.Sleep(delay2ndInteger); //Wait for the results...

                    var rows = driver.FindElements(By.XPath("//table/tbody/tr"));

                    string result = null;

                    foreach (var row in rows)
                    {
                        // Find the third <td> (index 2 in zero-based index)
                        IWebElement cell = row.FindElement(By.XPath(".//td[4]"));

                        // Get the text value from the cell
                        result = cell.Text;
                    }

                    Thread.Sleep(delayInteger);

                    if (result != "Yes")
                    {
                        appDbContext.Business.Remove(bs);
                        appDbContext.SaveChanges();

                        VerifyLogger verifyLogger = new VerifyLogger();

                        verifyLogger.Email = bs.Email;
                        verifyLogger.Valid = false;

                        appDbContext.VerifyLoggers.Add(verifyLogger);
                        appDbContext.SaveChanges();
                    }
                    else
                    {
                        VerifyLogger verifyLogger = new VerifyLogger();

                        verifyLogger.Email = bs.Email;
                        verifyLogger.Valid = true;

                        appDbContext.VerifyLoggers.Add(verifyLogger);
                        appDbContext.SaveChanges();
                    }

                    Thread.Sleep(delayInteger);
                    driver.Navigate().Refresh();
                }
            }
            catch(Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool UseVerifDotEmail()
        {
            try
            {
                var existingEmails = appDbContext.VerifyLoggers.Select(v => v.Email).ToList();
                var filteredBusinesses = appDbContext.Business
                    .Where(b => !existingEmails.Contains(b.Email))
                    .ToList();

                var deviceDriver = EdgeDriverService.CreateDefaultService();
                deviceDriver.HideCommandPromptWindow = true;
                EdgeOptions options = new EdgeOptions();
                options.AddArguments("--disable-infobars");

                var driver = new EdgeDriver(deviceDriver, options);
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeSpanInteger);

                driver.Navigate().GoToUrl("https://verif.email/en/email-checker/");

                foreach (var bs in filteredBusinesses)
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeSpanInteger);

                    IWebElement inputBox = driver.FindElement(By.Id("email-to-verify"));
                    IWebElement submitBtn = driver.FindElement(By.ClassName("submit-btn-verify"));

                    inputBox.SendKeys(bs.Email);

                    Thread.Sleep(delayInteger);
                    submitBtn.Click();

                    Thread.Sleep(delay2ndInteger); //Wait for the results....
                    IWebElement resultTag = driver.FindElement(By.XPath("//div[@class='verifemail-verify ok']"));

                    string result = resultTag.Text;

                    Thread.Sleep(delayInteger);

                    if (result != "✅ Valide")
                    {
                        appDbContext.Business.Remove(bs);
                        appDbContext.SaveChanges();

                        VerifyLogger verifyLogger = new VerifyLogger();

                        verifyLogger.Email = bs.Email;
                        verifyLogger.Valid = false;

                        appDbContext.VerifyLoggers.Add(verifyLogger);
                        appDbContext.SaveChanges();
                    }
                    else
                    {
                        VerifyLogger verifyLogger = new VerifyLogger();

                        verifyLogger.Email = bs.Email;
                        verifyLogger.Valid = true;

                        appDbContext.VerifyLoggers.Add(verifyLogger);
                        appDbContext.SaveChanges();
                    }

                    Thread.Sleep(delayInteger);
                    driver.Navigate().Refresh();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UseZeroBounce()
        {
            try
            {
                var existingEmails = appDbContext.VerifyLoggers.Select(v => v.Email).ToList();
                var filteredBusinesses = appDbContext.Business
                    .Where(b => !existingEmails.Contains(b.Email))
                    .ToList();

                var deviceDriver = EdgeDriverService.CreateDefaultService();
                deviceDriver.HideCommandPromptWindow = true;
                EdgeOptions options = new EdgeOptions();
                options.AddArguments("--disable-infobars");

                var driver = new EdgeDriver(deviceDriver, options);
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeSpanInteger);

                driver.Navigate().GoToUrl("https://www.zerobounce.net/free-email-verifier/");

                foreach (var bs in filteredBusinesses)
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeSpanInteger);

                    IWebElement inputBox = driver.FindElement(By.Id("email-validator"));
                    IWebElement submitBtn = driver.FindElement(By.Id("results-container"));

                    inputBox.SendKeys(bs.Email);

                    Thread.Sleep(delayInteger);
                    submitBtn.Click();

                    Thread.Sleep(delay2ndInteger); //Wait for the results....

                    IWebElement resultTag = driver.FindElement(By.XPath("//button[@id()='validator_component_status']"));

                    string result = resultTag.Text;

                    Thread.Sleep(delayInteger);

                    if (result != "Yes")
                    {
                        appDbContext.Business.Remove(bs);
                        appDbContext.SaveChanges();

                        VerifyLogger verifyLogger = new VerifyLogger();

                        verifyLogger.Email = bs.Email;
                        verifyLogger.Valid = false;

                        appDbContext.VerifyLoggers.Add(verifyLogger);
                        appDbContext.SaveChanges();
                    }
                    else
                    {
                        VerifyLogger verifyLogger = new VerifyLogger();

                        verifyLogger.Email = bs.Email;
                        verifyLogger.Valid = true;

                        appDbContext.VerifyLoggers.Add(verifyLogger);
                        appDbContext.SaveChanges();
                    }

                    Thread.Sleep(delayInteger);
                    driver.Navigate().Refresh();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
