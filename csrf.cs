using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PruebasCSRF
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://ejemplo.com/formulario");

            // Enviar el formulario sin token CSRF
            IWebElement botonEnviar = driver.FindElement(By.Id("botonEnviar"));
            botonEnviar.Click();

            // Verificar si la página muestra un error relacionado con CSRF
            if (driver.PageSource.Contains("Token CSRF faltante o incorrecto"))
            {
                Console.WriteLine("La protección CSRF está en su lugar.");
            }
            else
            {
                Console.WriteLine("No se detectó protección CSRF.");
            }

            driver.Quit();
        }
    }
}
