using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
    public string Pasword { get; set; } = null!;

    public string Rol { get; set; } = null!;
}
