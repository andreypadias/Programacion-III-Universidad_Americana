using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuchosAmuchos.Models
{
    public class Factura
    {
        [Key]
        public int FacturaId { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        // Relación muchos a uno con Cliente
        public int ClienteId { get; set; }

        public decimal MontoTotal { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; } //Propiedad de navegación

        public virtual ICollection<ProductosFactura> ProductosFacturas { get; set; }

        

}
}
