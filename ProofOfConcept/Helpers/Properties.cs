using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ProofOfConcept
{
    enum ObjectType
    {
        Id,
        Name,
        ClassName,
        CssSelector,
        LinkText,
        PartialLinkText,
        TagName,
        XPath
    }
    class Properties
    {
        //Auto-implemeted property
        public static IWebDriver driver { get; set; }
    }
}
