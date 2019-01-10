using System;
using OpenQA.Selenium;

namespace ProofOfConcept.Actions
{
    class Operations
    {
        GloLoginPageObject gloLoginPageObject = new GloLoginPageObject();
        public void OperationsOnObject(string objectOR, string objectName, string action, string testData)
        {
            dynamic objectORName = ObjectORName(objectOR);
            dynamic objectsName = ObjectsName(objectName);
            switch (action)
            {
                case "OpenURL":
                    SeleniumSetMethods.openURL(testData);
                    break;
                case "EnterText":
                    //dynamic userName = ObjectPRName(objectName);
                    
                    break;
                default:
                    Console.WriteLine("Wrong Action Name");
                    break;
            }
            
        }

        private IWebElement ObjectsName(string objectName)
        {
            IWebElement element;
            return null;
        }

        private dynamic ObjectORName(string objectOR)
        {
            switch (objectOR)
            {
                case "GloLoginPageObject":
                    return new GloLoginPageObject();
                //case "GloLogoutPageObject":
                //    return new GloLogoutPageObject();
                default:
                    return null;                    
            }
        }
    }
}
