using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoEjemplo.Models;

public partial class FacturaProducto
{
    public int Id { get; set; }

    public int IdFactura { get; set; }

    public int IdProducto { get; set; }

    [ForeignKey("IdFactura")]
    public  Factura IdFactura { get; set; } = null!;

    [ForeignKey("IdProducto")]
    public  Producto IdProducto { get; set; } = null!;
}
