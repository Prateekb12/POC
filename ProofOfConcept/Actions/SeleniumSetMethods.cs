using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ProofOfConcept
{
    public static class SeleniumSetMethods
    {
        //
        /// <summary>
        /// Enter Text 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        /// <summary>
        /// Click a Checkbox, Button , Option etc
        /// </summary>
        /// <param name="element"></param>
        public static void Clicks(this IWebElement element)
        {
            element.Click();
        }

        /// <summary>
        /// Selecting a drop down control
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SelectDropDownByText(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }

        /// <summary>
        /// Click a Checkbox, Button , Option etc
        /// </summary>
        /// <param name="element"></param>
        public static void openURL(string testData)
        {
            Properties.driver.Navigate().GoToUrl(testData);
        }
    }
}
