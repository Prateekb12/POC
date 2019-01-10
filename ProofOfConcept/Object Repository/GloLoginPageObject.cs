using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;

namespace ProofOfConcept
{
    class GloLoginPageObject
    {
        ////Create Instance of this Page
        //public GloLoginPageObject()
        //{
        //    PageFactory.InitElements(Properties.driver, this);
        //}

        //[FindsBy(How = How.Id, Using = "login")]
        //public IWebElement userName { get; set; }

        //[FindsBy(How = How.Id, Using = "password")]
        //public IWebElement password { get; set; }

        //[FindsBy(How = How.XPath, Using = ".//INPUT[contains(@class,'pull-right')]")]
        //public IWebElement loginButton { get; set; }


        //Classical way of initializing pages via POM concept
        private readonly RemoteWebDriver _driver;

        public GloLoginPageObject() => _driver = (RemoteWebDriver)Properties.driver;

        public IWebElement userName => _driver.FindElementById("login");
        public IWebElement password => _driver.FindElementById("password");
        public IWebElement loginButton => _driver.FindElementByXPath(".//INPUT[contains(@class,'pull-right')]");

        //Login Method
        public void Login(string username, string passWord)
        {
            userName.EnterText(username);
            password.EnterText(passWord);
            loginButton.Clicks();            
        }
    }
}
