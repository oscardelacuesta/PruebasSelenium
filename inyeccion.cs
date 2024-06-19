using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PruebasInyeccion
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://ejemplo.com/busqueda");

            // Intento de inyección SQL
            IWebElement campoBusqueda = driver.FindElement(By.Id("consultaBusqueda"));
            campoBusqueda.SendKeys("'; DROP TABLE usuarios; --");
            campoBusqueda.Submit();

            // Verificar si la página muestra un error de base de datos
            if (driver.PageSource.Contains("error de base de datos"))
            {
                Console.WriteLine("Posible vulnerabilidad de inyección SQL detectada.");
            }
            else
            {
                Console.WriteLine("No se detectó vulnerabilidad de inyección SQL.");
            }

            driver.Quit();
        }
    }
}
