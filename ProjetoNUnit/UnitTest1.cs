using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ProjetoNUnit
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        public void Test1()
        {
            Assert.Pass();
        }
        //[Test]
        public void Exercicio1()
        {

            string nome = "Anderson";

            Assert.AreEqual(nome, "Anderson");
            Assert.IsTrue(nome.Equals("Anderson"));
            Assert.IsFalse(nome.Equals("Jose"));

        }
        [Test]
        [Obsolete]
        public void InstanciarNavegador()
        {
            
            string url ="https://www.google.com.br/";
            string titulo = "Google";
            string urlBase2 = "https://www.base.com.br/";
               

            IWebDriver driver = new ChromeDriver();
            
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.Name("q")).SendKeys("Base2");
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); 
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div > .tF2Cxc")));
            
            driver.FindElement(By.CssSelector("div > .tF2Cxc")).Click();

          

            Assert.AreEqual(urlBase2, driver.Url.ToString());
            //Assert.AreEqual(titulo, driver.Title.ToString());
        }

        [Test]
        [Obsolete]
        public void FillingOutForms()
        {
            string url = "https://ultimateqa.com/filling-out-forms/";
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);

            driver.FindElement(By.Id("et_pb_contact_name_0")).SendKeys("Teste");
            driver.FindElement(By.Id("et_pb_contact_message_0")).SendKeys("Teste1");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); 
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("et_builder_submit_button")));
            driver.FindElement(By.Name("et_builder_submit_button")).Click();
            
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait1.Until(ExpectedConditions.ElementToBeClickable(By.Name("et_builder_submit_button")));    
            driver.FindElement(By.Name("et_builder_submit_button")).Click();

            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait2.Until(ExpectedConditions.ElementToBeClickable(By.Name("et_builder_submit_button")));
            driver.FindElement(By.Name("et_builder_submit_button")).Click();
        }

        [Test]
        public void DropDownList()
        {
            string url = "http://the-internet.herokuapp.com/dropdown";
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);

            driver.FindElement(By.Id("dropdown")).Click();
            //Utilizando CssSelector
            driver.FindElement(By.CssSelector("option[value='2']")).Click();
            driver.FindElement(By.Id("dropdown")).Click();
            //Utilizando o XPath
            driver.FindElement(By.XPath("//option[@value='1']")).Click();


        }
        [Test]
        [Obsolete]
        public void CrowdTest()
        {
            string url = "http://blackmirror.crowdtest.me.s3-website-us-east-1.amazonaws.com/landing";
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);

            driver.FindElement(By.CssSelector("a[class='cc-btn cc-dismiss']")).Click();

            driver.FindElement(By.Id("login")).SendKeys("anderson.silva@base2.com.br");
            driver.FindElement(By.Id("password")).SendKeys("Andin@25");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //Selecionando o bot??o confirmar
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[class='btn btn-crowdtest btn-block']"))); 
            driver.FindElement(By.CssSelector("button[class='btn btn-crowdtest btn-block']")).Click();
            //Selecionando o bot??o Geranciar
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[class='btn btn-crowdtest mr-1']"))); 
            driver.FindElement(By.CssSelector("button[class='btn btn-crowdtest mr-1']")).Click();
            //Selecionando o menu projeto
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div ul > li:nth-child(4)"))); 
            driver.FindElement(By.CssSelector("div ul > li:nth-child(4)")).Click();
            //Selecionando o projeto
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div mat-table mat-row mat-cell"))); 
            driver.FindElement(By.CssSelector("div mat-table mat-row mat-cell")).Click();

            //Acessando o menu Casos de Teste
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[text() ='Casos de Teste']"))); 
            driver.FindElement(By.XPath("//div[text() ='Casos de Teste']")).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div/mat-table/mat-row/mat-cell[text() = '1']"))); 
            string grid = driver.FindElement(By.XPath("//div/mat-table/mat-row/mat-cell[text() = '1']")).ToString();
            
            Assert.IsNotEmpty(grid);
            
        }

    }
}