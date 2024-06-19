using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PruebasAutorizacion
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://ejemplo.com/paginaRestringida");

            try
            {
                IWebElement contenidoRestringido = driver.FindElement(By.Id("contenidoRestringido"));
                Console.WriteLine("Acceso concedido al contenido restringido.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Acceso denegado al contenido restringido.");
            }

            driver.Quit();
        }
    }
}
