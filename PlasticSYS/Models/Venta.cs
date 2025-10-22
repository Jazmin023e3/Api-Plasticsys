using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // 👈 NECESARIO para [NotMapped]

namespace PlasticSYS.Models;

public partial class Venta
{
    public int VentaId { get; set; }

    [Display(Name = "Fecha de venta")]
    public DateTime? FechaVenta { get; set; }

    [Required(ErrorMessage = "El Total es obligatorio")]
    public decimal Total { get; set; }

    [Display(Name = "Cliente")]
    [Required(ErrorMessage = "El Cliente es obligatorio")]
    public int? ClienteId { get; set; }

    [Display(Name = "Producto")]
    [Required(ErrorMessage = "El Producto es obligatorio")]
    public int? ProductoId { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Producto? Producto { get; set; }

    // 👇 Propiedad 'Cantidad' para las pruebas. 
    // EF Core la ignora en la DB, pero está disponible en el código C#.
    [NotMapped]
    public int Cantidad { get; set; }
} 