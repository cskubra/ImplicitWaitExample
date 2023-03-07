using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;



namespace ImplicitWaitExample
{
    public class EaseMyTrip
    {
        private IWebDriver driver;
        private string test_url = "https://www.easemytrip.com";

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-web-security");

            driver = new ChromeDriver(@"D:\WebDriver\Chrome", options);

            driver.Navigate().GoToUrl(test_url);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestSearch()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            // select round-trip flight destinations
            
            IWebElement fromSector = driver.FindElement(By.Id("FromSector_show"));
            fromSector.Click();

            IWebElement fromDelhi = driver.FindElement(By.XPath("//span[@class='flsctrhead']"));
            fromDelhi.Click();

            IWebElement toSector = driver.FindElement(By.Id("tocity"));
            toSector.Click();

            IWebElement toKolkata = driver.FindElement(By.XPath("//div[@id='toautoFill']/ul[1]/li[4]/div[1]"));
            toKolkata.Click();

            //select the round-trip flight dates and click the search button
            IWebElement Date = driver.FindElement(By.Id("ddate"));
            Date.Click();

            IWebElement departureDate = driver.FindElement(By.Id("snd_0_02/04/2023"));
            departureDate.Click();

            IWebElement rtnDate = driver.FindElement(By.Id("divRtnCal"));
            rtnDate.Click(); 

            IWebElement retuneDate = driver.FindElement(By.Id("snd_6_08/04/2023"));
            retuneDate.Click();

            IWebElement btnSearch = driver.FindElement(By.XPath("//button[@class='srchBtnSe']"));
            btnSearch.Click();

            Thread.Sleep(8000);

            //choose the ready flights that the site gives
            IWebElement bookNow = driver.FindElement(By.Id("BtnBookNow"));
            bookNow.Click();

            IWebElement btnContinue = driver.FindElement(By.XPath("//a[@class='countnbtn']"));
            btnContinue.Click();

            IWebElement insuranceBtn = driver.FindElement(By.XPath("//input[@id='notinsure']/following-sibling::span[1]"));
            insuranceBtn.Click();

            // Write e-mail information for the planned flight
            IWebElement entryEmail = driver.FindElement(By.Id("txtEmailId"));
            entryEmail.SendKeys("testing@gmail.com");

            IWebElement continueBook = driver.FindElement(By.Id("spnVerifyEmail"));
            continueBook.Click();

            // Write all information for the planned flight
            IWebElement title = driver.FindElement(By.Id("titleAdult0"));
            
            SelectElement titleTraveller = new SelectElement(title);         

            titleTraveller.SelectByText("MS");
            
            driver.FindElement(By.Id("txtFNAdult0")).SendKeys("Kubra");
            
            driver.FindElement(By.Id("txtLNAdult0")).SendKeys("Caliskan");

            driver.FindElement(By.Id("txtCountryCode")).SendKeys("+90"); 

            driver.FindElement(By.Id("txtCPhone")).SendKeys("5228852255");
            
            


        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}

