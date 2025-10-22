using PlasticSYS.Models;
using Xunit;

namespace PlasticSys.Tests
{
    public class ProductoNoVacioTest
    {
        [Fact]
        public void Nombre_NoDebeEstarVacio()
        {
            var producto = new Producto { Nombre = "Botella" }; // ✅ Valor válido

            bool estaVacio = string.IsNullOrWhiteSpace(producto.Nombre);

            Assert.False(estaVacio, "El nombre del producto no debe estar vacío.");
        }
    }
}
