using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ProofOfConcept
{
    public static class SeleniumGetMethods
    {
        //Getting innertext of a Web Element
        public static String GetText(this IWebElement element)
        {
            return element.Text;
        }

        //Getting Value of a Web Element
        public static String GetValue(this IWebElement element)
        {
            return element.GetAttribute("value");
        }

        //Getting first option from the drop down list
        public static String GetTextFromDDL(this IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }
    }
}
