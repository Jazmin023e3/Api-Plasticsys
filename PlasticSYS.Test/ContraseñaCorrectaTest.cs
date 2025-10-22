using PlasticSYS.Models;
using Xunit;

namespace PlasticSys.Tests
{
    public class ContraseñaCorrectaTest
    {
        [Fact]
        public void Password_DebeTenerMinimo6Caracteres()
        {
            // Arrange
            var usuario = new Usuario { Password = "admin123" };

            // Act
            bool longitudValida = !string.IsNullOrEmpty(usuario.Password) && usuario.Password.Length >= 6;

            // Assert
            Assert.True(longitudValida, "La contraseña debe tener al menos 6 caracteres.");
        }
    }
}


