using System;
using System.Runtime;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpotifyUITest
{
    public class SpotifyLoginPageTests
    {
        private IWebDriver driver;
		
        [SetUp]
        public void SetUp()
        {
			string currentDirectory = Environment.CurrentDirectory;
			if(string.IsNullOrEmpty(currentDirectory))
			{
				throw new ArgumentNullException("currentDirectory is null");
			}
			string chromeDriverPath = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
			if(string.IsNullOrEmpty(chromeDriverPath))
			{
				throw new ArgumentNullException("chromeDriverPath is null");
			}
            driver = new ChromeDriver(chromeDriverPath);
        }

        [Test]
        public void LoginPage_WhenLoginPageIsOpen_TitleIsCorrect()
        {
            driver.Url = "https://accounts.spotify.com/en/login";
            var title = "Login - Spotify";
            Assert.AreEqual(title, driver.Title);
        }

        [Test]
        public void LoginPage_ForgotYourPassword_HasCorrectLinkAndText()
        {
            driver.Url = "https://accounts.spotify.com/en/login";
            var element = driver.FindElement(By.Id("reset-password-link"));
            var linkText = element.Text;
            element.Click();
            Assert.AreEqual(linkText, "Forgot your password?");
            Assert.AreEqual("https://www.spotify.com/ua-en/password-reset/", driver.Url);
        }


        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}