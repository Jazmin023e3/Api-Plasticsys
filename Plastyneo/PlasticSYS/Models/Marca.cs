using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace PlasticSYS.Models;

public partial class Marca
{
    public int MarcaId { get; set; }
    [Required(ErrorMessage = "El Nombre es obligatorio")]
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
