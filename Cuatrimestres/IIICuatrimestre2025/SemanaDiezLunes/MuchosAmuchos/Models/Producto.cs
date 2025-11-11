using System.ComponentModel.DataAnnotations;

namespace MuchosAmuchos.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage ="El nombre del producto es obligatorio.")]
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public bool Disponible { get; set; } = true;

        public virtual ICollection<ProductosFactura> ProductosFacturas { get; set; }
    }
}
