using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuchosAmuchos.Models
{
    public class ProductosFactura
    {
        [Key]
        public int ProductosFacturaID { get; set; }

        public int FacturaId { get; set; }

        public int ProductoId { get; set; }

        [ForeignKey("FacturaId")]
        public Factura Factura { get; set; } 

        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }
    }
}
