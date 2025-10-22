using PlasticSYS.Models;
using Xunit;

namespace PlasticSys.Tests
{
    public class NombreUsuarioTest
    {
        [Fact]
        public void NombreUsuario_NoDebeEstarVacio()
        {
            // Arrange
            var usuario = new Usuario { NombreUsuario = "admin01" };

            // Act
            bool estaVacio = string.IsNullOrWhiteSpace(usuario.NombreUsuario);

            // Assert
            Assert.False(estaVacio, "El nombre de usuario no debe estar vacío.");
        }
    }
}
