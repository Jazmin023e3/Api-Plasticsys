using PlasticSYS.Models;
using PlasticSys;
using System.Text.RegularExpressions;
using Xunit;

namespace PlasticSys.Tests
{
    public class CorreoTCorrectoests
    {
        [Fact]
        public void Correo_DebeTenerFormatoValido()
        {
            var cliente = new Cliente { Correo = "juan@mail.com" };

            bool esValido = Regex.IsMatch(cliente.Correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            Assert.True(esValido, "El formato del correo no es válido.");
        }
    }
}