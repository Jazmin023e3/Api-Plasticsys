using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // 👈 Step 1: Add this using statement

namespace PlasticSYS.Models;

public partial class Marca
{
    public int MarcaId { get; set; }

    [Required(ErrorMessage = "El Nombre es obligatorio")]
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    // 👇 Step 2: Add the [NotMapped] attribute to the property your tests need
    [NotMapped]
    public string? TestingNotes { get; set; } // Example property for testing
}