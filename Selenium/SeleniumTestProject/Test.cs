using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestProject
{
    class Test
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            // Inithialize chrome web driver
            driver = new ChromeDriver("S:\\CV\\Selenium\\SeleniumTestProject\\packages\\Selenium.WebDriver.ChromeDriver.89.0.4389.2300\\driver\\win32");
            ////driver = new ChromeDriver("..\\..\\packages\\Selenium.WebDriver.ChromeDriver.89.0.4389.2300\\driver\\win32");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void test1()
        {
            // delay between steps
            int delay = 500;
            IWebElement element;
            IWebElement message;
            // Open rozetka online store
            driver.Url = "https://rozetka.com.ua/";
            // find sign in button
            element = driver.FindElement(By.XPath("//rz-user/button[@class=\"header__button\"]"));
            element.Click();
            Thread.Sleep(delay);
            // fing link "Зарегистрироваться"
            element = driver.FindElement(By.XPath("//form//div/a[@class=\"auth-modal__register-link\"]"));
            element.Click();
            Thread.Sleep(delay);
            // Check field "Имя"
            element = driver.FindElement(By.XPath("//register//form/fieldset/*[@formcontrolname=\"name\"]"));
            element.SendKeys("John");
            Thread.Sleep(delay);
            message = driver.FindElement(By.XPath("//p[@class=\"validation-message\"]"));
            if (message.Text != "Введите свое имя на кириллице")
                throw new Exception("Invalid validation message on name field");
            element.Clear();
            Thread.Sleep(delay);
            element.SendKeys("Ян");
            Thread.Sleep(delay);
            // check field "Фамилия"
            element = driver.FindElement(By.XPath("//register//form/fieldset/*[@formcontrolname = \"surname\"]"));
            element.SendKeys("123456");
            Thread.Sleep(delay);
            message = driver.FindElement(By.XPath("//p[@class=\"validation-message\"]"));
            if (message.Text != "Введите свою фамилию на кириллице")
                throw new Exception("Invalid validation message on surname field");
            element.Clear();
            Thread.Sleep(delay);
            element.SendKeys("Ли");
            Thread.Sleep(delay);
            // check field "Номер телефона"
            element = driver.FindElement(By.CssSelector(".auth-modal fieldset > input[formcontrolname=\"phone\"]"));
            element.SendKeys("0123456text");
            Thread.Sleep(delay);
            message = driver.FindElement(By.XPath("//p[@class=\"validation-message\"]"));
            if (message.Text != "Введите свой номер телефона")
                throw new Exception("Invalid validation message on phone number field");
            Thread.Sleep(delay);
            element.SendKeys("789");
            Thread.Sleep(delay);
            // fill field "Эл. почта"
            element = driver.FindElement(By.CssSelector(".auth-modal input[formcontrolname=\"email\"]"));
            element.SendKeys("example@ex.ex");
            Thread.Sleep(delay);
            // fill field "Придумайте пароль"
            element = driver.FindElement(By.CssSelector("*[type=\"password\"]"));
            element.SendKeys("N0tSimpl3Pa55");
            Thread.Sleep(delay);
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
