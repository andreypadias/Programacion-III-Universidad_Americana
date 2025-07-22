using System;
using System.Collections.Generic;

namespace ProyectoEjemplo.Models;

public partial class Factura
{
    public int Id { get; set; }

    public decimal? MontoTotal { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly? Fecha { get; set; }

    public virtual ICollection<FacturaProducto> FacturaProductos { get; set; } = new List<FacturaProducto>();
}
