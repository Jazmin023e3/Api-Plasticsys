using PlasticSYS.Models;
using PlasticSys; // 👈 Namespace de tu proyecto principal
using Xunit;

namespace PlasticSys.Tests
{
    public class ProductoTests
    {
        [Fact]
        public void CrearProducto_DebeTenerNombrePrecioYMarcaId()
        {
            // Crear un producto de prueba
            var producto = new Producto
            {
                Nombre = "Producto Test",
                Precio = (decimal)50.0,
                MarcaId = 1
            };

            // Verificar que las propiedades se asignaron correctamente
            Assert.Equal("Producto Test", producto.Nombre);
            Assert.Equal((decimal)50.0, producto.Precio);
            Assert.Equal(1, producto.MarcaId);
        }
    }
}