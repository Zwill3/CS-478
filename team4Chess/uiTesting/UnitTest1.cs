using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Windows;
using Appium;

namespace uiTesting
{
    public class Tests
    {
        protected const string winAppDriverURL = "http://127.0.0.1:4723";
        private const string projectID = @"C:\Users\Lucas Zoglmann\Documents\GitHub\CS-478\team4Chess\team4Chess\bin\Debug\netcoreapp3.1\team4Chess.exe";

        protected static WindowsDriver<WindowsElement> session;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            if (session == null)
            {
                var appiumOptions  = new AppiumOptions();
                appiumOptions.AddAdditionalCapability("app", projectID);
                session = new WindowsDriver<WindowsElement>(new Uri(winAppDriverURL), appiumOptions);
            }
        }

        [TestMethod]
        public void Test1()
        {
            session.FindElementByAccessibilityId("E2").Click();
            session.FindElementByAccessibilityId("E4").Click();
            session.FindElementByAccessibilityId("G1").Click();
            session.FindElementByAccessibilityId("F3").Click();
            session.FindElementByAccessibilityId("D2").Click();
            session.FindElementByAccessibilityId("D3").Click();
            session.FindElementByAccessibilityId("B1").Click();
            session.FindElementByAccessibilityId("C3").Click();
        }
    }
}