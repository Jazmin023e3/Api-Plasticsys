using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // 👈 NECESARIO para [NotMapped]

namespace PlasticSYS.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    [EmailAddress]
    public string Correo { get; set; } = null!;

    [Display(Name = "Contraseña")]
    [DataType(DataType.Password)]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "El password debe tener entre 5 y 50 caracteres.")]
    public string Pasword { get; set; } = null!; // 👈 La columna real de tu DB

    public string Rol { get; set; } = null!;

    // 👇 Propiedades necesarias para las pruebas que NO deben mapearse a la DB
    [NotMapped]
    public string Password { get; set; } = string.Empty; // Inicializado para evitar null

    [NotMapped]
    public string? NombreUsuario { get; set; }
}