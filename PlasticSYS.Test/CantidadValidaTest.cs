using PlasticSYS.Models;
using Xunit;

namespace PlasticSys.Tests
{
    public class CantidadValidaTest
    {
        [Fact]
        public void Cantidad_DebeSerMayorQueCero()
        {
            var venta = new Venta { Cantidad = 3 };

            bool esValido = venta.Cantidad > 0;

            Assert.True(esValido, "La cantidad debe ser mayor a cero.");
        }
    }
}
