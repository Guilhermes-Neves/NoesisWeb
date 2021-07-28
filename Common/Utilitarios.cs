using OpenQA.Selenium;
using System;

namespace Common
{
    public class Utilitarios
    {
        private IWebDriver driver;
        int defaultWaitTime = 30;

        public Utilitarios(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateTo(string url)
        {
            try
            {
                driver.Navigate().GoToUrl(new Uri(url));
            }
            catch (Exception methodException)
            {
                throw methodException;
            }
        }

        public void OnClick(By element)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(defaultWaitTime);
            Exception methodException = null;

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    driver.FindElement(element).Click();
                    return;
                }
                catch (Exception e)
                {
                    methodException = e;
                    continue;
                }
            }
        }

        public string GetText(By element)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(defaultWaitTime);
            Exception methodException = null;

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    string textoElemento = driver.FindElement(element).Text;
                    return textoElemento;
                }
                catch (Exception e)
                {
                    methodException = e;
                    continue;
                }
            }

            throw methodException;
        }

        public void SendKey(By element, string value, bool sendKey)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(defaultWaitTime);
            Exception methodException = null;

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    if (sendKey == true)
                    {
                        driver.FindElement(element).SendKeys(value + Keys.Enter);
                        return;
                    }

                    driver.FindElement(element).SendKeys(value);
                    return;
                }
                catch (Exception e)
                {
                    methodException = e;
                    continue;
                }
            }

            throw methodException;
        }

        public int GetElementCount(By by)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(defaultWaitTime);
            Exception methodException = new Exception();

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    return driver.FindElements(by).Count;
                }
                catch (Exception e)
                {
                    throw methodException = e;
                }

            }

            return 0;
        }

        public bool IsElementDisplayed(By by)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(defaultWaitTime);
            Exception methodException = new Exception();

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    IWebElement element = driver.FindElement(by);
                    return element.Displayed;
                }
                catch (Exception e)
                {
                    methodException = e;
                }
                
            }
            throw methodException;
        }

        public void WaitUntilElementAppear(By by)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(defaultWaitTime);

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    IWebElement element = driver.FindElement(by);
                    return;
                }
                catch (Exception)
                {
                    break;
                }
            }
        }
    }
}
