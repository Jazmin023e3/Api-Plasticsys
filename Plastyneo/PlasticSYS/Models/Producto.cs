using System;
using System.Collections.Generic;

namespace PlasticSYS.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public int? MarcaId { get; set; }

    public virtual Marca? Marca { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
