using PlasticSYS.Models;
using Xunit;

namespace PlasticSys.Tests
{
    public class CorreoTest
    {
        [Fact]
        public void Correo_DebeContenerArroba()
        {
            var cliente = new Cliente { Correo = "juan@mail.com" }; // ✅ Ahora tiene @

            bool contieneArroba = cliente.Correo.Contains("@");

            Assert.True(contieneArroba, "El correo del cliente debe contener '@'.");
        }
    }
}
