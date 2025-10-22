using PlasticSYS.Models;
using Xunit;
using PlasticSys; // 👈 Namespace de tu proyecto principal

namespace PlasticSys.Tests
{
    public class MarcaTests
    {
        [Fact]
        public void CrearMarca_DebeTenerNombre()
        {
            // Crear una marca de prueba
            var marca = new Marca
            {
                Nombre = "Marca Test"
            };

            // Verificar que la propiedad se asignó correctamente
            Assert.Equal("Marca Test", marca.Nombre);
        }
    }
}