using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace ProofOfConcept.Reporting
{
    class Report
    {
        public ExtentReports extent;        
        private static ExtentHtmlReporter htmlReporter;

        public void GenerateReport()
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;

            string reportPath = projectPath + @"Reports\ExtentReport _" + $"{DateTime.Now:dd-MM-yyyy_(hh-mm-ss)}" + ".html";
            htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);

            extent.AddSystemInfo("Host Name", "Benika");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("User Name", "Benika Kharbanda");
        }

        public ExtentTest CreateTest(string testName)
        {
            return extent.CreateTest(testName);
        }

        public void FlushExtent()
        {
            extent.Flush();
        }
    }
}
