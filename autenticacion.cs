using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PruebasAutenticacion
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://ejemplo.com/login");

            // Credenciales válidas
            ProbarInicioSesion(driver, "usuarioValido", "contrasenaValida");

            // Credenciales inválidas
            ProbarInicioSesion(driver, "usuarioInvalido", "contrasenaInvalida");

            driver.Quit();
        }

        static void ProbarInicioSesion(IWebDriver driver, string usuario, string contrasena)
        {
            IWebElement campoUsuario = driver.FindElement(By.Id("usuario"));
            IWebElement campoContrasena = driver.FindElement(By.Id("contrasena"));
            IWebElement botonInicioSesion = driver.FindElement(By.Id("botonInicioSesion"));

            campoUsuario.Clear();
            campoContrasena.Clear();
            campoUsuario.SendKeys(usuario);
            campoContrasena.SendKeys(contrasena);
            botonInicioSesion.Click();

            try
            {
                IWebElement mensajeError = driver.FindElement(By.Id("mensajeError"));
                Console.WriteLine($"Inicio de sesión fallido para {usuario}");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine($"Inicio de sesión exitoso para {usuario}");
            }
        }
    }
}
