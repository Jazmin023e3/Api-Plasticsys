using PlasticSYS.Models;
using Xunit;

namespace PlasticSys.Tests
{
    public class VentaClienteTest
    {
        [Fact]
        public void Venta_DebeTenerCliente()
        {
            var venta = new Venta
            {
                ClienteId = 1 // ✅ Cliente existente
            };

            bool tieneCliente = venta.ClienteId > 0;

            Assert.True(tieneCliente, "La venta debe estar asociada a un cliente válido.");
        }
    }
}

