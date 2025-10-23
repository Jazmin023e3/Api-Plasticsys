using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlasticSYS.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }
    [Required(ErrorMessage = "El Nombre es obligatorio")]
    public string Nombre { get; set; } = null!;
    [Required(ErrorMessage = "El Email es obligatorio")]
    public string Email { get; set; } = null!;
    [Required(ErrorMessage = "El telefono es obligatorio")]
    public string Telefono { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
