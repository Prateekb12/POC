using System;
using System.Drawing.Imaging;
using OpenQA.Selenium;

namespace ProofOfConcept.Helpers
{
    class takeScreenshots
    {
        public string TakeScreenshot()
        {
            ITakesScreenshot ts = (ITakesScreenshot)Properties.driver;
            Screenshot screenshot = ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin")) + "Screenshots\\" + "abc";
            string screenShotPath = new Uri(actualPath).LocalPath;
            //string screenShotPath = projectPath + "Screenshots";
            //Console.WriteLine(screenShotPath);
            screenshot.SaveAsFile(screenShotPath, ScreenshotImageFormat.Png);

            return screenShotPath;
        }
    }
}
