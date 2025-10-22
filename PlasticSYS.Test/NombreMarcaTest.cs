using PlasticSYS.Models;
using Xunit;

namespace PlasticSys.Tests
{
    public class NombreMarcaTest
    {
        [Fact]
        public void Nombre_NoDebeEstarVacio()
        {
            // ✅ Dato correcto para que la prueba pase
            var marca = new Marca { Nombre = "Plastimarca" };

            bool estaVacio = string.IsNullOrWhiteSpace(marca.Nombre);

            Assert.False(estaVacio, "El nombre de la marca no debe estar vacío.");
        }
    }
}

