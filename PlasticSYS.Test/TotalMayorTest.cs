using PlasticSYS.Models;
using Xunit;

namespace PlasticSys.Tests
{
    public class TotalMayorTest
    {
        [Fact]
        public void Total_DebeSerMayorQueCero()
        {
            var venta = new Venta { Total = 50 };

            bool esValido = venta.Total > 0;

            Assert.True(esValido, "El total de la venta debe ser mayor que cero.");
        }
    }
}
