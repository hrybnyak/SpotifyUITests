using System;
using System.Runtime;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpotifyUITest
{
    public class SpotifySignupPageTests
    {
        private IWebDriver driver;
		
        [SetUp]
        public void SetUp()
        {
            var co = new ChromeOptions();
            co.AddArgument("no-sandbox");
            driver = new ChromeDriver();
        }

        [Test]
        public void SignupPage_WhenInvalidValueIsEnteredForEmail_BorderTurnsRed()
        {
            driver.Url = "https://www.spotify.com/uk/signup/";
            var element = driver.FindElement(By.Id("email"));
            element.SendKeys("12fhufuis");
            driver.FindElement(By.Id("confirm")).Click();
            element = driver.FindElement(By.Id("email"));
            var elementBorderColor = element.GetCssValue("box-shadow");
            Assert.AreEqual("rgb(226, 33, 52) 0px 0px 0px 1px inset", elementBorderColor);
        }

        [Test]
        public void SignupPage_WhenValidValueIsEnteredForBirthDateDayValue_BorderStaysNormal()
        {
            driver.Url = "https://www.spotify.com/uk/signup/";
            var element = driver.FindElement(By.Id("day"));
            element.SendKeys("12");
            driver.FindElement(By.Id("month")).Click();
            element = driver.FindElement(By.Id("day"));
            var elementBorderColor = element.GetCssValue("border-color");
            Assert.AreEqual("rgb(0, 0, 0)", elementBorderColor);
        }

        [Test]
        public void SignupPage_PaddingForConfirmBox_Is14px()
        {
            driver.Url = "https://www.spotify.com/uk/signup/";
            var element = driver.FindElement(By.Id("confirm"));
            var elementPadding = element.GetCssValue("padding");
            Assert.AreEqual("14px", elementPadding);
        }

        [TearDown]
        public void TearDown()
        {
			if (driver != null)
			{
				driver.Dispose();
			}
        }
    }
}
