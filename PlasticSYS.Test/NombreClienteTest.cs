using PlasticSYS.Models;
using Xunit;

namespace PlasticSys.Tests
{
    public class NombreClienteTest
    {
        [Fact]
        public void Nombre_NoDebeContenerNumeros_Correcto()
        {
            var cliente = new Cliente { Nombre = "María Lopez" };

            bool tieneNumero = false;
            foreach (char c in cliente.Nombre)
            {
                if (char.IsDigit(c))
                {
                    tieneNumero = true;
                    break;
                }
            }

            Assert.False(tieneNumero, "El nombre del cliente no debe contener números.");
        }
    }
}

