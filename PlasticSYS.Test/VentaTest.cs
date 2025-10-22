using PlasticSYS.Models;
using PlasticSys; // 👈 Namespace de tu proyecto principal
using Xunit;

namespace PlasticSys.Tests
{
    public class VentaTests
    {
        [Fact]
        public void CrearVenta_DebeTenerProductoCantidadYTotal()
        {
            // Crear una venta de prueba
            var venta = new Venta
            {
                ProductoId = 1,
                Cantidad = 2,
                Total = (decimal)100.0
            };

            // Verificar que las propiedades se asignaron correctamente
            Assert.Equal(1, venta.ProductoId);
            Assert.Equal(2, venta.Cantidad);
            Assert.Equal((decimal)100.0, venta.Total);
        }
    }
}