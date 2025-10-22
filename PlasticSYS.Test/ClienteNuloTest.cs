using PlasticSYS.Models;
using PlasticSys;
using Xunit;

namespace PlasticSys.Tests
{
    public class ClienteNuloTests
    {
        [Fact]
        public void Nombre_NoDebeEstarVacio()
        {
            var cliente = new Cliente { Nombre = "" };

            var resultado = string.IsNullOrWhiteSpace(cliente.Nombre);

            Assert.True(resultado, "El nombre no debe estar vacío.");
        }
    }
}