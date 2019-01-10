using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace ProofOfConcept
{
    [TestFixture]
    class TestCases
    {
        public ExtentTest test;
        Reporting.Report report = new Reporting.Report();
        Helpers.takeScreenshots helpers = new Helpers.takeScreenshots();

        static void Main(string[] args)
        {
        }

        [OneTimeSetUp]
        public void StartReport()
        {             
            report.GenerateReport();
        }

        [SetUp]
        public void Initialize()
        {
            //Create the reference for our browser
            Properties.driver = new ChromeDriver();
            Properties.driver.Manage().Window.Maximize();
        }

        [Test]
        public void ExecuteTest()
        {
            test = report.CreateTest("ExecuteTest");
            Properties.driver.Navigate().GoToUrl("https://glo.globallogic.com");

            ExcelLiabrary.PopulateInCollection(ExcelLiabrary.fileName());

            GloLoginPageObject gloLoginPageObject = new GloLoginPageObject();

            helpers.TakeScreenshot();
            gloLoginPageObject.Login(ExcelLiabrary.ReadData(1, "Username"), ExcelLiabrary.ReadData(1, "Password"));
        }

        [Test]
        public void PassingTest()
        {
            test = report.CreateTest("Passing Test");

            Properties.driver.Navigate().GoToUrl("http://www.google.com");

            try
            {
                Assert.IsTrue(true);
                test.Pass("Assertion passed");
            }
            catch (AssertionException)
            {
                test.Fail("Assertion failed");
                throw;
            }
        }

        [Test]
        public void FailingTest()
        {
            test = report.CreateTest("Failing test");
             
            Properties.driver.Navigate().GoToUrl("http://www.yahoo.com");
            try
            {
                Assert.IsTrue(false);
                test.Pass("Assertion passed");
            }
            catch (AssertionException)
            {
                test.Fail("Assertion failed");
                throw;
            }
        }


        [TearDown]
        public void CleanUp()
        {
            Properties.driver.Quit();
            //Console.WriteLine("Closed Browser");
        }

        [OneTimeTearDown]
        public void EndReport()
        {
            report.FlushExtent();
        }
    }   
}
