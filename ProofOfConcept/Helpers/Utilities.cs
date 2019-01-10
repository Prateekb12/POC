using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ProofOfConcept
{
    class Utilities
    {
        //Returns WebElement 
        public static IWebElement Element(IWebDriver driver, ObjectType objectType, String objectValue)
        {
            if (objectType == ObjectType.Id)
                return driver.FindElement(By.Id(objectValue));
            else if (objectType == ObjectType.Name)
                return driver.FindElement(By.Name(objectValue));
            else if (objectType == ObjectType.ClassName)
                return driver.FindElement(By.ClassName(objectValue));
            else if (objectType == ObjectType.CssSelector)
                return driver.FindElement(By.CssSelector(objectValue));
            else if (objectType == ObjectType.LinkText)
                return driver.FindElement(By.LinkText(objectValue));
            else if (objectType == ObjectType.PartialLinkText)
                return driver.FindElement(By.PartialLinkText(objectValue));
            else if (objectType == ObjectType.TagName)
                return driver.FindElement(By.TagName(objectValue));
            else if (objectType == ObjectType.XPath)
                return driver.FindElement(By.XPath(objectValue));
            else
                return null;
        }
    }
}
