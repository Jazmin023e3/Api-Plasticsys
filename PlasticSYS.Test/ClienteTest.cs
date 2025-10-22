using PlasticSYS.Models;
using PlasticSys; // 👈 Aquí el namespace de tu proyecto principal donde está la clase Cliente
using Xunit;

namespace PlasticSys.Tests
{
    public class ClienteTests
    {
        [Fact]
        public void CrearCliente_DebeTenerNombreYCorreo()
        {
            // Crear un cliente de prueba
            var cliente = new Cliente
            {
                Nombre = "Juan Pérez",
                Correo = "juan@mail.com"
            };

            // Verificar que las propiedades se asignaron correctamente
            Assert.Equal("Juan Pérez", cliente.Nombre);
            Assert.Equal("juan@mail.com", cliente.Correo);
        }
    }
}