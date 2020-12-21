﻿// <copyright file="SafariDriverTest.cs" company="TestProject">
// Copyright 2020 TestProject (https://testproject.io)
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestProject.OpenSDK.Drivers.Web;

namespace TestProject.OpenSDK.Tests.Examples.Drivers
{
    /// <summary>
    /// This class contains examples of using the TestProject C# SDK with Safari.
    /// </summary>
    [TestClass]
    public class SafariDriverTest
    {
        /// <summary>
        /// The TestProject SafariDriver instance to be used in this test class.
        /// </summary>
        private SafariDriver driver;

        /// <summary>
        /// Starts a Safari browser with default SafariOptions before each test.
        /// </summary>
        [TestInitialize]
        public void StartBrowser()
        {
            OpenQA.Selenium.Safari.SafariOptions safariOptions = new OpenQA.Selenium.Safari.SafariOptions();
            safariOptions.PageLoadStrategy = PageLoadStrategy.Normal;
            safariOptions.UnhandledPromptBehavior = UnhandledPromptBehavior.DismissAndNotify;

            this.driver = new SafariDriver(
                safariOptions: safariOptions);
        }

        /// <summary>
        /// An example test logging in to the TestProject demo application with Safari.
        /// </summary>
        [TestMethod]
        public void ExampleTestUsingSafariDriver()
        {
            this.driver.Navigate().GoToUrl("https://example.testproject.io");
            this.driver.FindElement(By.CssSelector("#name")).SendKeys("John Smith");
            this.driver.FindElement(By.CssSelector("#password")).SendKeys("12345");
            this.driver.FindElement(By.CssSelector("#login")).Click();

            Assert.IsTrue(this.driver.FindElement(By.CssSelector("#greetings")).Displayed);
        }

        /// <summary>
        /// Closes the browser and ends the development session after each test.
        /// </summary>
        [TestCleanup]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }
    }
}
